using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;

namespace Common
{
    public static class ExtensionMethod
    {
        public static bool IsMatchRegex(this string value, string pattern)
        {
            Regex regex = new Regex(pattern);
            return (regex.IsMatch(value));
        }
        public static string IfNullElse(this string input, string nullAlternateValue)
        {
            return (!string.IsNullOrWhiteSpace(input)) ? input : nullAlternateValue;
        }
        public static string IfNull(this string input)
        {
            return (!string.IsNullOrWhiteSpace(input)) ? input : "";
        }
        public static bool IsValidEmailAddress(this string s)
        {
            Regex regex = new Regex(@"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$");
            return regex.IsMatch(s);
        }
        public static IEnumerable<T> Distinct<T, TKey>(this IEnumerable<T> @this, Func<T, TKey> keySelector)
        {
            return @this.GroupBy(keySelector).Select(grps => grps).Select(e => e.First());
        }
        public static bool IsNull(this object source)
        {
            return source == null;
        }
        public static string ToPlural(this string singular)
        {
            // Multiple words in the form A of B : Apply the plural to the first word only (A)
            int index = singular.LastIndexOf(" of ");
            if (index > 0) return (singular.Substring(0, index)) + singular.Remove(0, index).ToPlural();

            // single Word rules
            //sibilant ending rule
            if (singular.EndsWith("sh")) return singular + "es";
            if (singular.EndsWith("ch")) return singular + "es";
            if (singular.EndsWith("us")) return singular + "es";
            if (singular.EndsWith("ss")) return singular + "es";
            //-ies rule
            if (singular.EndsWith("y")) return singular.Remove(singular.Length - 1, 1) + "ies";
            // -oes rule
            if (singular.EndsWith("o")) return singular.Remove(singular.Length - 1, 1) + "oes";
            // -s suffix rule
            return singular + "s";
        }

        public static string KiloFormat(this int num)
        {
            if (num >= 1000000)
                return (num / 1000000D).ToString("0.#") + "M";

            if (num >= 10000)
                return (num / 1000D).ToString("#,0K");

            if (num >= 1000)
                return (num / 1000D).ToString("0.#") + "K";

            return num.ToString(CultureInfo.InvariantCulture);
        }
        public static int ToInt32(this string value)
        {
            int number;

            Int32.TryParse(value, out number);

            return number;
        }
        public static double ToDouble(this string value)
        {
            double number;

            Double.TryParse(value, out number);

            return number;
        }
        public static decimal ToDecimal(this string value)
        {
            decimal number;

            Decimal.TryParse(value, out number);

            return number;
        }
        public static bool ToBool(this string value)
        {
            bool number;

            Boolean.TryParse(value, out number);

            return number;
        }
        public static DateTime ToDateTime(this string value)
        {
            DateTime date;

            DateTime.TryParse(value, out date);

            return date;
        }

       
    }
    public static class EnumerableExtensions
    {
        private static Random random = new Random();

        public static T SelectRandom<T>(this IEnumerable<T> sequence)
        {
            if (sequence == null)
            {
                throw new ArgumentNullException();
            }

            if (!sequence.Any())
            {
                throw new ArgumentException("The sequence is empty.");
            }

            //optimization for ICollection<T>
            if (sequence is ICollection<T>)
            {
                ICollection<T> col = (ICollection<T>)sequence;
                return col.ElementAt(random.Next(col.Count));
            }

            int count = 1;
            T selected = default(T);

            foreach (T element in sequence)
            {
                if (random.Next(count++) == 0)
                {
                    //Select the current element with 1/count probability
                    selected = element;
                }
            }

            return selected;
        }
        public static string GetEnumDescription(Enum value)
        {
            FieldInfo fi = value.GetType().GetField(value.ToString());

            DescriptionAttribute[] attributes = fi.GetCustomAttributes(typeof(DescriptionAttribute), false) as DescriptionAttribute[];

            if (attributes != null && attributes.Any())
            {
                return attributes.First().Description;
            }

            return value.ToString();
        }

    }
    
}
