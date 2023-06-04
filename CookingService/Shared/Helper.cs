using System.Reflection;
using CookingService.Domain;

namespace CookingService.Shared
{
    public static class Helper 
    {
        public static Dictionary<string, bool> ConvertObjectToDictionary(this Ingredients obj)
        {
            var dictionary = new Dictionary<string, bool>();

            if (obj != null)
            {
                PropertyInfo[] properties = obj.GetType().GetProperties();

                foreach (PropertyInfo property in properties)
                {
                    string propertyName = property.Name.ToLower();
                    var propertyValue = property.GetValue(obj, null);
                    dictionary[propertyName] = (bool)propertyValue;
                }
            }

            return dictionary;
        }
    }
}