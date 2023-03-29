using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Entities
{
    public partial class Settings
    {
        public Guid Id { get; set; }
        public string PageImageUrl { get; set; }
        public string PageDescription { get; set; }
        public string PageTitle { get; set; }
        public string MetaDesc { get; set; }
        public string FacebookLink { get; set; }
        public string LinkedInLink { get; set; }
        public string YoutubeLink { get; set; }
        public string InstagramLink { get; set; }
        public string FacebookScript { get; set; }
        public string GoogleScript { get; set; }
        public string TermsAndConditions { get; set; }
        public string DefaultLanguage { get; set; }
        public string CompanyInfo { get; set; }
        public string Logo { get; set; }
    }
}
