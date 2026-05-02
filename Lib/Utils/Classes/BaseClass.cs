using System;
using System.Collections.Generic;
using ShortcutLib.SR;
using UnityEngine;

namespace ShortcutLib.Utils.Classes
{
    /// <summary>
    /// Represents a plort instance created through <see cref="ShortcutLib"/>.
    /// Typically produced by calling <see cref="SlimeCut.CreateBasePlort"/>.
    /// </summary>
    public class BasePlort
    {
        /// <param name="id">A unique enum identifier for an <see cref="Identifiable"/>, typically typed as <see cref="Identifiable.Id"/>.</param>
        /// <param name="name">The full name of the plort, this is automatically translated in-game.</param>
        /// <param name="icon">A <see cref="Sprite"/> icon to visually represent the plort with in-game UI.</param>
        /// <param name="baseValue">The overall base value of the plort, this doesn't change.</param>
        /// <param name="fullSaturation">The full saturation of the plort, this does control how drastically your plort value changes in the market.</param>
        /// <param name="prefab">The <see cref="GameObject"/> prefab of the -plort, automatically created along with the built-in method(s) for producing <see cref="BasePlort"/>.</param>
        /// <param name="colorPalette">A basic <see cref="ColorPalette"/> for the plort, considered to be utility for having easy access to the colors.</param>
        /// <param name="behaviours">Optional <see cref="MonoBehaviour"/> types to iterate through, and automatically add for custom-made behaviours.</param>
        /// <returns><see cref="BasePlort"/></returns>
        public BasePlort(
            Identifiable.Id id,
            string name,
            Sprite icon,
            float baseValue,
            float fullSaturation,
            GameObject prefab,
            ColorPalette colorPalette,
            Type[] behaviours = null)
        {
            Id = id;
            Name = name;
            Icon = icon;
            BaseValue = baseValue;
            FullSaturation = fullSaturation;
            Prefab = prefab;
            ColorPalette = colorPalette;
            Behaviours = behaviours ?? Array.Empty<Type>();
        }
        
        public Identifiable.Id Id { get; }

        public string Name { get; }
        public Sprite Icon { get; }

        public float BaseValue { get; }
        public float FullSaturation { get; }

        public GameObject Prefab { get; }
        public ColorPalette ColorPalette { get; }

        public Type[] Behaviours { get; }
    }

    /// <summary>
    /// Represents a slime instance created through <see cref="ShortcutLib"/>.
    /// Typically produced by calling <see cref="SlimeCut.CreateBaseSlime"/>.
    /// </summary>
    public class BaseSlime
    {
        /// <summary>
        /// General diet information for a <see cref="BaseSlime"/> created through <see cref="ShortcutLib"/>.
        /// </summary>
        public class Diet
        {
            /// <param name="foodGroups">An array of primary <see cref="SlimeEat.FoodGroup"/>s the slime will eat.</param>
            /// <param name="additionalFoods">An array of additional <see cref="Identifiable.Id"/>s the slime will eat, this could be nearly anything that is considered an identifiable.</param>
            /// <param name="favorites">An array of favorite <see cref="Identifiable.Id"/>s, eating a favorite food typically produces more than one plort.</param>
            /// <param name="produces">An array of produced <see cref="Identifiable.Id"/>s, typically set to their own plort, but can be anything else as well.</param>
            /// <param name="favoriteProductionCount">The amount that is produced after eating any of their favorites. Typically set to 2, however, largos have it set to 4.</param>
            /// <returns><see cref="BaseSlime.Diet"/></returns>
            public Diet(
                SlimeEat.FoodGroup[] foodGroups,
                Identifiable.Id[] additionalFoods,
                Identifiable.Id[] favorites,
                Identifiable.Id[] produces,
                int favoriteProductionCount = 2)
            {
                FoodGroups = foodGroups;
                AdditionalFoods = additionalFoods;
                Favorites = favorites;
                Produces = produces;
                FavoriteProductionCount = favoriteProductionCount;
            }
            
            public SlimeEat.FoodGroup[] FoodGroups { get; }
            
            public Identifiable.Id[] AdditionalFoods { get; } 
            public Identifiable.Id[] Favorites { get; }
            public Identifiable.Id[] Produces { get; }

            public int FavoriteProductionCount { get; }

            public static Diet CreateFromDiet(SlimeDiet diet) =>
                new(diet.MajorFoodGroups, diet.AdditionalFoods, diet.Favorites, diet.Produces);
        }

        /// <param name="id">A unique enum identifier for an <see cref="Identifiable"/>, typically typed as <see cref="Identifiable.Id"/>.</param>
        /// <param name="name">The full name of the slime, this is automatically translated in-game.</param>
        /// <param name="icon">A <see cref="Sprite"/> icon to visually represent the slime with in-game UI.</param>
        /// <param name="definition">The <see cref="SlimeDefinition"/> of the slime, automatically created along with the built-in method(s) for producing <see cref="BaseSlime"/>.</param>
        /// <param name="prefab">The <see cref="GameObject"/> prefab of the slime, automatically created along with the built-in method(s) for producing <see cref="BaseSlime"/>.</param>
        /// <param name="appearance">The <see cref="SlimeAppearance"/> of the slime, automatically created along with the built-in method(s) for producing <see cref="BaseSlime"/>.</param>
        /// <param name="colorPalette">A basic <see cref="ColorPalette"/> for the slime, considered to be utility for having easy access to the colors.</param>
        /// <param name="behaviours">Optional <see cref="MonoBehaviour"/> types to iterate through, and automatically add for custom-made behaviours.</param>
        /// <returns><see cref="BaseSlime"/></returns>
        public BaseSlime(
            Identifiable.Id id,
            string name,
            Sprite icon,
            SlimeDefinition definition,
            GameObject prefab,
            SlimeAppearance appearance,
            ColorPalette colorPalette,
            Type[] behaviours = null)
        {
            Id = id;
            Name = name;
            Icon = icon;
            Definition = definition;
            Prefab = prefab;
            Appearance = appearance;
            ColorPalette = colorPalette;
            Behaviours = behaviours ?? Array.Empty<Type>();
        }
        
