using MonomiPark.SlimeRancher.Regions;
using UnityEngine;

namespace ShortcutLib.Utils.Extensions
{
    public static class GameObjectExtensions
    {
        /// <summary>
        /// Sets a layer mask for a <see cref="GameObject"/>.
        /// </summary>
        /// <param name="gameObject"><see cref="GameObject"/> to set the layer mask for.</param>
        /// <param name="layer">The index of the layer.</param>
        public static void SetLayerMask(this GameObject gameObject, int layer) => gameObject.layer = layer;

        /// <summary>
        /// Sets a layer mask for a <see cref="GameObject"/>.
        /// </summary>
        /// <param name="gameObject"><see cref="GameObject"/> to set the layer mask for.</param>
        /// <param name="layerName">The name of the layer.</param>
        public static void SetLayerMask(this GameObject gameObject, string layerName) =>
            gameObject.layer = LayerMask.NameToLayer(layerName);

        /// <summary>
        /// Creates a delaunch trigger, and parents it to the specified <see cref="GameObject"/>.
        /// Delaunch triggers allow an object to go through corrals.
        /// </summary>
        /// <param name="gameObject"><see cref="GameObject"/> to add the delaunch trigger to.</param>
        /// <returns><see cref="GameObject"/></returns>
        public static GameObject AddDelaunchTrigger(this GameObject gameObject) =>
            Object.Instantiate(AssetUtil.GetResource<GameObject>("DelaunchTrigger"), gameObject.transform);

        /// <summary>
        /// Adds the basic components for creating an <see cref="Identifiable"/> object.
        /// </summary>
        /// <param name="obj"><see cref="GameObject"/> to add the base components to. Ideally a Prefab.</param>
        /// <param name="id">The <see cref="Identifiable.Id"/> attached to the <see cref="Identifiable"/>.</param>
        /// <param name="size">The <see cref="Vacuumable.Size"/> set for the <see cref="Vacuumable"/> behaviour.</param>
        public static void AddIdentifiableBase(this GameObject obj, Identifiable.Id id, Vacuumable.Size size)
        {
            obj.AddComponent<Rigidbody>();
            obj.AddComponent<RegionMember>();
            obj.AddComponent<Identifiable>().id = id;
            obj.AddComponent<Vacuumable>().size = size;
        }
    }
}