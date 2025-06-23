using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace ShortcutLib.Utils;

public static class AssetUtil
{
    private static readonly Dictionary<string, UnityEngine.Object> resourceCache = new();

    public static T GetResource<T>(string name) where T : UnityEngine.Object
    {
        if (resourceCache.ContainsKey(name))
            return (T)resourceCache.FirstOrDefault(x => x.Key == name).Value;
        
        var res = Resources.FindObjectsOfTypeAll<T>().FirstOrDefault(x => x.name == name);
        resourceCache.AddIfDoesNotContain(name, res);
        return res;
    }

    public static AssetBundle LoadBundle(string path) => AssetBundle.LoadFromFile(path);

    public static Sprite ToSprite(this Texture2D texture)
    {
        Sprite sprite = Sprite.Create(texture, new Rect(0f, 0f, texture.width, texture.height), new Vector2(0.5f, 0.5f),
            1f);
        sprite.name = texture.name;
        return sprite;
    }

    public static Texture2D LoadLocalTexture(string filePath)
    {
        byte[] byteArray = File.ReadAllBytes(filePath);
        Texture2D texture = new Texture2D(2, 2);
        texture.LoadImage(byteArray);
        return texture;
    }
}