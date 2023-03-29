using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;

namespace Common
{
    public static class StringUtils
    {
        public static string StripHtmlFromString(string input)
        {
            if (!string.IsNullOrEmpty(input))
            {
                input = Regex.Replace(input, @"</?\w+((\s+\w+(\s*=\s*(?:"".*?""|'.*?'|[^'"">\s]+))?)+\s*|\s*)/?>", string.Empty, RegexOptions.Singleline);
                input = Regex.Replace(input, @"\[[^]]+\]", "");
            }
            return input;
        }
        public static string GetSafeHtml(string html, bool useXssSantiser = false)
        {
            // Scrub html
            //html = ScrubHtml(html, useXssSantiser);

            // remove unwanted html
            //html = RemoveUnwantedTags(html);

            return html;
        }

        public static string SafePlainText(string input)
        {
            if (!string.IsNullOrEmpty(input))
            {
                input = StripHtmlFromString(input);
                input = GetSafeHtml(input, true);
            }
            return input;
        }

        public static string GenerateSaltedHash(string plainText, string salt)
        {
            // http://stackoverflow.com/questions/2138429/hash-and-salt-passwords-in-c-sharp

            var plainTextBytes = Encoding.UTF8.GetBytes(plainText);
            var saltBytes = Encoding.UTF8.GetBytes(salt);

            // Combine the two lists
            var plainTextWithSaltBytes = new List<byte>(plainTextBytes.Length + saltBytes.Length);
            plainTextWithSaltBytes.AddRange(plainTextBytes);
            plainTextWithSaltBytes.AddRange(saltBytes);

            // Produce 256-bit hashed value i.e. 32 bytes
            HashAlgorithm algorithm = new SHA256Managed();
            var byteHash = algorithm.ComputeHash(plainTextWithSaltBytes.ToArray());
            return Convert.ToBase64String(byteHash);
        }

        public static string CreateSalt(int size)
        {
            // Generate a cryptographic random number.
            var rng = new RNGCryptoServiceProvider();
            var buff = new byte[size];
            rng.GetBytes(buff);

            // Return a Base64 string representation of the random number.
            return Convert.ToBase64String(buff);
        }

        public static string RemoveAccents(string input)
        {
            // Replace accented characters for the closest ones:
            //var from = "ÂÃÄÀÁÅÇÈÉÊËÌÍÎÏÐÑÒÓÔÕÖØÙÚÛÜÝàáâãäåçèéêëìíîïðñòóôõöøùúûüýÿ".ToCharArray();
            //var to = "AAAAAACEEEEIIIIDNOOOOOOUUUUYaaaaaaceeeeiiiidnoooooouuuuyy".ToCharArray();
            //for (var i = 0; i < from.Length; i++)
            //{
            //    input = input.Replace(from[i], to[i]);
            //}

            //// Thorn http://en.wikipedia.org/wiki/%C3%9E
            //input = input.Replace("Þ", "TH");
            //input = input.Replace("þ", "th");

            //// Eszett http://en.wikipedia.org/wiki/%C3%9F
            //input = input.Replace("ß", "ss");

            //// AE http://en.wikipedia.org/wiki/%C3%86
            //input = input.Replace("Æ", "AE");
            //input = input.Replace("æ", "ae");

            //return input;


            var stFormD = input.Normalize(NormalizationForm.FormD);
            var sb = new StringBuilder();

            foreach (var t in stFormD)
            {
                var uc = CharUnicodeInfo.GetUnicodeCategory(t);
                if (uc != UnicodeCategory.NonSpacingMark)
                {
                    sb.Append(t);
                }
            }

            return (sb.ToString().Normalize(NormalizationForm.FormC));

        }

        public static string StripNonAlphaNumeric(string strInput, string replaceWith)
        {
            strInput = Regex.Replace(strInput, "[^\\w]", replaceWith);
            strInput = strInput.Replace(string.Concat(replaceWith, replaceWith, replaceWith), replaceWith)
                                .Replace(string.Concat(replaceWith, replaceWith), replaceWith)
                                .TrimStart(Convert.ToChar(replaceWith))
                                .TrimEnd(Convert.ToChar(replaceWith));
            return strInput;
        }

