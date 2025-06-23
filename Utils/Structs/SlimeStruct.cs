using System.Collections.Generic;

namespace ShortcutLib.Utils.Structs;

public readonly struct BasePlort(
    Identifiable.Id id,
    string name,
    Sprite icon,
    float baseValue,
    float fullSaturation,
    GameObject prefab,
    ColorPalette colorPalette,
    MonoBehaviour[] behaviours = null)
{
    public Identifiable.Id Id { get; } = id;

    public string Name { get; } = name;
    public Sprite Icon { get; } = icon;

    public float BaseValue { get; } = baseValue;
    public float FullSaturation { get; } = fullSaturation;
        
    public GameObject Prefab { get; } = prefab;
    public ColorPalette ColorPalette { get; } = colorPalette;
    
    public MonoBehaviour[] Behaviours { get; } = behaviours;
}

public readonly struct BaseSlime(
    Identifiable.Id id,
    string name,
    Sprite icon,
    SlimeDefinition definition,
    GameObject prefab,
    SlimeAppearance appearance,
    ColorPalette colorPalette,
    MonoBehaviour[] behaviours = null)
{
    public readonly struct Diet(
        SlimeEat.FoodGroup[] foodGroups,
        Identifiable.Id[] additionalFoods,
        Identifiable.Id[] favorites,
        Identifiable.Id[] produces,
        int favoriteProductionCount = 2)
    {
        public SlimeEat.FoodGroup[] FoodGroups { get; } = foodGroups;
        public Identifiable.Id[] AdditionalFoods { get; } = additionalFoods;
        public Identifiable.Id[] Favorites { get; } = favorites;
        public Identifiable.Id[] Produces { get; } = produces;

        public int FavoriteProductionCount { get; } = favoriteProductionCount;
    }
    //
    // public struct Structure(
    //     Mesh mesh,
    //     GameObject prefab,
    //     SlimeAppearanceObject appearanceObject,
    //     bool ignoreLODIndex = true,
    //     MonoBehaviour[] behaviours = null)
    // {
    //     public readonly Mesh mesh = mesh;
    //     public readonly GameObject prefab = prefab;
    //     public readonly SlimeAppearanceObject appearanceObject = appearanceObject;
    //     
    //     public readonly bool ignoreLODIndex = ignoreLODIndex;
    //
    //     public readonly MonoBehaviour[] behaviours = behaviours;
    // }
    
    public Identifiable.Id Id { get; } = id;

    public string Name { get; } = name;
    public Sprite Icon { get; } = icon;

    public SlimeDefinition Definition { get; } = definition;
    public GameObject Prefab { get; } = prefab;
    public SlimeAppearance Appearance { get; } = appearance;

    public ColorPalette ColorPalette { get; } = colorPalette;
    public MonoBehaviour[] Behaviours { get; } = behaviours ?? [];
}

public readonly struct BaseGordo(
    Identifiable.Id id,
    string name,
    Sprite icon,
    SlimeDefinition definition,
    GameObject prefab,
    List<GameObject> rewards,
    ZoneDirector.Zone[] zones,
    int feedCount = 30,
    string persistentId = null)
{
    public string Name { get; } = name;
    public Sprite Icon { get; } = icon;

    public Identifiable.Id Id { get; } = id;
    
    public SlimeDefinition Definition { get; } = definition;
    public GameObject Prefab { get; } = prefab;

    public List<GameObject> Rewards { get; } = rewards;
    
    public ZoneDirector.Zone[] Zones { get; } = zones;
    public int FeedCount { get; } = feedCount;
    
    public string PersistentId { get; } = persistentId.IsNullOrEmpty()
        ? "gordo" + name.Replace(" ", "").Replace("Gordo", "")
        : persistentId;
}
