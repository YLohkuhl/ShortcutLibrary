using SRML.Utils;

namespace ShortcutLib.Utils.Extensions;

public static class PrefabExtensions
{
    public static GameObject CopyPrefab(this Identifiable.Id identifiable) => PrefabUtils.CopyPrefab(identifiable.GetPrefab());
}