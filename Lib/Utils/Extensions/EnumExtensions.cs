using System;

namespace ShortcutLib.Utils.Extensions
{
    public static class EnumExtensions
    {
        public static string ToLower<T>(this T value) where T : Enum => value.ToString().ToLower();

        public static string Underscore<T>(this T value) where T : Enum => value.ToString().Replace(" ", "_");
    }
}