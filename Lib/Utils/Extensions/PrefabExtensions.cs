using SRML.Utils;
using UnityEngine;

namespace ShortcutLib.Utils.Extensions
{
    /// <summary>
    /// Prefab-oriented extensions for <see cref="ShortcutLib"/>.
    /// </summary>
    public static class PrefabExtensions
    {
        /// <summary>
        /// Validates if a prefab is an asset resource, and not an instance by looking at its loaded scene.
        /// </summary>
        /// <param name="obj">The <see cref="GameObject"/> to check for.</param>
        /// <returns></returns>
        public static bool IsPrefabAsset(this GameObject obj) =>
            obj != null && !obj.scene.IsValid() && !obj.scene.isLoaded;

        /// <summary>
        /// Creates an identical copy of a prefab.
        /// </summary>
        /// <param name="identifiable">The <see cref="Identifiable.Id"/> prefab to be copied.</param>
        /// <returns><see cref="GameObject"/></returns>
        public static GameObject CopyPrefab(this Identifiable.Id identifiable) =>
            PrefabUtils.CopyPrefab(identifiable.GetPrefab());

        /// <summary>
        /// Creates an identical copy of a prefab.
        /// </summary>
        /// <param name="gameObject">The <see cref="GameObject"/> prefab to be copied.</param>
        /// <returns><see cref="GameObject"/></returns>
        public static GameObject CopyPrefab(this GameObject gameObject) => PrefabUtils.CopyPrefab(gameObject);
    }
}