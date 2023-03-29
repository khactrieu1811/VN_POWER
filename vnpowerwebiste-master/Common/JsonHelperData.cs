using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;

namespace Common
{
    public class JsonHelperData
    {
        public static T DeserializeObject<T>(string jsonString)
        {
            try
            {
                return JsonSerializer.Deserialize<T>(jsonString);
            }
            catch
            {
                return default(T);
            }

        }


        public static object DeserializeObject(string jsonString)
        {
            try
            {
                return JsonSerializer.Deserialize<object>(jsonString);
            }
            catch
            {
                return default(object);
            }

        }

        public static string SerializeObject(object obj)
        {
            try
            {
                return JsonSerializer.Serialize(obj);
            }
            catch (Exception ex)
            {
                return string.Empty;
            }
        }
    }
}
