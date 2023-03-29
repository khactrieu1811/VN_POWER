using Entities.Entities;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public class SettingModel : Settings
    {
        public IFormFile FileLogo { get; set; }
        public string CompanyInfo { get; set; }
        public string Logo { get; set; }
        public SettingModel()
        {

        }
        public SettingModel(Settings entity)
        {
            Id = entity.Id;
            CompanyInfo = entity.CompanyInfo;
            Logo = entity.Logo;
        }
    }

}
