using System.Collections.Generic;
using System.Linq;
using HarmonyLib;
using ShortcutLib.Utils.Extensions;

namespace ShortcutLib.Harmony
{
    [HarmonyPatch(typeof(SlimeDiet), nameof(SlimeDiet.GetFoodCategoryMsg))]
    internal static class PatchSlimeDietGetFoodCategoryMsg
    {
        // private static readonly List<SlimeEat.FoodGroup> IgnoredGroups = new()
        // {
        //     SlimeEat.FoodGroup.NONTARRGOLD_SLIMES, SlimeEat.FoodGroup.MEAT, SlimeEat.FoodGroup.FRUIT,
        //     SlimeEat.FoodGroup.GINGER, SlimeEat.FoodGroup.PLORTS, SlimeEat.FoodGroup.VEGGIES
        // };

        // ReSharper disable once InconsistentNaming
        public static bool Prefix(Identifiable.Id id, ref string __result)
        {
            var pair = FoodGroupExtensions.PatchedTranslations.ToList().Find(x =>
                SlimeEat.GetFoodGroupIds(x.Key).Contains(id));
            if (pair.Value.IsNullOrEmpty()) return true;
            __result = pair.Value;
            return false;
        }
    }
}