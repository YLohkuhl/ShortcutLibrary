using System.Collections.Generic;
using SRML.SR;

namespace ShortcutLib.Utils.Extensions
{
    public static class FoodGroupExtensions
    {
        internal static readonly Dictionary<SlimeEat.FoodGroup, string> PatchedTranslations = new();

        /// <summary>
        /// Adds a patched translation for a desired <see cref="SlimeEat.FoodGroup"/>.
        /// </summary>
        /// <param name="foodGroup">The <see cref="SlimeEat.FoodGroup"/> attached to the UI translation.</param>
        /// <param name="key">The key for the UI translation.</param>
        public static void AddPatchedTranslation(this SlimeEat.FoodGroup foodGroup, string key) =>
            PatchedTranslations[foodGroup] = key;

        /// <summary>
        /// Adds a patched translation for a desired <see cref="SlimeEat.FoodGroup"/>.
        /// </summary>
        /// <param name="foodGroup">The <see cref="SlimeEat.FoodGroup"/> attached to the UI translation.</param>
        /// <param name="key">The key for the UI translation.</param>
        /// <param name="value">The translation value for the UI translation.</param>
        public static void AddPatchedTranslation(this SlimeEat.FoodGroup foodGroup, string key, string value)
        {
            PatchedTranslations[foodGroup] = key;
            TranslationPatcher.AddUITranslation(key, value);
        }
    }
}