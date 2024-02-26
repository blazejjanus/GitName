using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace GitName.Utils {
    internal static class EnumExtensions {
        public static TAttribute GetAttribute<TAttribute>(this Enum enumValue)
            where TAttribute : Attribute {
            return enumValue.GetType().GetMember(enumValue.ToString()).First().GetCustomAttribute<TAttribute>() 
                ?? throw new Exception($"Cannot get {typeof(TAttribute).Name} from {enumValue.GetType().Name}");
        }

        public static string GetName(this Enum enumValue) {
            var attr = enumValue.GetAttribute<DisplayAttribute>();
            return attr.Name ?? throw new Exception("Cannot get enum name!");
        }
    }
}