        public Identifiable.Id Id { get; }

        public string Name { get; }
        public Sprite Icon { get; }

        public SlimeDefinition Definition { get; }
        public GameObject Prefab { get; }
        public SlimeAppearance Appearance { get; }
        
        public ColorPalette ColorPalette { get; }
        public Type[] Behaviours  { get; }
    }

    /// <summary>
    /// Represents a gordo instance created through <see cref="ShortcutLib"/>.
    /// Typically produced by calling <see cref="SlimeCut.CreateBaseGordo"/>.
    /// </summary>
    public class BaseGordo
    {
        /// <param name="id">A unique enum identifier for an <see cref="Identifiable"/>, typically typed as <see cref="Identifiable.Id"/>.</param>
        /// <param name="name">The full name of the gordo, this is automatically translated in-game.</param>
        /// <param name="icon">A <see cref="Sprite"/> icon to visually represent the gordo with in-game UI.</param>
        /// <param name="baseSlime">The <see cref="BaseSlime"/> of the gordo, typically belongs to the <see cref="BaseSlime"/> that the gordo is based on.</param>
        /// <param name="prefab">The <see cref="GameObject"/> prefab of the gordo, automatically created along with the built-in method(s) for producing <see cref="BaseGordo"/>.</param>
        /// <param name="rewards">A list of rewards to spawn when popping the gordo, typically consists of <see cref="GameObject"/> prefabs.</param>
        /// <param name="zones">An array of <see cref="ZoneDirector.Zone"/>s the gordo naturally inhabitants.</param>
        /// <param name="feedCount">The amount of food required to pop the gordo, by default is set to 30.</param>
        /// <param name="persistentId">A persistent ID for the gordo, typically used in world placements. This is automatically created if not manually set.</param>
        /// <param name="behaviours">Optional <see cref="MonoBehaviour"/> types to iterate through, and automatically add for custom-made behaviours.</param>
        /// <returns><see cref="BaseGordo"/></returns>
        public BaseGordo(
            Identifiable.Id id,
            string name,
            Sprite icon,
            BaseSlime baseSlime,
            GameObject prefab,
            GameObject[] rewards,
            ZoneDirector.Zone[] zones,
            int feedCount = 30,
            Type[] behaviours = null,
            string persistentId = null)
        {
            Id = id;
            Name = name;
            Icon = icon;
            BaseSlime = baseSlime;
            Prefab = prefab;
            Rewards = rewards;
            Zones = zones;
            FeedCount = feedCount;
            Behaviours = behaviours ?? Array.Empty<Type>();
            PersistentId = persistentId.IsNullOrEmpty()
                ? "gordo" + name.Replace(" ", "").Replace("Gordo", "")
                : persistentId;
        }
        
        public Identifiable.Id Id { get; }
        
        public string Name { get; }
        public Sprite Icon { get; }
        
        public BaseSlime BaseSlime { get; }
        public GameObject Prefab { get; }
        
        public GameObject[] Rewards { get; }
        public GameObject[] OverrideRewards { get; }
        public ZoneDirector.Zone[] Zones { get; }
        public int FeedCount { get; }

        public Type[] Behaviours  { get; }
        public string PersistentId { get; }
    }
    
    public class BaseStructure
    {
        public class Bones
        {
            public Bones(
                SlimeAppearance.SlimeBone root,
                SlimeAppearance.SlimeBone parent,
                SlimeAppearance.SlimeBone[] attached = null)
            {
                Root = root;
                Parent = parent;
                Attached = attached ?? new []
                {
                    SlimeAppearance.SlimeBone.JiggleBack,
                    SlimeAppearance.SlimeBone.JiggleBottom,
                    SlimeAppearance.SlimeBone.JiggleFront,
                    SlimeAppearance.SlimeBone.JiggleLeft,
                    SlimeAppearance.SlimeBone.JiggleRight,
                    SlimeAppearance.SlimeBone.JiggleTop,
                };
            }
            
            public SlimeAppearance.SlimeBone Root { get; }
            public SlimeAppearance.SlimeBone Parent { get; }
            public SlimeAppearance.SlimeBone[] Attached { get; }
        }

        public BaseStructure(
            Mesh mesh,
            GameObject prefab,
            SlimeAppearanceObject appearanceObject,
            bool ignoreLODIndex = true,
            bool supportsFaces = false,
            SlimeFaceRules[] faceRules = null,
            Type[] behaviours = null)
        {
            Mesh = mesh;
            Prefab = prefab;
            AppearanceObject = appearanceObject;
            IgnoreLODIndex = ignoreLODIndex;
            SupportsFaces = supportsFaces;
            FaceRules = faceRules;
            Behaviours = behaviours ?? Array.Empty<Type>();
        }
        
        public Mesh Mesh { get; }

        public GameObject Prefab { get; }
        
        public SlimeAppearanceObject AppearanceObject { get; }
        
        public bool IgnoreLODIndex { get; }
        
        public bool SupportsFaces { get; }
        public SlimeFaceRules[] FaceRules { get; }
        public Type[] Behaviours { get; }
    }
}