        public static string CreateUrl(string strInput, string replaceWith)
        {
            // Doing this to stop the urls having amp from &amp;
            strInput = HttpUtility.HtmlDecode(strInput);
            // Doing this to stop the urls getting encoded
            var url = RemoveAccents(strInput);
            return StripNonAlphaNumeric(url, replaceWith).ToLower();
        }
        public static DateTime GetFirstDayOfMonth(int iMonth)
        {
            DateTime dtResult = new DateTime(DateTime.Now.Year, iMonth, 1);
            dtResult = dtResult.AddDays((-dtResult.Day) + 1);
            return dtResult;
        }
        //public static string SetValueNull(Guid Id = new Guid(), string UserName = "", string FullName = "", string phone = "", string Email = "", string Avatar = "", string Token = "", string KeyCodeActive = "", int expires_in = 0, string expires_date = "")
        //{
        //    if (string.IsNullOrEmpty(UserName))
        //    {
        //        return "";
        //    }
        //    else
        //    {
        //        if (string.IsNullOrEmpty(FullName))
        //        {
        //            return "";
        //        }
        //        else
        //        {
        //            if (string.IsNullOrEmpty(phone))
        //            {
        //                return "";
        //            }
        //            else
        //            {
        //                return phone;
        //            }

        //        }

        //    }
        //}

        //private static string IsNullOrEmpty(object value)
        //{
        //    if (Object.ReferenceEquals(value, null))
        //        return "";

        //    var type = value.ToString();
        //    if (p.PropertyType == typeof(string))
        //    {
        //        return string.IsNullOrEmpty((string)value);
        //    }
        //}

        public class StringUtil

        {

            private static readonly string[] VietnameseSigns = new string[]

            {

            "aAeEoOuUiIdDyY",

            "áàạảãâấầậẩẫăắằặẳẵ",

            "ÁÀẠẢÃÂẤẦẬẨẪĂẮẰẶẲẴ",

            "éèẹẻẽêếềệểễ",

            "ÉÈẸẺẼÊẾỀỆỂỄ",

            "óòọỏõôốồộổỗơớờợởỡ",

            "ÓÒỌỎÕÔỐỒỘỔỖƠỚỜỢỞỠ",

            "úùụủũưứừựửữ",

            "ÚÙỤỦŨƯỨỪỰỬỮ",

            "íìịỉĩ",

            "ÍÌỊỈĨ",

            "đ",

            "Đ",

            "ýỳỵỷỹ",

            "ÝỲỴỶỸ"

            };

            public static string RemoveSign4VietnameseString(string str)
            {
                str = str.Trim();
                str = RemoveSpaces(str);
                //Tiến hành thay thế , lọc bỏ dấu cho chuỗi

                for (int i = 1; i < VietnameseSigns.Length; i++)

                {

                    for (int j = 0; j < VietnameseSigns[i].Length; j++)

                        str = str.Replace(VietnameseSigns[i][j], VietnameseSigns[0][i - 1]);

                }

                return str;

            }


        }

        public static string SetValueNull(string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                return "";
            }
            return value;
        }

        public static double Null(double value)
        {
            if (double.IsNaN(value))
            {
                return 0;
            }

            return value;
        }

