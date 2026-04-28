using UnityEngine;

namespace ShortcutLib.Utils.Extensions
{
    public static class TextureExtensions
    {
        /// <summary>
        /// Converts a <see cref="Texture2D"/> to a <see cref="Sprite"/>.
        /// </summary>
        /// <param name="texture"><see cref="Texture2D"/> to convert.</param>
        /// <returns><see cref="Sprite"/></returns>
        public static Sprite ToSprite(this Texture2D texture)
        {
            var sprite = Sprite.Create(texture, new Rect(0f, 0f, texture.width, texture.height),
                new Vector2(0.5f, 0.5f),
                1f);
            sprite.name = texture.name;
            return sprite;
        }
    }
}