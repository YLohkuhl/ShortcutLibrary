using System.Collections.Generic;
using System.Linq;
using ShortcutLib.Utils.Extensions;
using UnityEngine;

namespace ShortcutLib.Utils
{
    public static class AssetUtil
    {
        private static readonly Dictionary<string, Object> ResourceCache = new();
        private static readonly Dictionary<string, GameObject> PrefabCache = new();

        /// <summary>
        /// Looks, and grabs a resource within the game. This can also grab instances, rather than just asset resources.
        /// </summary>
        /// <param name="name">The name of the resource to be searched for.</param>
        /// <typeparam name="T">The type of the resource to be searched for.</typeparam>
        /// <returns><see cref="T"/></returns>
        public static T GetResource<T>(string name) where T : Object
        {
            if (ResourceCache.ContainsKey(name))
                return (T)ResourceCache.FirstOrDefault(x => x.Key == name).Value;

            var res = Resources.FindObjectsOfTypeAll<T>().FirstOrDefault(x => x.name == name);
            ResourceCache.AddIfDoesNotContain(name, res);
            return res;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public static GameObject GetPrefabAsset(string name)
        {
            if (PrefabCache.ContainsKey(name))
                return PrefabCache.FirstOrDefault(x => x.Key == name).Value;

            var res = Resources.FindObjectsOfTypeAll<GameObject>()
                .FirstOrDefault(x => x.name == name && x.IsPrefabAsset());
            PrefabCache.AddIfDoesNotContain(name, res);
            return res;
        }

        // public static Sprite ToSprite(this Texture2D texture)
        // {
        //     Sprite sprite = Sprite.Create(texture, new Rect(0f, 0f, texture.width, texture.height), new Vector2(0.5f, 0.5f),
        //         1f);
        //     sprite.name = texture.name;
        //     return sprite;
        // }

        // public static Texture2D LoadLocalTexture(string filePath)
        // {
        //     byte[] byteArray = File.ReadAllBytes(filePath);
        //     Texture2D texture = new Texture2D(2, 2);
        //     texture.LoadImage(byteArray);
        //     return texture;
        // }
    }
}