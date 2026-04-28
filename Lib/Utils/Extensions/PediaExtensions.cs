using SRML.SR;
using UnityEngine;

namespace ShortcutLib.Utils.Extensions
{
    public static class PediaExtensions
    {
        public static void CreateEntry(this PediaDirector.Id pedia, Sprite icon) =>
            PediaRegistry.RegisterIdEntry(pedia, icon);

        public static void LinkEntry(this PediaDirector.Id pedia, Identifiable.Id id) =>
            PediaRegistry.RegisterIdentifiableMapping(pedia, id);
    }
}