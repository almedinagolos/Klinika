using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace Klinika.Helper
{
    public static class EnumHelper
    {
        public static string GetDisplayValue(Enum value)
        {
            var fieldInfo = value.GetType().GetField(value.ToString());
            var displayAttribute = fieldInfo.GetCustomAttribute<DisplayAttribute>(false);
            return displayAttribute?.Name ?? value.ToString();
        }
    }
}