        public static string CreateUrlSlug(string name)
        {
            var slug = name.Replace("đ", "d");
            return CreateUrl(slug, "-");
        }
        public static string ConvertMoney(decimal value)
        {
            if (value != 0)
            {
                return value.ToString("#,###", CultureInfo.GetCultureInfo("vi-VN").NumberFormat) + " VNĐ";
            }
            return "0 VNĐ";
        }
        public static double GetMinute(int milisecond)
        {
            return Math.Round(((double)milisecond / 60), 1);
        }
        public static string GetMinuteString(int value)
        {
            var timespan = TimeSpan.FromSeconds(value);
            var hour = (int)timespan.Hours;
            var min = (int)timespan.Minutes;
            var second = timespan.Seconds;
            return string.Format("{0}:{1}:{2}",
                  hour > 10 ? hour.ToString() : "0" + hour.ToString(),
            min > 10 ? min.ToString() : "0" + min.ToString(), // <== Note the casting to int.
             second > 10 ? second.ToString() : "0" + second.ToString());
        }
        public static string MinuteString(int value)
        {
            var timespan = TimeSpan.FromSeconds(value);
            var hour = (int)timespan.Hours;
            var min = (int)timespan.Minutes;
            var second = timespan.Seconds;
            if (hour > 0)
            {
                return string.Format("{0} giờ {1} phút {2} giây",
                 hour > 10 ? hour.ToString() : "0" + hour.ToString(),
                 min > 10 ? min.ToString() : "0" + min.ToString(), // <== Note the casting to int.
                 second > 10 ? second.ToString() : "0" + second.ToString());
            }
            if (min > 0)
                return string.Format("{0} phút {1} giây",
            min > 10 ? min.ToString() : "0" + min.ToString(), // <== Note the casting to int.
             second > 10 ? second.ToString() : "0" + second.ToString());
            if (second > 0)
                return string.Format("{0} giây",
             second > 10 ? second.ToString() : "0" + second.ToString());
            return "";
        }
        public static string HtmlToPlainText(string html)
        {
            const string htmlString = @"<(.|\n)*?>";
            const string tagWhiteSpace = @"(>|$)(\W|\n|\r)+<";//matches one or more (white space or line breaks) between '>' and '<'
            const string stripFormatting = @"<[^>]*(>|$)";//match any character between '<' and '>', even when end tag is missing
            const string lineBreak = @"<(br|BR)\s{0,1}\/{0,1}>";//matches: <br>,<br/>,<br />,<BR>,<BR/>,<BR />
            var lineBreakRegex = new Regex(lineBreak, RegexOptions.Multiline);
            var stripFormattingRegex = new Regex(stripFormatting, RegexOptions.Multiline);
            var tagWhiteSpaceRegex = new Regex(tagWhiteSpace, RegexOptions.Multiline);
            var htmlStringRegex = new Regex(htmlString, RegexOptions.Multiline);
            var text = html;
            //Decode html specific characters
            text = System.Net.WebUtility.HtmlDecode(text);
            //Remove tag whitespace/line breaks
            text = tagWhiteSpaceRegex.Replace(text, "><");
            //Replace <br /> with line breaks
            text = lineBreakRegex.Replace(text, Environment.NewLine);
            //Strip formatting
            text = stripFormattingRegex.Replace(text, string.Empty);
            text = htmlStringRegex.Replace(text, string.Empty);
            text = text.Replace("\n", string.Empty);
            return text;
        }

        public static string GetImageByPoints(int point)
        {
            string url = string.Empty;
            if (point < 210)
            {
                url = "ImagesUpload/image-levels/pwrnet-level-egg.png";
            }
            else if (point >= 210 && point < 14700)
            {
                url = "ImagesUpload/image-levels/pwrnet-level-baby.png";
            }
            else if (point >= 14700 && point < 44100)
            {
                url = "ImagesUpload/image-levels/pwrnet-level-learn-to-fly.png";
            }
            else if (point >= 44100 && point < 88200)
            {
                url = "ImagesUpload/image-levels/pwrnet-level-adult.png";
            }
            else
            {
                url = "ImagesUpload/image-levels/pwrnet-level-leader.png";
            }
            return url;

        }
        public static string RemoveSpaces(string value)
        {
            return Regex.Replace(value, @"\s+", " ");
        }

        public static string GetEnumDescription(this Enum value)
        {
            System.Reflection.FieldInfo fi = value.GetType().GetField(value.ToString());

            DescriptionAttribute[] attributes = (DescriptionAttribute[])fi.GetCustomAttributes(typeof(DescriptionAttribute), false);

            if (attributes != null && attributes.Length > 0)
                return attributes[0].Description;
            else
                return value.ToString();
        }
    }
}
