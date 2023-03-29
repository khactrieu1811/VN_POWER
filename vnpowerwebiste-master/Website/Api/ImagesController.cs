using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Logging;
using Model;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Processing;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Website.Helpers;
using Image = SixLabors.ImageSharp.Image;

namespace Website.Api
{
    [Authorize(JwtBearerDefaults.AuthenticationScheme)]
    [Route("api/[controller]")]
    [ApiController]
    public class ImagesController : ControllerBase
    {
        private readonly IFileProvider _fileProvider;
        private readonly IDistributedCache _cache;
        protected IHttpContextAccessor _httpContextAccessor;
        private ILogger<ImagesController> _logger;
        private string _urlServerImage = string.Empty;

        public ImagesController(ILogger<ImagesController> logger, IWebHostEnvironment env,
            IHttpContextAccessor httpContextAccessor,
            IDistributedCache cache)
        {

            _logger = logger;
            _fileProvider = env.WebRootFileProvider;
            _cache = cache;
            _httpContextAccessor = httpContextAccessor;
        }
        [HttpPost("UploadFileImageForum")]
        public IActionResult UploadFileImageForum(IFormFile image)
        {

            try
            {
                string folder = $"UploadFiles/Images/Forum/{DateTime.Now:yyyy}/{DateTime.Now:MM}/{DateTime.Now:dd}/";
                // full path to file in temp location
                var filePath = Path.Combine(
                    Directory.GetCurrentDirectory(), "wwwroot",
                    folder);

                bool folderExists = Directory.Exists(filePath);
                if (!folderExists)
                    Directory.CreateDirectory(filePath);

                var url = "";

                if (image.Length > 0)
                {
                    var id = Guid.NewGuid();
                    var fullpath = filePath + $"{id}_{image.FileName.Replace(" ", "")}";

                    using (var img = Image.Load(image.OpenReadStream()))
                    {
                        int width = img.Width;
                        if (img.Width > 4000)
                        {
                            width = 4000;
                        }
                        img.Mutate(x => x
                             .Resize(width, 0)
                         );

                        img.Save(fullpath);

                        url = url + folder + $"{id}_{image.FileName}";
                    }
                }

                return Ok(new
                {
                    Message = "Thành công",
                    Data = $"{url}"
                }
                );
            }
            catch (Exception exp)
            {

                _logger.LogCritical($"Exception generated when uploading file - {exp.Message} ");
                string message = $"file / upload failed!";
                return Ok(message);
            }
        }

        [HttpPost("UploadFileImage")]
        public IActionResult UploadFileImage(IFormFile image)
        {

            try
            {
                string folder = $"UploadFiles/Images/{DateTime.Now:yyyyMMdd}";
                // full path to file in temp location
                var filePath = Path.Combine(
                    Directory.GetCurrentDirectory(), "wwwroot",
                    folder);

                bool folderExists = Directory.Exists(filePath);
                if (!folderExists)
                    Directory.CreateDirectory(filePath);

                var url = "";

                if (image.Length > 0)
                {
                    var id = Guid.NewGuid();
                    var fullpath = filePath + $"{id}_{image.FileName.Replace(" ", "")}";

                    using (var img = Image.Load(image.OpenReadStream()))
                    {
                        int width = img.Width;
                        if (img.Width > 1000)
                        {
                            width = 1000;
                        }
                        img.Mutate(x => x
                             .Resize(width, 0)
                         );

                        img.Save(fullpath);

                        url =   url + folder + $"{id}_{image.FileName}";
                    }
                }

                return Ok(new
                {
                    Message = "Thành công",
                    Data = $"{GetUrlServerImage()}/{url}"
                }
                );
            }
            catch (Exception exp)
            {

                _logger.LogCritical($"Exception generated when uploading file - {exp.Message} ");
                string message = $"file / upload failed!";
                return Ok(message);
            }
        }

