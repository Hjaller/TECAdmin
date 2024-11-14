using System.ComponentModel;


namespace TECAdmin
{
    public class Utils
    {
        public static string GetEnumDescription(SearchCriteria value)
        {
            var fieldInfo = value.GetType().GetField(value.ToString());
            var attribute = (DescriptionAttribute)Attribute.GetCustomAttribute(fieldInfo, typeof(DescriptionAttribute));
            return attribute?.Description ?? value.ToString();
        }
    }
}
