using System.Collections.Generic;

namespace ShortcutLib.Utils.Structs;

public readonly struct ColorPalette(
    Color top = default,
    Color middle = default,
    Color bottom = default,
    Color ammo = default,
    Dictionary<string, Color> freeSpace = null)
{
    public Color Top { get; } = top;
    public Color Middle { get; } = middle;
    public Color Bottom { get; } = bottom;
    
    public Color Ammo { get; } = ammo;
    public Dictionary<string, Color> FreeSpace { get; } = freeSpace;
}