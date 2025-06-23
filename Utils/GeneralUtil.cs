namespace ShortcutLib.Utils;

public static class GeneralUtil
{
    public static Color HexToColor(string hex)
    {
        if (!hex.StartsWith("#"))
            hex = "#" + hex;
        bool parsed = ColorUtility.TryParseHtmlString(hex, out var color);
        return parsed ? color : Color.black;
    }
}