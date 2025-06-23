using ShortcutLib.Utils.Structs;

namespace ShortcutLib.Utils.Extensions;

public static class MaterialExtensions
{
    private static readonly int topColor = Shader.PropertyToID("_TopColor");
    private static readonly int middleColor = Shader.PropertyToID("_MiddleColor");
    private static readonly int bottomColor = Shader.PropertyToID("_BottomColor");

    public static void SetTopMidBot(this Material material, ColorPalette colorPalette) =>
        SetTopMidBot(material, colorPalette.Top, colorPalette.Middle, colorPalette.Bottom);
    
    public static void SetTopMidBot(this Material material, Color top, Color middle, Color bottom)
    {
        material.SetColor(topColor, top);
        material.SetColor(middleColor, middle);
        material.SetColor(bottomColor, bottom);
    }
}