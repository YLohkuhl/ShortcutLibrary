using System.Collections.Generic;
using UnityEngine;

namespace ShortcutLib.Utils.Classes
{
    /// <summary>
    /// A basic <see cref="ColorPalette"/>.
    /// You can utilize it to store, and organize colors easily. Extensions and/or methods may also make use of it.
    /// </summary>
    public class ColorPalette
    {
        /// <param name="top">The <c>_TopColor</c> property of a material, it has a common usage.</param>
        /// <param name="middle">The <c>_MiddleColor</c> property of a material, it has a common usage.</param>
        /// <param name="bottom">The <c>_BottomColor</c> property of a material, it has a common usage.</param>
        /// <param name="ammo">The color of the ammo slot for an <see cref="Identifiable"/> inside the VacPack.</param>
        /// <param name="freeSpace">Optional <see cref="Dictionary{TKey,TValue}"/> of additional colors, findable by key.</param>
        /// <returns><see cref="ColorPalette"/></returns>
        public ColorPalette(
            Color top = default,
            Color middle = default,
            Color bottom = default,
            Color ammo = default,
            Dictionary<string, Color> freeSpace = null)
        {
            Top = top;
            Middle = middle;
            Bottom = bottom;
            Ammo = ammo;
            FreeSpace = freeSpace;
        }

        public Color Top { get; }
        public Color Middle { get; }
        public Color Bottom { get; }

        public Color Ammo { get; }

        private Dictionary<string, Color> FreeSpace { get; }

        /// <summary>
        /// Gets a color from <c>FreeSpace</c> by key.
        /// </summary>
        /// <param name="name">The key that is attached to the requested <see cref="Color"/>.</param>
        /// <returns><see cref="Color"/></returns>
        public Color GetColor(string name) => FreeSpace.GetValueOrDefault(name);

        /// <summary>
        /// Adds a color to <c>FreeSpace</c> with a findable key.
        /// </summary>
        /// <param name="name">The key to be attached to the added <see cref="Color"/>.</param>
        /// <param name="color">The <see cref="Color"/> to be added under the key.</param>
        public void AddColor(string name, Color color) => FreeSpace.AddIfDoesNotContain(name, color);
    }
}