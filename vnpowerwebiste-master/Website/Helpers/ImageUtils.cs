using Microsoft.AspNetCore.Http;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Processing;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Website
{
    public class ImageUtils
    {
       
        public static string UploadFileImage(IFormFile image, string folder)
        {

            try
            {

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
                    string name = $"{id}_{image.FileName.Replace(" ", "")}";
                    var fullpath = filePath + name;

                    using (var img = Image.Load(image.OpenReadStream()))
                    {
                        int width = img.Width;
                        if (img.Width > 800)
                        {
                            width = 800;
                        }
                        img.Mutate(x => x
                             .Resize(width, 0)
                         );

                        img.Save(fullpath);

                        url =  url + folder + name;
                    }
                }

                return url;
            }
            catch
            {
                throw;
            }
        }
        
    }
}
