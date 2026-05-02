using System;
using HarmonyLib;
using ShortcutLib.Utils;
using ShortcutLib.Utils.Classes;
using ShortcutLib.Utils.Extensions;
using SRML.SR;
using UnityEngine;
using Object = UnityEngine.Object;

namespace ShortcutLib.SR
{
    public static partial class SlimeCut
    {
        public static SlimeAppearance GetSlimeAppearance(this SlimeDefinition slimeDefinition, int index = 0,
            bool instantiate = false) => !instantiate
            ? slimeDefinition.AppearancesDefault[index]
            : slimeDefinition.AppearancesDefault[index].Instantiate();

        public static SlimeAppearance GetSlimeAppearance(this SlimeDefinition slimeDefinition, SlimeAppearance.AppearanceSaveSet saveSet,
            bool instantiate = false) => !instantiate
            ? slimeDefinition.GetAppearanceForSet(saveSet)
            : slimeDefinition.GetAppearanceForSet(saveSet).Instantiate();
        
        public static void CreateBasePlort(Identifiable.Id baseId, Identifiable.Id id, string name, Sprite icon,
            float baseValue, float fullSaturation, ColorPalette colorPalette, out BasePlort basePlort,
            Type[] behaviours = null)
        {
            // **** PREFAB **** \\
            
            var prefab = baseId.CopyPrefab();
            prefab.name = "plort" + name.Replace(" ", "").Replace("Plort", "");

            prefab.GetComponent<Identifiable>().id = id;

            if (behaviours != null)
                foreach (var behaviour in behaviours)
                    prefab.AddComponent(behaviour);

            // **** END **** \\
            
            Identifiable.PLORT_CLASS.Add(id);
            Identifiable.NON_SLIMES_CLASS.Add(id);

            TranslationPatcher.AddActorTranslation("l." + id.ToString().ToLower(), name);

            id.AddToAmmo();
            id.AddToSilo(SiloStorage.StorageType.PLORT);
            id.AddToDrone();
            id.RegisterVacDefinition(icon, colorPalette.Ammo, name.Replace(" ", ""));

            PediaRegistry.RegisterIdentifiableMapping(PediaDirector.Id.PLORTS, id);
            LookupRegistry.RegisterIdentifiablePrefab(prefab);

            if (!(baseValue == 0 || fullSaturation == 0))
            {
                PlortRegistry.AddPlortEntry(id);
                PlortRegistry.AddEconomyEntry(id, baseValue, fullSaturation);
            }

            basePlort = new BasePlort(id, name, icon, baseValue, fullSaturation, prefab, colorPalette, behaviours);
        }

