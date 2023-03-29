using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Website.Services
{
    public class CaptchaVerificationService
    {
        private CaptchaSettings captchaSettings;
        private ILogger<CaptchaVerificationService> logger;

        public string ClientKey => captchaSettings.ClientKey;

        public CaptchaVerificationService(IOptions<CaptchaSettings> captchaSettings, ILogger<CaptchaVerificationService> logger)
        {
            this.captchaSettings = captchaSettings.Value;
            this.logger = logger;
        }

        public async Task<bool> IsCaptchaValid(string token)
        {
            var result = false;

            var googleVerificationUrl = "https://www.google.com/recaptcha/api/siteverify";

            try
            {
                using var client = new HttpClient();

                var response = await client.PostAsync($"{googleVerificationUrl}?secret={captchaSettings.ServerKey}&response={token}", null);
                var jsonString = await response.Content.ReadAsStringAsync();
                var captchaVerfication = JsonConvert.DeserializeObject<CaptchaVerificationResponse>(jsonString);

                result = captchaVerfication.Success;
            }
            catch (Exception e)
            {
                // fail gracefully, but log
                logger.LogError("Failed to process captcha validation", e);
            }

            return result;
        }
    }

    public class CaptchaSettings
    {
        public string ClientKey { get; set; }
        public string ServerKey { get; set; }
    }

    public class ReCaptchaRequest
    {
        [JsonProperty("secret")]
        public string Secret { get; set; }

        [JsonProperty("response ")]
        public string Response { get; set; }

        [JsonProperty("remoteip")]
        public string RemoteIp { get; set; }
    }

    public class CaptchaVerificationResponse
    {
        [JsonProperty("success")]
        public bool Success { get; set; }

        [JsonProperty("challenge_ts")]
        public DateTime ChallengeTimeStamp { get; set; }

        [JsonProperty("hostname")]
        public string Hostname { get; set; }

        [JsonProperty("error-codes")]
        public List<string> ErrorCodes { get; set; }
    }
}
