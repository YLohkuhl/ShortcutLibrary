using HarmonyLib;
using ShortcutLib.Utils;
using ShortcutLib.Utils.Extensions;
using ShortcutLib.Utils.Structs;
using SRML.SR;

namespace ShortcutLib.SR;

public static class SlimeCut
{
    public static BasePlort CreatePlortBase(Identifiable.Id baseId, Identifiable.Id id, string name, Sprite icon, float baseValue, float fullSaturation, ColorPalette colorPalette, MonoBehaviour[] behaviours = null)
    {
        // PREFAB
        GameObject prefab = baseId.CopyPrefab();
        prefab.name = "plort" + name.Replace(" ", "").Replace("Plort", "");

        prefab.GetComponent<Identifiable>().id = id;

        if (behaviours.IsNotNull())
            foreach (MonoBehaviour behaviour in behaviours)
                prefab.AddComponent(behaviour.GetType());
        
        // END
        Identifiable.PLORT_CLASS.Add(id);
        Identifiable.NON_SLIMES_CLASS.Add(id);
        TranslationPatcher.AddActorTranslation("l." + id.ToString().ToLower(), name);
        
        id.AddToAmmo();
        id.AddToSilo(SiloStorage.StorageType.PLORT);
        id.AddToDrone();
        id.RegisterVac(icon, colorPalette.Ammo, name.Replace(" ", ""));
        
        PediaRegistry.RegisterIdentifiableMapping(PediaDirector.Id.PLORTS, id);
        LookupRegistry.RegisterIdentifiablePrefab(prefab);
        
        PlortRegistry.AddPlortEntry(id);
        PlortRegistry.AddEconomyEntry(id, baseValue, fullSaturation);
        
        return new BasePlort(id, name, icon, baseValue, fullSaturation, prefab, colorPalette, behaviours);
    }
    
    public static BaseSlime CreateSlimeBase(Identifiable.Id baseId, Identifiable.Id id, string name, Sprite icon, BaseSlime.Diet diet, ColorPalette colorPalette, MonoBehaviour[] behaviours = null)
    {
        // DEFINITION
        SlimeDefinition slimeDefinition = ScriptableObject.CreateInstance<SlimeDefinition>();
        slimeDefinition.name = name.Replace("Slime", "").Replace(" ", "");
        slimeDefinition.Name = slimeDefinition.name;
        slimeDefinition.IdentifiableId = id;
        
        slimeDefinition.Sounds = AssetUtil.GetResource<SlimeSounds>("Standard");
        slimeDefinition.BaseModule = AssetUtil.GetResource<GameObject>("moduleSlimeStandard");
        slimeDefinition.BaseSlimes = [];
        slimeDefinition.FavoriteToys = [];
        slimeDefinition.SlimeModules = [];

        // PREFAB
        GameObject prefab = baseId.CopyPrefab();
        prefab.name = "slime" + name.Replace("Slime", "").Replace(" ", "");

        prefab.GetComponent<Identifiable>().id = id;
        prefab.GetComponent<SlimeEat>().slimeDefinition = slimeDefinition;
        prefab.GetComponent<PlayWithToys>().slimeDefinition = slimeDefinition;
        prefab.GetComponent<ReactToToyNearby>().slimeDefinition = slimeDefinition;
        prefab.GetComponent<SlimeVarietyModules>().baseModule = slimeDefinition.BaseModule;
        prefab.GetComponent<SlimeVarietyModules>().slimeModules = slimeDefinition.SlimeModules;
        
        if (behaviours.IsNotNull())
            foreach (MonoBehaviour behaviour in behaviours)
                prefab.AddComponent(behaviour.GetType());
        
        Object.Destroy(prefab.GetComponent<PinkSlimeFoodTypeTracker>());

        // DIET
        slimeDefinition.Diet = new SlimeDiet
        {
            MajorFoodGroups = diet.FoodGroups,
            AdditionalFoods = diet.AdditionalFoods,
            Favorites = diet.Favorites,
            Produces = diet.Produces,
            FavoriteProductionCount = diet.FavoriteProductionCount
        };
        slimeDefinition.Diet.RefreshEatMap(SRSingleton<GameContext>.Instance.SlimeDefinitions, slimeDefinition);

        // APPEARANCE
        SlimeAppearance slimeAppearance = baseId.GetSlimeDefinition().AppearancesDefault[0].Instantiate();
        SlimeAppearanceApplicator slimeAppearanceApplicator = prefab.GetComponent<SlimeAppearanceApplicator>();
        slimeAppearance.name = name.Replace("Slime", "").Replace(" ", "") + "Normal";
        slimeAppearanceApplicator.Appearance = slimeAppearance;
        slimeAppearanceApplicator.SlimeDefinition = slimeDefinition;

        slimeAppearance.Face = Object.Instantiate(slimeAppearance.Face);
        slimeAppearance.Face.name = "faceSlime" + name.Replace("Slime", "").Replace(" ", "");

        SlimeExpressionFace[] expressionFaces = [];
        for (int i = 0; i < slimeAppearance.Face.ExpressionFaces.Length; i++)
        {
            Material eyes = slimeAppearance.Face.ExpressionFaces[i].Eyes;
            Material mouth = slimeAppearance.Face.ExpressionFaces[i].Mouth;

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
        slimeDefinition.AppearancesDefault = [slimeAppearance];

        // END
        Identifiable.SLIME_CLASS.Add(id);
        TranslationPatcher.AddPediaTranslation("t." + id.ToString().ToLower(), name);
        
        id.AddToAmmo();
        id.RegisterVac(icon, colorPalette.Ammo, name.Replace(" ", ""));
        
        SlimeRegistry.RegisterSlimeDefinition(slimeDefinition);
        LookupRegistry.RegisterIdentifiablePrefab(prefab);
        
        SceneContext.Instance.SlimeAppearanceDirector.RegisterDependentAppearances(slimeDefinition, slimeDefinition.AppearancesDefault[0]);
        SceneContext.Instance.SlimeAppearanceDirector.UpdateChosenSlimeAppearance(slimeDefinition, slimeDefinition.AppearancesDefault[0]);
        
        return new BaseSlime(id, name, icon, slimeDefinition, prefab, slimeAppearance, colorPalette, behaviours);
    }
}