        public static void CreateBaseSlime(Identifiable.Id baseId, Identifiable.Id id, string name, Sprite icon,
            BaseSlime.Diet diet, ColorPalette colorPalette, out BaseSlime baseSlime, Type[] behaviours = null)
        {
            // *** DEFINITION *** \\
            
            var slimeDefinition = ScriptableObject.CreateInstance<SlimeDefinition>();
            slimeDefinition.name = name.Replace("Slime", "").Replace(" ", "");
            slimeDefinition.Name = slimeDefinition.name;
            slimeDefinition.IdentifiableId = id;

            slimeDefinition.Sounds = AssetUtil.GetResource<SlimeSounds>("Standard");
            slimeDefinition.BaseModule = AssetUtil.GetResource<GameObject>("moduleSlimeStandard");
            slimeDefinition.BaseSlimes = Array.Empty<SlimeDefinition>();
            slimeDefinition.FavoriteToys = Array.Empty<Identifiable.Id>();
            slimeDefinition.SlimeModules = Array.Empty<GameObject>();

            // *** PREFAB *** \\
            
            var prefab = baseId.CopyPrefab();
            prefab.name = "slime" + name.Replace("Slime", "").Replace(" ", "");

            prefab.GetComponent<Identifiable>().id = id;
            prefab.GetComponent<SlimeEat>().slimeDefinition = slimeDefinition;
            prefab.GetComponent<PlayWithToys>().slimeDefinition = slimeDefinition;
            prefab.GetComponent<ReactToToyNearby>().slimeDefinition = slimeDefinition;
            prefab.GetComponent<SlimeVarietyModules>().baseModule = slimeDefinition.BaseModule;
            prefab.GetComponent<SlimeVarietyModules>().slimeModules = slimeDefinition.SlimeModules;
            
            if (behaviours != null)
                foreach (var behaviour in behaviours)
                    prefab.AddComponent(behaviour);

            Object.Destroy(prefab.GetComponent<PinkSlimeFoodTypeTracker>());

            // *** DIET *** \\
            
            slimeDefinition.Diet = new SlimeDiet
            {
                MajorFoodGroups = diet.FoodGroups,
                AdditionalFoods = diet.AdditionalFoods,
                Favorites = diet.Favorites,
                Produces = diet.Produces,
                FavoriteProductionCount = diet.FavoriteProductionCount
            };
            slimeDefinition.Diet.RefreshEatMap(SRSingleton<GameContext>.Instance.SlimeDefinitions, slimeDefinition);

            // *** APPEARANCE *** \\

            var slimeAppearance = slimeDefinition.GetSlimeAppearance(0, true);
            var slimeAppearanceApplicator = prefab.GetComponent<SlimeAppearanceApplicator>();
            slimeAppearance.name = name.Replace("Slime", "").Replace(" ", "") + "Normal";
            slimeAppearanceApplicator.Appearance = slimeAppearance;
            slimeAppearanceApplicator.SlimeDefinition = slimeDefinition;

            slimeAppearance.Face = Object.Instantiate(slimeAppearance.Face);
            slimeAppearance.Face.name = "faceSlime" + name.Replace("Slime", "").Replace(" ", "");

            var expressionFaces = Array.Empty<SlimeExpressionFace>();
            for (var i = 0; i < slimeAppearance.Face.ExpressionFaces.Length; i++)
            {
                var eyes = slimeAppearance.Face.ExpressionFaces[i].Eyes;
                var mouth = slimeAppearance.Face.ExpressionFaces[i].Mouth;

                if (eyes)
                    slimeAppearance.Face.ExpressionFaces[i].Eyes = Object.Instantiate(eyes);
                if (mouth)
                    slimeAppearance.Face.ExpressionFaces[i].Mouth = Object.Instantiate(mouth);

                expressionFaces = expressionFaces.AddToArray(slimeAppearance.Face.ExpressionFaces[i]);
            }

            slimeAppearance.Face.ExpressionFaces = expressionFaces;
            slimeAppearance.Face.OnEnable();

            slimeAppearance.Icon = icon;
            slimeAppearance.ColorPalette = new SlimeAppearance.Palette
            {
                Top = colorPalette.Top,
                Middle = colorPalette.Middle,
                Bottom = colorPalette.Bottom,
                Ammo = colorPalette.Ammo
            };
            slimeDefinition.AppearancesDefault = new[] { slimeAppearance };

            // *** END *** \\
            
            Identifiable.SLIME_CLASS.Add(id);
            TranslationPatcher.AddPediaTranslation(TranslationCut.CreateKey("l", id.ToLower()), name);
            TranslationPatcher.AddPediaTranslation(TranslationCut.CreateKey("t", id.ToLower()), name);

            id.AddToAmmo();
            id.RegisterVacDefinition(icon, colorPalette.Ammo, name.Replace(" ", ""));

            SlimeRegistry.RegisterSlimeDefinition(slimeDefinition);
            LookupRegistry.RegisterIdentifiablePrefab(prefab);

            SceneContext.Instance.SlimeAppearanceDirector.RegisterDependentAppearances(slimeDefinition,
                slimeDefinition.AppearancesDefault[0]);
            SceneContext.Instance.SlimeAppearanceDirector.UpdateChosenSlimeAppearance(slimeDefinition,
                slimeDefinition.AppearancesDefault[0]);

            baseSlime = new BaseSlime(id, name, icon, slimeDefinition, prefab, slimeAppearance, colorPalette,
                behaviours);
        }
    }
}