using AutoMapper;
using Business.IRepostitory;
using Entities.Entities;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Model;
using Model.APIs;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace Website.Api
{

    [Route("api")]
    [ApiController]
    [EnableCors("AllowAll")]
    public class SettingController : ControllerBase
    {
        private readonly ILogger<SettingController> _logger;
        private readonly ISettingsRepository _settingsRepository;
        public SettingController(ILogger<SettingController> logger
            , ISettingsRepository settingsRepository)
        {
            _logger = logger;
            _settingsRepository = settingsRepository;
        }

       
        [HttpGet("Settings")]
        public IActionResult Settings()
        {
            Dictionary<string, string> data =
                      new Dictionary<string, string>();
            try
            {
                var setting = _settingsRepository.GetAllData().FirstOrDefault();
                if(setting != null)
                {
                  
                    foreach (PropertyInfo propertyInfo in setting.GetType().GetProperties())
                    {
                        object value = propertyInfo.GetValue(setting, null);

                        if (value != null && !string.IsNullOrEmpty(value.ToString()))
                        {
                            if (value != null && !string.IsNullOrEmpty(value.ToString()))
                            {
                                if (propertyInfo.Name != "Id")
                                {
                                    data.Add(propertyInfo.Name, value.ToString());
                                }
                            }
                            
                        }

                    } 
                }

                return Ok(data);

            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                return BadRequest();
            }



        }
    }
}
