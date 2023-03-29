using Business.IRepostitory;
using Common;
using Entities.Entities;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;

namespace Website.Controllers
{
    [Authorize(JwtBearerDefaults.AuthenticationScheme)]
    public class SettingsController : Controller
    {
        private readonly ISettingsRepository _settingsRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<SettingsController> _logger;



        public SettingsController(ISettingsRepository settingsRepository,
            ILogger<SettingsController> logger, IMapper mapper)
        {
            _mapper = mapper;
            _logger = logger;
            _settingsRepository = settingsRepository;
        }
        public IActionResult Index()
        {
            var data = _settingsRepository.GetAllData().FirstOrDefault();
            var model = _mapper.Map<SettingModel>(data);
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(SettingModel model)
        {
            var settings = _mapper.Map<Settings>(model);
            try
            {
                if (settings != null)
                {
                    if (model.FileLogo != null)
                    {
                        string folder = $"UploadFiles/Images/Settings/{DateTime.Now:yyyyMMdd}/";
                        settings.Logo = ImageUtils.UploadFileImage(model.FileLogo, folder);
                    }
                    _settingsRepository.Update(settings);
                    return RedirectToAction("Index");
                }
                ModelState.AddModelError(string.Empty, string.Format(MessageConstants.NotExists, "Setting"));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                ModelState.AddModelError(string.Empty, ex.Message);
            }
            return View(settings);
        }
    }
}