        [HttpPost("UploadFileImageRadiography")]
        public IActionResult UploadFileImageRadiography(IFormFile image)
        {

            try
            {
                string folder = $"UploadFiles/Images/Radiography/{DateTime.Now:yyyyMMdd}/";
                // full path to file in temp location
                var filePath = Path.Combine(
                    Directory.GetCurrentDirectory(), "wwwroot",
                    folder);

                bool folderExists = Directory.Exists(filePath);
                if (!folderExists)
                    Directory.CreateDirectory(filePath);

                var url = "";

                if (image.Length > 0)
                {
                    var id = Guid.NewGuid();
                    var name = image.FileName.Replace(" ", "");
                    var fullpath = filePath + $"{id}_{name}";

                    using (var img = Image.Load(image.OpenReadStream()))
                    {

                        img.Save(fullpath);

                        url = url + folder + $"{id}_{name}";
                    }
                }

                return Ok(new ResponseUploadModel
                {
                    Message = "Thành công",
                    Data = $"{url}",
                    Success = true
                }
                );
            }
            catch (Exception exp)
            {

                _logger.LogCritical($"Exception generated when uploading file - {exp.Message} ");
                string message = $"file / upload failed!";
                return Ok(message);
            }
        }

        [HttpPost("UploadListFileImageRadiography")]
        public IActionResult UploadListFileImageRadiography(IFormFile[] images)
        {

            try
            {
                string folder = $"UploadFiles/Images/Radiography/{DateTime.Now:yyyyMMdd}";
                // full path to file in temp location
                var filePath = Path.Combine(
                    Directory.GetCurrentDirectory(), "wwwroot",
                    folder);

                bool folderExists = Directory.Exists(filePath);
                if (!folderExists)
                    Directory.CreateDirectory(filePath);

                var url = "";
                var listFile = new List<UploadFile>();
                if (images.Count() > 0)
                {
                    foreach (var image in images)
                    {

                        if (image.Length > 0)
                        {
                            var id = Guid.NewGuid();
                            var name = image.FileName.Replace(" ", "");
                            var fullpath = filePath + $"{id}_{name}";
                            if (image.ContentType == "application/pdf")
                            {
                                using (var fileStream = new FileStream(fullpath, FileMode.Create))
                                {
                                    image.CopyTo(fileStream);
                                }
                            }
                            else
                            {
                                using (var img = Image.Load(image.OpenReadStream()))
                                {

                                    img.Save(fullpath);
                                    
                                }

                            }
                            var fileuploaded = new UploadFile()
                            {
                                FileName = name,
                                Url = GetUrlServerImage() + url + folder + $"{id}_{name}"
                            };
                            listFile.Add(fileuploaded);

                        }
                    }
                }


                return Ok(new ResponseUploadModel
                {
                    Message = "Thành công",
                    Data = JsonSerializer.Serialize(listFile)
                });
            }
            catch (Exception exp)
            {

                _logger.LogCritical($"Exception generated when uploading file - {exp.Message} ");
                string message = $"file / upload failed!";
                return Ok(message);
            }
        }

        [HttpPost("UploadFilesToCnd")]
        public async Task<IActionResult> UploadFilesToCnd(IFormFile file)
        {




            return Ok(new
            {
                Message = "Thành công",
                Data = $""
            }
            );
        }

        private void Image_resize(string input_Image_Path, string output_Image_Path, int width = 500, int height = 320)
        {
            using (var image = Image.Load(input_Image_Path))
            {
                image.Mutate(x => x
                     .Resize(image.Width > width ? width : image.Width, image.Height > height ? height : image.Height));
                image.Save(output_Image_Path);
            }
        }

        private string GetUrlServerImage()
        {
            _urlServerImage = SettingsConfigHelper.UrlServerImage();
            if (string.IsNullOrEmpty(_urlServerImage))
            {
                _urlServerImage = string.Format("{0}://{1}", _httpContextAccessor.HttpContext.Request.Scheme, _httpContextAccessor.HttpContext.Request.Host.Value);

            }

            return _urlServerImage;
        }
    }
}