using System;
using UnityEngine;

namespace ShortcutLib.Utils
{
    /// <summary>
    /// General utilities for <see cref="ShortcutLib"/>.
    /// </summary>
    public static class GenUtil
    {
        /// <summary>
        /// Parses a hex (HtmlString) code, then converts it to a usable <see cref="Color"/>.
        /// </summary>
        /// <param name="hex">A parsable hex. It does not need to start with #.</param>
        /// <returns><see cref="Color"/></returns>
        public static Color HexToColor(string hex)
        {
            var h = !hex.StartsWith("#") ? "#" + hex : hex;
            var parsed = ColorUtility.TryParseHtmlString(h, out var color);
            return parsed ? color : default;
        }

        /// <summary>
        /// Parses a <see cref="String"/> id, type of <see cref="T"/>, then converts it to a usable enum.
        /// </summary>
        /// <param name="id">The <see cref="string"/> id to be parsed.</param>
        /// <typeparam name="T">The type of the parsed enum.</typeparam>
        /// <returns><see cref="T"/></returns>
        public static T ParseEnum<T>(string id) => (T)Enum.Parse(typeof(T), id);
    }
}