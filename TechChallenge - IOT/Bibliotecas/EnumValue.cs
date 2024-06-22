﻿using System.ComponentModel;
using System.Reflection;

namespace TC_IOC.Bibliotecas
{
    public class EnumValue
    {
        public string? Value { get; set; }
        public string? Description {  get; set; }
    }

   public static class EnumExtension
    {
        public static EnumValue GetValue(this Enum value)
        {
            EnumValue enumval = new()
            {
                Value = value.ToString(),
                Description = value.GetDescription()
            };

            return enumval;
        }

        public static string GetDescription(this Enum value)
        {
            FieldInfo? field = value.GetType().GetField(value.ToString()) ?? throw new Exception("Enumerator sem decorator");
            DescriptionAttribute[] array = (DescriptionAttribute[]) field.GetCustomAttributes(typeof(DescriptionAttribute), false);
            if(array.Length == 0)
            {
                return value.ToString();
            }
            return array[0].Description;
        }
    }
}