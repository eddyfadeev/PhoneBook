using System.ComponentModel;

namespace PhoneBook.Extensions;

internal static class EnumTypeExtensions
{
    public static string GetEnumDescription<TEnum>() where TEnum : Enum
    {
        Type enumType = typeof(TEnum);
        DescriptionAttribute? attribute = enumType.GetCustomAttribute<DescriptionAttribute>();

        return attribute is null ? enumType.Name : attribute.Description;
    }
}