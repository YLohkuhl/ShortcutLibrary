using System;
using System.ComponentModel;
using System.Runtime.InteropServices;
using MonomiPark.SlimeRancher.Regions;
using ShortcutLib.SR;
using ShortcutLib.Utils;
using ShortcutLib.Utils.Classes;
using ShortcutLib.Utils.Extensions;
using SRML.SR;
using SRML.SR.Translation;
using SRML.Utils;
using UnityEngine;

// ReSharper disable MemberCanBePrivate.Global
// ReSharper disable CheckNamespace

namespace ShortcutLib
{
    [EditorBrowsable(EditorBrowsableState.Never)]
    [Obsolete("Legacy class (as of ShortcutLib Rewrite). Refer to `ShortcutLib` (namespace) instead!")]
    public class Shortcut
    {
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("Legacy class (as of ShortcutLib Rewrite). There is no direct replacement available.")]
        public static class Ornament
        {
            [EditorBrowsable(EditorBrowsableState.Never)]
            [Obsolete("Legacy method (as of ShortcutLib Rewrite). There is no replacement available.")]
            public static GameObject CreateOrnament(string ornamentName, Identifiable.Id ornamentPrefab, Identifiable.Id ornamentIdent, Texture2D ornamentImage, Sprite ornamentIcon, Color32 topColor, Color32 middleColor, Color32 bottomColor, [Optional] Color32 vacColor, Vacuumable.Size vacSize = Vacuumable.Size.NORMAL)
            {
                GameObject OrnamentPrefab = Prefab.ObjectPrefab(Prefab.GetPrefab(ornamentPrefab));
                GameObject OrnamentModel = OrnamentPrefab.transform.Find("model").gameObject;
                OrnamentPrefab.name = ornamentName;
                OrnamentPrefab.GetComponent<Identifiable>().id = ornamentIdent;

                Material OrnamentMat = (Material)Prefab.Instantiate(OrnamentModel.GetComponent<MeshRenderer>().material);
                OrnamentModel.GetComponent<MeshRenderer>().material.mainTexture = ornamentImage;
                OrnamentModel.GetComponent<MeshRenderer>().material.color = bottomColor;
                OrnamentModel.GetComponent<MeshRenderer>().material = OrnamentMat;

                // Registry.RegisterIdentPrefab(OrnamentPrefab);
                // Registry.RegisterAmmo(OrnamentPrefab);
                // Registry.RegisterSilo(ornamentIdent);
                // Registry.RegisterVac(vacColor, ornamentIdent, ornamentIcon, ornamentName.ToLower().Replace(" ", "") + "Definition");

                return OrnamentPrefab;
            }
        }
        
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("Legacy class (as of ShortcutLib Rewrite). There is no direct replacement available.")]
        public static class Director
        {
            [EditorBrowsable(EditorBrowsableState.Never)]
            [Obsolete("Legacy method (as of ShortcutLib Rewrite). There is no replacement available.")]
            public static MailDirector Mail() => SceneContext.Instance.MailDirector;

            [EditorBrowsable(EditorBrowsableState.Never)]
            [Obsolete("Legacy method (as of ShortcutLib Rewrite). There is no replacement available.")]
            public static AchievementsDirector Achieve() => SceneContext.Instance.AchievementsDirector;

            [EditorBrowsable(EditorBrowsableState.Never)]
            [Obsolete("Legacy method (as of ShortcutLib Rewrite). There is no replacement available.")]
            public static AmbianceDirector Ambiance() => SceneContext.Instance.AmbianceDirector;

            [EditorBrowsable(EditorBrowsableState.Never)]
            [Obsolete("Legacy method (as of ShortcutLib Rewrite). There is no replacement available.")]
            public static EconomyDirector Economy() => SceneContext.Instance.EconomyDirector;

            [EditorBrowsable(EditorBrowsableState.Never)]
            [Obsolete("Legacy method (as of ShortcutLib Rewrite). There is no replacement available.")]
            public static ExchangeDirector Exchange() => SceneContext.Instance.ExchangeDirector;

            [EditorBrowsable(EditorBrowsableState.Never)]
            [Obsolete("Legacy method (as of ShortcutLib Rewrite). There is no replacement available.")]
            public static GadgetDirector Gadget() => SceneContext.Instance.GadgetDirector;

            [EditorBrowsable(EditorBrowsableState.Never)]
            [Obsolete("Legacy method (as of ShortcutLib Rewrite). There is no replacement available.")]
            public static HolidayDirector Holiday() => SceneContext.Instance.HolidayDirector;

            [EditorBrowsable(EditorBrowsableState.Never)]
            [Obsolete("Legacy method (as of ShortcutLib Rewrite). There is no replacement available.")]
            public static InstrumentDirector Instrument() => SceneContext.Instance.InstrumentDirector;

            [EditorBrowsable(EditorBrowsableState.Never)]
            [Obsolete("Legacy method (as of ShortcutLib Rewrite). There is no replacement available.")]
            public static MetadataDirector Metadata() => SceneContext.Instance.MetadataDirector;

            [EditorBrowsable(EditorBrowsableState.Never)]
            [Obsolete("Legacy method (as of ShortcutLib Rewrite). There is no replacement available.")]            
            public static ModDirector Mod() => SceneContext.Instance.ModDirector;

            [EditorBrowsable(EditorBrowsableState.Never)]
            [Obsolete("Legacy method (as of ShortcutLib Rewrite). There is no replacement available.")]
            public static PediaDirector Pedia() => SceneContext.Instance.PediaDirector;

            [EditorBrowsable(EditorBrowsableState.Never)]
            [Obsolete("Legacy method (as of ShortcutLib Rewrite). There is no replacement available.")]
            public static PopupDirector Popup() => SceneContext.Instance.PopupDirector;

            [EditorBrowsable(EditorBrowsableState.Never)]
            [Obsolete("Legacy method (as of ShortcutLib Rewrite). There is no replacement available.")]
            public static ProgressDirector Progress() => SceneContext.Instance.ProgressDirector;

            [EditorBrowsable(EditorBrowsableState.Never)]
            [Obsolete("Legacy method (as of ShortcutLib Rewrite). There is no replacement available.")]
            public static RanchDirector Ranch() => SceneContext.Instance.RanchDirector;

            [EditorBrowsable(EditorBrowsableState.Never)]
            [Obsolete("Legacy method (as of ShortcutLib Rewrite). There is no replacement available.")]
            public static SceneParticleDirector Particle() => SceneContext.Instance.SceneParticleDirector;

            [EditorBrowsable(EditorBrowsableState.Never)]
            [Obsolete("Legacy method (as of ShortcutLib Rewrite). There is no replacement available.")]
            public static SECTRDirector Sector() => SceneContext.Instance.SECTRDirector;

            [EditorBrowsable(EditorBrowsableState.Never)]
            [Obsolete("Legacy method (as of ShortcutLib Rewrite). There is no replacement available.")]
            public static TimeDirector Time() => SceneContext.Instance.TimeDirector;

            [EditorBrowsable(EditorBrowsableState.Never)]
            [Obsolete("Legacy method (as of ShortcutLib Rewrite). There is no replacement available.")]
            public static SlimeAppearanceDirector Appearance() => SceneContext.Instance.SlimeAppearanceDirector;

            [EditorBrowsable(EditorBrowsableState.Never)]
            [Obsolete("Legacy method (as of ShortcutLib Rewrite). There is no replacement available.")]
            public static TutorialDirector Tutorial() => SceneContext.Instance.TutorialDirector;

            [EditorBrowsable(EditorBrowsableState.Never)]
            [Obsolete("Legacy method (as of ShortcutLib Rewrite). There is no replacement available.")]
            public static LookupDirector Lookup() => GameContext.Instance.LookupDirector;

            [EditorBrowsable(EditorBrowsableState.Never)]
            [Obsolete("Legacy method (as of ShortcutLib Rewrite). There is no replacement available.")]
            public static AutoSaveDirector Autosave() => GameContext.Instance.AutoSaveDirector;

            [EditorBrowsable(EditorBrowsableState.Never)]
            [Obsolete("Legacy method (as of ShortcutLib Rewrite). There is no replacement available.")]
            public static DLCDirector DLC() => GameContext.Instance.DLCDirector;

            [EditorBrowsable(EditorBrowsableState.Never)]
            [Obsolete("Legacy method (as of ShortcutLib Rewrite). There is no replacement available.")]
            public static GalaxyDirector Galaxy() => GameContext.Instance.GalaxyDirector;

            [EditorBrowsable(EditorBrowsableState.Never)]
            [Obsolete("Legacy method (as of ShortcutLib Rewrite). There is no replacement available.")]
            public static InputDirector Input() => GameContext.Instance.InputDirector;

            [EditorBrowsable(EditorBrowsableState.Never)]
            [Obsolete("Legacy method (as of ShortcutLib Rewrite). There is no replacement available.")]
            public static MessageDirector Message() => GameContext.Instance.MessageDirector;

            [EditorBrowsable(EditorBrowsableState.Never)]
            [Obsolete("Legacy method (as of ShortcutLib Rewrite). There is no replacement available.")]
            public static MessageOfTheDayDirector MessageDay() => GameContext.Instance.MessageOfTheDayDirector;

            [EditorBrowsable(EditorBrowsableState.Never)]
            [Obsolete("Legacy method (as of ShortcutLib Rewrite). There is no replacement available.")]
            public static OptionsDirector Options() => GameContext.Instance.OptionsDirector;

            [EditorBrowsable(EditorBrowsableState.Never)]
            [Obsolete("Legacy method (as of ShortcutLib Rewrite). There is no replacement available.")]
            public static RailDirector Rail() => GameContext.Instance.RailDirector;

            [EditorBrowsable(EditorBrowsableState.Never)]
            [Obsolete("Legacy method (as of ShortcutLib Rewrite). There is no replacement available.")]
            public static RichPresence.Director Presence() => GameContext.Instance.RichPresenceDirector;

            [EditorBrowsable(EditorBrowsableState.Never)]
            [Obsolete("Legacy method (as of ShortcutLib Rewrite). There is no replacement available.")]
            public static ToyDirector Toy() => GameContext.Instance.ToyDirector;
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("Legacy class (as of ShortcutLib Rewrite). Refer to `ShortcutLib.SR.AchievementCut` instead!")]
        public static class Achieve
        {
            [EditorBrowsable(EditorBrowsableState.Never)]
            [Obsolete("Legacy method (as of ShortcutLib Rewrite). Use `AchievementCut.RegisterAchievement` instead!")]
            public static void CreateAchievement(string achievementName, string achievementDesc,
                AchievementsDirector.Achievement achievementId, AchievementRegistry.Tier achievementTier,
                AchievementsDirector.Tracker achievementTracker) => AchievementCut.RegisterAchievement(achievementId, achievementName,
                achievementDesc, achievementTracker, achievementTier);

            [EditorBrowsable(EditorBrowsableState.Never)]
            [Obsolete("Legacy method (as of ShortcutLib Rewrite). Use `AchievementCut.AwardAchievement` instead!")]
            public static void AwardAchieve(AchievementsDirector.Achievement achievementId) =>
                AchievementCut.AwardAchievement(achievementId);

            [EditorBrowsable(EditorBrowsableState.Never)]
            [Obsolete("Legacy method (as of ShortcutLib Rewrite). Use `AchievementCut.AddToStat` instead!")]
            public static void AddStat(AchievementsDirector.IntStat achievementStat, int statAmount) =>
                AchievementCut.AddToStat(achievementStat, statAmount);

            [EditorBrowsable(EditorBrowsableState.Never)]
            [Obsolete("Legacy method (as of ShortcutLib Rewrite). Use `AchievementCut.AddToStat` instead!")]
            public static void AddStat(AchievementsDirector.EnumStat achievementStat, Enum statValue) =>
                AchievementCut.AddToStat(achievementStat, statValue);

            [EditorBrowsable(EditorBrowsableState.Never)]
            [Obsolete("Legacy method (as of ShortcutLib Rewrite). Use `AchievementCut.AddToStat` instead!")]
            public static void AddStat(AchievementsDirector.GameIntStat achievementStat, int statAmount) =>
                AchievementCut.AddToStat(achievementStat, statAmount);

            [EditorBrowsable(EditorBrowsableState.Never)]
            [Obsolete("Legacy method (as of ShortcutLib Rewrite). Use `AchievementCut.AddToStat` instead!")]
            public static void AddStat(AchievementsDirector.GameIdDictStat achievementStat, Identifiable.Id statId, int statAmount) =>
                AchievementCut.AddToStat(achievementStat, statId, statAmount);

            [EditorBrowsable(EditorBrowsableState.Never)]
            [Obsolete("Legacy method (as of ShortcutLib Rewrite). Use `AchievementCut.SetStat` instead!")]
            public static void SetBoolStat(AchievementsDirector.BoolStat achievementStat) =>
                AchievementCut.SetStat(achievementStat, true);
        }
        
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("Legacy class (as of ShortcutLib Rewrite). There is no direct replacement available.")]
        public static class Other
        {
            [EditorBrowsable(EditorBrowsableState.Never)]
            [Obsolete("Legacy method (as of ShortcutLib Rewrite). There is no replacement available.")]
            public static UnityEngine.Object LoadAsset(Type assetType, AssetBundle assetBundle, string assetName) =>
                assetBundle.LoadAsset(assetName, assetType);

            [EditorBrowsable(EditorBrowsableState.Never)]
            [Obsolete("Legacy method (as of ShortcutLib Rewrite). Use `ShortcutLib.Utils.GeneralUtil.HexToColor` instead!")]
            public static Color LoadHex(string hexCode) => GenUtil.HexToColor(hexCode);

            [EditorBrowsable(EditorBrowsableState.Never)]
            [Obsolete("Legacy method (as of ShortcutLib Rewrite). Use `ShortcutLib.Utils.MeshUtil.CreateObject` instead!")]
            public static GameObject CreateMeshObject(string objectName, Mesh objectMesh, Type colliderType,
                [Optional] Material meshMaterial, [Optional] Vector3 meshSize, bool usesSkinnedRenderer = false,
                bool hasDelaunchTrigger = true)
            {
                var obj = !usesSkinnedRenderer
                    ? MeshCut.CreateObject(objectMesh, objectName, colliderType, meshSize)
                    : MeshCut.CreateSkinnedObject(objectMesh, objectName, colliderType, meshSize);

                obj.GetComponent<Renderer>().sharedMaterial = meshMaterial;

                if (hasDelaunchTrigger)
                    obj.AddDelaunchTrigger();

                return obj;
            }

            // public static (Color[], Color[]) CreateChroma(Sprite chromaIcon, RanchDirector.Palette newPaletteID, string newPaletteName, Color[] darkColors, Color[] lightColors, ProgressDirector.ProgressType progressType = ProgressDirector.ProgressType.NONE, int partnerLevel = 0, int progressCount = 0, int order = 0)
            // {
            //     if (darkColors.Length < 8)
            //         throw new NullReferenceException("Please have at least 8 colors in your Dark Colors Array. (This includes Light Colors)");
            //     if (darkColors.Length > 8)
            //         throw new NullReferenceException("Please don't have more than 8 colors in your Dark Colors Array. (This includes Light Colors)");
            //     if (lightColors.Length < 8)
            //         throw new NullReferenceException("Please have at least 8 colors in your Light Colors Array. (This includes Dark Colors)");
            //     if (lightColors.Length > 8)
            //         throw new NullReferenceException("Please don't have more than 8 colors in your Light Colors Array. (This includes Dark Colors)");
            //
            //     ChromaRegistry.RegisterPaletteEntry(
            //         new RanchDirector.PaletteEntry()
            //         {
            //             icon = chromaIcon,
            //             palette = newPaletteID,
            //             requiresPartnerLevel = partnerLevel,
            //             requiresProgressCount = progressCount,
            //             requiresProgressType = progressType,
            //             order = order,
            //             blackDark = darkColors[0],
            //             blueDark = darkColors[1],
            //             cyanDark = darkColors[2],
            //             greenDark = darkColors[3],
            //             magentaDark = darkColors[4],
            //             redDark = darkColors[5],
            //             whiteDark = darkColors[6],
            //             yellowDark = darkColors[7],
            //             blackLight = lightColors[0],
            //             blueLight = lightColors[1],
            //             cyanLight = lightColors[2],
            //             greenLight = lightColors[3],
            //             magentaLight = lightColors[4],
            //             redLight = lightColors[5],
            //             whiteLight = lightColors[6],
            //             yellowLight = lightColors[7]
            //         }
            //     );
            //     Translate.TranslatePedia("m.palette.name." + newPaletteID.ToString().ToLower(), newPaletteName);
            //
            //     return (darkColors, lightColors);
            // }

            // public static (LiquidDefinition, GameObject, Material) CreateLiquid(Identifiable.Id liquidPrefab, Identifiable.Id newLiquidID, string liquidName, Texture2D colorRamp, Color liquidColor, Color vacColor, Sprite liquidIcon)
            // {
            //     // PREFAB
            //     GameObject LiquidPrefab = PrefabUtils.CopyPrefab(SRSingleton<GameContext>.Instance.LookupDirector.GetPrefab(liquidPrefab));
            //     LiquidDefinition liquidDefinition = ScriptableObject.CreateInstance<LiquidDefinition>();
            //     GameObject liquidIncomingFX = Prefab.ObjectPrefab(SRSingleton<GameContext>.Instance.LookupDirector.GetLiquidIncomingFX(liquidPrefab));
            //     GameObject liquidVacFailFX = Prefab.ObjectPrefab(SRSingleton<GameContext>.Instance.LookupDirector.GetLiquidVacFailFX(liquidPrefab));
            //
            //     LiquidPrefab.name = liquidName;
            //     LiquidPrefab.GetComponent<Identifiable>().id = newLiquidID;
            //     liquidDefinition.name = liquidName;
            //
            //     // MATERIAL
            //     GameObject SpherePrefab = LiquidPrefab.FindChild("Sphere");
            //     MeshRenderer LiquidRenderer = SpherePrefab.GetComponent<MeshRenderer>();
            //     Material liquidMaterial = UnityEngine.Object.Instantiate(LiquidRenderer.sharedMaterial);
            //     liquidMaterial.name = liquidName;
            //     liquidMaterial.SetTexture("_ColorRamp", colorRamp);
            //     LiquidRenderer.sharedMaterial = liquidMaterial;
            //
            //     // PARTICLE
            //     GameObject fxWaterSplat = Prefab.ObjectPrefab(Assets.LoadResource<GameObject>("FX waterSplat"));
            //     liquidIncomingFX.transform.Find("Water Glops").GetComponent<ParticleSystemRenderer>().sharedMaterial = LiquidPrefab.transform.Find("Sphere").GetComponent<MeshRenderer>().sharedMaterial;
            //     var SprinklerSystemMain = LiquidPrefab.transform.Find("Sphere").Find("FX Sprinkler 1").GetComponent<ParticleSystem>().main;
            //     var SprinklerSystemOvertime = LiquidPrefab.transform.Find("Sphere").Find("FX Sprinkler 1").GetComponent<ParticleSystem>().colorOverLifetime;
            //     SprinklerSystemMain.startColor = new ParticleSystem.MinMaxGradient(liquidColor);
            //     SprinklerSystemOvertime.color = new ParticleSystem.MinMaxGradient(liquidColor);
            //
            //     LiquidPrefab.transform.Find("Sphere").Find("FX Water Glops").GetComponent<ParticleSystemRenderer>().sharedMaterial = LiquidPrefab.transform.Find("Sphere").GetComponent<MeshRenderer>().sharedMaterial;
            //     fxWaterSplat.transform.Find("Water Glops").GetComponent<ParticleSystemRenderer>().sharedMaterial = LiquidPrefab.transform.Find("Sphere").GetComponent<MeshRenderer>().sharedMaterial;
            //
            //     var MainSystemMain = fxWaterSplat.GetComponent<ParticleSystem>().main;
            //     // var MainSystemMainOvertime = fxWaterSplat.GetComponent<ParticleSystem>().colorOverLifetime;
            //
            //     var HitSystemMain = fxWaterSplat.transform.Find("Hit").GetComponent<ParticleSystem>().main;
            //     // var HitSystemOvertime = fxWaterSplat.transform.Find("Hit").GetComponent<ParticleSystem>().colorOverLifetime;
            //
            //     var BubblesSystemMain = fxWaterSplat.transform.Find("Bubbles").GetComponent<ParticleSystem>().main;
            //     var BubblesSystemOvertime = fxWaterSplat.transform.Find("Bubbles").GetComponent<ParticleSystem>().colorOverLifetime;
            //
            //     var SparklesSystemMain = fxWaterSplat.transform.Find("Sparkles").GetComponent<ParticleSystem>().main;
            //     // var SparklesSystemOvertime = fxWaterSplat.transform.Find("Sparkles").GetComponent<ParticleSystem>().colorOverLifetime;
            //
            //     var WaveSystemMain = fxWaterSplat.transform.Find("Wave").GetComponent<ParticleSystem>().main;
            //     // var WaveSystemOvertime = fxWaterSplat.transform.Find("Wave").GetComponent<ParticleSystem>().colorOverLifetime;
            //
            //     MainSystemMain.startColor = new ParticleSystem.MinMaxGradient(liquidColor, new Color(liquidColor.r, liquidColor.g, liquidColor.b, 0));
            //     // MainSystemMainOvertime.color = new ParticleSystem.MinMaxGradient(liquidColor, new Color(liquidColor.r, liquidColor.g, liquidColor.b, 0));
            //
            //     HitSystemMain.startColor = new ParticleSystem.MinMaxGradient(liquidColor, new Color(liquidColor.r, liquidColor.g, liquidColor.b, 0));
            //     // HitSystemOvertime.color = new ParticleSystem.MinMaxGradient(liquidColor, new Color(liquidColor.r, liquidColor.g, liquidColor.b, 0));
            //
            //     BubblesSystemMain.startColor = new ParticleSystem.MinMaxGradient(liquidColor, new Color(liquidColor.r, liquidColor.g, liquidColor.b, 0));
            //     BubblesSystemOvertime.color = new ParticleSystem.MinMaxGradient(liquidColor, new Color(liquidColor.r, liquidColor.g, liquidColor.b, 0));
            //
            //     SparklesSystemMain.startColor = new ParticleSystem.MinMaxGradient(liquidColor, new Color(liquidColor.r, liquidColor.g, liquidColor.b, 0));
            //     // SparklesSystemOvertime.color = new ParticleSystem.MinMaxGradient(liquidColor, new Color(liquidColor.r, liquidColor.g, liquidColor.b, 0));
            //
            //     WaveSystemMain.startColor = new ParticleSystem.MinMaxGradient(liquidColor, new Color(liquidColor.r, liquidColor.g, liquidColor.b, 0));
            //     // WaveSystemOvertime.color = new ParticleSystem.MinMaxGradient(liquidColor, new Color(liquidColor.r, liquidColor.g, liquidColor.b, 0));
            //
            //     LiquidPrefab.GetComponent<DestroyOnTouching>().destroyFX = fxWaterSplat;
            //
            //     // DEFINITION
            //     typeof(LiquidDefinition).GetField("id", BindingFlags.Instance | BindingFlags.NonPublic).SetValue(liquidDefinition, newLiquidID);
            //     typeof(LiquidDefinition).GetField("inFX", BindingFlags.Instance | BindingFlags.NonPublic).SetValue(liquidDefinition, liquidIncomingFX);
            //     typeof(LiquidDefinition).GetField("vacFailFX", BindingFlags.Instance | BindingFlags.NonPublic).SetValue(liquidDefinition, liquidVacFailFX);
            //
            //     // REGISTER
            //     Identifiable.LIQUID_CLASS.Add(newLiquidID);
            //     Translate.TranslatePedia("t." + newLiquidID.ToString().ToLower(), liquidName);
            //     LookupRegistry.RegisterLiquid(liquidDefinition);
            //     LookupRegistry.RegisterIdentifiablePrefab(LiquidPrefab);
            //     LookupRegistry.RegisterVacEntry(newLiquidID, vacColor, liquidIcon);
            //     AmmoRegistry.RegisterPlayerAmmo(PlayerState.AmmoMode.DEFAULT, newLiquidID);
            //
            //     return (liquidDefinition, LiquidPrefab, liquidMaterial);
            // }
            //
            // public static GameObject CreateFountain(Identifiable.Id liquidObject, string fountainObject, string parent, string fountainName, Vector3 position, string dictionaryName)
            // {
            //     // OBJECT
            //     GameObject ParentObject = GameObject.Find(parent);
            //     GameObject FountainObject = GameObjectUtils.InstantiateInactive(GameObject.Find(fountainObject));
            //     FountainObject.transform.parent = ParentObject.transform;
            //     FountainObject.name = fountainName;
            //     FountainObject.transform.position = position;
            //
            //     // LIQUID
            //     LiquidSource componentInChildren = FountainObject.GetComponentInChildren<LiquidSource>();
            //     componentInChildren.director = IdHandlerUtils.GlobalIdDirector;
            //     componentInChildren.director.persistenceDict.Add(componentInChildren, dictionaryName);
            //     componentInChildren.liquidId = liquidObject;
            //     FountainObject.SetActive(true);
            //
            //     return FountainObject;
            // }
            //
            // public static void ColorFountain(GameObject fountainObject, Color mainColor, Color mistColor, Color hitColor, Color dripsColor, Color waveColor, Color rippleColor, Color tinyDripsColor, Color glowColor, Color sparklesColor)
            // {
            //     PooledSceneParticle ParticlePrefab = fountainObject.GetComponentInChildren<PooledSceneParticle>();
            //     GameObject FountainParticle = Prefab.ObjectPrefab(ParticlePrefab.particlePrefab);
            //
            //     var MainSystemMain = FountainParticle.GetComponent<ParticleSystem>().main;
            //     // var MainSystemMainOvertime = FountainParticle.GetComponent<ParticleSystem>().colorOverLifetime;
            //
            //     var MistSystemMain = FountainParticle.transform.Find("Mist").GetComponent<ParticleSystem>().main;
            //     var MistSystemOvertime = FountainParticle.transform.Find("Mist").GetComponent<ParticleSystem>().colorOverLifetime;
            //
            //     var HitSystemMain = FountainParticle.transform.Find("Hit").GetComponent<ParticleSystem>().main;
            //     // var HitSystemOvertime = FountainParticle.transform.Find("Hit").GetComponent<ParticleSystem>().colorOverLifetime;
            //
            //     var DripsSystemMain = FountainParticle.transform.Find("Drips").GetComponent<ParticleSystem>().main;
            //     // var DripsSystemOvertime = FountainParticle.transform.Find("Drips").GetComponent<ParticleSystem>().colorOverLifetime;
            //
            //     var WaveSystemMain = FountainParticle.transform.Find("Wave").GetComponent<ParticleSystem>().main;
            //     // var WaveSystemOvertime = FountainParticle.transform.Find("Wave").GetComponent<ParticleSystem>().colorOverLifetime;
            //
            //     var RippleSystemMain = FountainParticle.transform.Find("Ripple").GetComponent<ParticleSystem>().main;
            //     // var RippleSystemOvertime = FountainParticle.transform.Find("Ripple").GetComponent<ParticleSystem>().colorOverLifetime;
            //
            //     var TinyDripsSystemMain = FountainParticle.transform.Find("Tiny Drips").GetComponent<ParticleSystem>().main;
            //     var TinyDripsSystemOvertime = FountainParticle.transform.Find("Tiny Drips").GetComponent<ParticleSystem>().colorOverLifetime;
            //
            //     var GlowSystemMain = FountainParticle.transform.Find("Glow").GetComponent<ParticleSystem>().main;
            //     // var GlowSystemOvertime = FountainParticle.transform.Find("Glow").GetComponent<ParticleSystem>().colorOverLifetime;
            //
            //     var SparklesSystemMain = FountainParticle.transform.Find("Sparkles").GetComponent<ParticleSystem>().main;
            //     var SparklesSystemOvertime = FountainParticle.transform.Find("Sparkles").GetComponent<ParticleSystem>().colorOverLifetime;
            //
            //     MainSystemMain.startColor = new ParticleSystem.MinMaxGradient(mainColor, new Color(mainColor.r, mainColor.g, mainColor.b, 0));
            //     // MainSystemMainOvertime.color = new ParticleSystem.MinMaxGradient(mainColor, new Color(mainColor.r, mainColor.g, mainColor.b, 0));
            //
            //     MistSystemMain.startColor = new ParticleSystem.MinMaxGradient(mistColor, new Color(mistColor.r, mistColor.g, mistColor.b, 0));
            //     MistSystemOvertime.color = new ParticleSystem.MinMaxGradient(mistColor, new Color(mistColor.r, mistColor.g, mistColor.b, 0));
            //
            //     HitSystemMain.startColor = new ParticleSystem.MinMaxGradient(hitColor, new Color(hitColor.r, hitColor.g, hitColor.b, 0));
            //     // HitSystemOvertime.color = new ParticleSystem.MinMaxGradient(hitColor, new Color(hitColor.r, hitColor.g, hitColor.b, 0));
            //
            //     DripsSystemMain.startColor = new ParticleSystem.MinMaxGradient(dripsColor, new Color(dripsColor.r, dripsColor.g, dripsColor.b, 0));
            //     // DripsSystemOvertime.color = new ParticleSystem.MinMaxGradient(dripsColor, new Color(dripsColor.r, dripsColor.g, dripsColor.b, 0));
            //
            //     WaveSystemMain.startColor = new ParticleSystem.MinMaxGradient(waveColor, new Color(waveColor.r, waveColor.g, waveColor.b, 0));
            //     // WaveSystemOvertime.color = new ParticleSystem.MinMaxGradient(waveColor, new Color(waveColor.r, waveColor.g, waveColor.b, 0));
            //
            //     RippleSystemMain.startColor = new ParticleSystem.MinMaxGradient(rippleColor, new Color(rippleColor.r, rippleColor.g, rippleColor.b, 0));
            //     // RippleSystemOvertime.color = new ParticleSystem.MinMaxGradient(rippleColor, new Color(rippleColor.r, rippleColor.g, rippleColor.b, 0));
            //
            //     TinyDripsSystemMain.startColor = new ParticleSystem.MinMaxGradient(tinyDripsColor, new Color(tinyDripsColor.r, tinyDripsColor.g, tinyDripsColor.b, 0));
            //     TinyDripsSystemOvertime.color = new ParticleSystem.MinMaxGradient(tinyDripsColor, new Color(tinyDripsColor.r, tinyDripsColor.g, tinyDripsColor.b, 0));
            //
            //     GlowSystemMain.startColor = new ParticleSystem.MinMaxGradient(glowColor, new Color(glowColor.r, glowColor.g, glowColor.b, 0));
            //     // GlowSystemOvertime.color = new ParticleSystem.MinMaxGradient(glowColor, new Color(glowColor.r, glowColor.g, glowColor.b, 0));
            //
            //     SparklesSystemMain.startColor = new ParticleSystem.MinMaxGradient(sparklesColor, new Color(sparklesColor.r, sparklesColor.g, sparklesColor.b, 0));
            //     SparklesSystemOvertime.color = new ParticleSystem.MinMaxGradient(sparklesColor, new Color(sparklesColor.r, sparklesColor.g, sparklesColor.b, 0));
            //
            //     ParticlePrefab.particlePrefab = FountainParticle;
            // }
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("Legacy class (as of ShortcutLib Rewrite). There is no direct replacement available.")]
        public static class Prefab
        {
            [EditorBrowsable(EditorBrowsableState.Never)]
            [Obsolete("Legacy method (as of ShortcutLib Rewrite). Use `EnumExtensions.GetPrefab` instead!")]
            public static GameObject GetPrefab(Identifiable.Id objectToGet) => objectToGet.GetPrefab();

            [EditorBrowsable(EditorBrowsableState.Never)]
            [Obsolete(
                "Legacy method (as of ShortcutLib Rewrite). Use `ShortcutLib.Utils.Extensions.PrefabExtensions.CopyPrefab` instead!")]
            public static GameObject QuickPrefab(Identifiable.Id objectToCopy) => objectToCopy.CopyPrefab();

            [EditorBrowsable(EditorBrowsableState.Never)]
            [Obsolete(
                "Legacy method (as of ShortcutLib Rewrite). Use `ShortcutLib.Utils.Extensions.PrefabExtensions.CopyPrefab` instead!")]
            public static GameObject ObjectPrefab(GameObject objectToCopy) => objectToCopy.CopyPrefab();

            [EditorBrowsable(EditorBrowsableState.Never)]
            [Obsolete(
                "Legacy method (as of ShortcutLib Rewrite). Use `SRML.Utils.PrefabUtils.DeepCopyObject` instead!")]
            public static UnityEngine.Object DeepPrefab(UnityEngine.Object objectToCopy) =>
                PrefabUtils.DeepCopyObject(objectToCopy);

            [EditorBrowsable(EditorBrowsableState.Never)]
            [Obsolete("Legacy method (as of ShortcutLib Rewrite). Use `UnityEngine.Object.Instantiate` instead!")]
            public static UnityEngine.Object Instantiate(UnityEngine.Object objectToCopy) =>
                UnityEngine.Object.Instantiate(objectToCopy);

            [EditorBrowsable(EditorBrowsableState.Never)]
            [Obsolete("Legacy method (as of ShortcutLib Rewrite). Use `SRBehaviour.InstantiateActor` instead!")]
            public static GameObject InstantiateActor(GameObject objectToCopy, RegionRegistry.RegionSetId region,
                Vector3 position, Quaternion rotation, bool nonActorOk = false) =>
                SRBehaviour.InstantiateActor(objectToCopy, region, position, rotation, nonActorOk);

            [EditorBrowsable(EditorBrowsableState.Never)]
            [Obsolete("Legacy method (as of ShortcutLib Rewrite). Use `UnityEngine.Object.Destroy` instead!")]
            public static void Destroy(UnityEngine.Object objectToDestroy) =>
                UnityEngine.Object.Destroy(objectToDestroy);

            [EditorBrowsable(EditorBrowsableState.Never)]
            [Obsolete("Legacy method (as of ShortcutLib Rewrite). Use `Destroyer.Destroy` instead!")]
            public static void PermanentDestroy(UnityEngine.Object objectToDestroy, string source) =>
                Destroyer.Destroy(objectToDestroy, source);
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("Legacy class (as of ShortcutLib Rewrite). There is no direct replacement available.")]
        public static class EnumP
        {
            [EditorBrowsable(EditorBrowsableState.Never)]
            [Obsolete(
                "Legacy method (as of ShortcutLib Rewrite). Use `ShortcutLib.Utils.GenUtil.ParseEnum<T>` instead!")]
            public static Identifiable.Id ParseID(string enumId) => GenUtil.ParseEnum<Identifiable.Id>(enumId);

            [EditorBrowsable(EditorBrowsableState.Never)]
            [Obsolete(
                "Legacy method (as of ShortcutLib Rewrite). Use `ShortcutLib.Utils.GenUtil.ParseEnum<T>` instead!")]
            public static Gadget.Id ParseGad(string enumId) => GenUtil.ParseEnum<Gadget.Id>(enumId);

            [EditorBrowsable(EditorBrowsableState.Never)]
            [Obsolete(
                "Legacy method (as of ShortcutLib Rewrite). Use `ShortcutLib.Utils.GenUtil.ParseEnum<T>` instead!")]
            public static PediaDirector.Id ParsePedia(string enumId) => GenUtil.ParseEnum<PediaDirector.Id>(enumId);

            [EditorBrowsable(EditorBrowsableState.Never)]
            [Obsolete(
                "Legacy method (as of ShortcutLib Rewrite). Use `ShortcutLib.Utils.GenUtil.ParseEnum<T>` instead!")]
            public static SpawnResource.Id ParseSpawnRes(string enumId) => GenUtil.ParseEnum<SpawnResource.Id>(enumId);

            [EditorBrowsable(EditorBrowsableState.Never)]
            [Obsolete(
                "Legacy method (as of ShortcutLib Rewrite). Use `ShortcutLib.Utils.GenUtil.ParseEnum<T>` instead!")]
            public static LandPlot.Id ParsePlot(string enumId) => GenUtil.ParseEnum<LandPlot.Id>(enumId);

            [EditorBrowsable(EditorBrowsableState.Never)]
            [Obsolete(
                "Legacy method (as of ShortcutLib Rewrite). Use `ShortcutLib.Utils.GenUtil.ParseEnum<T>` instead!")]
            public static SlimeEat.FoodGroup ParseGroup(string enumId) => GenUtil.ParseEnum<SlimeEat.FoodGroup>(enumId);

            [EditorBrowsable(EditorBrowsableState.Never)]
            [Obsolete(
                "Legacy method (as of ShortcutLib Rewrite). Use `ShortcutLib.Utils.GenUtil.ParseEnum<T>` instead!")]
            public static RanchDirector.Palette ParsePalette(string enumId) =>
                GenUtil.ParseEnum<RanchDirector.Palette>(enumId);
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("Legacy class (as of ShortcutLib Rewrite). Refer to `ShortcutLib.SR.SlimeCut` instead!")]
        public static class Slime
        {
            [EditorBrowsable(EditorBrowsableState.Never)]
            [Obsolete("Legacy method (as of ShortcutLib Rewrite). Use `EnumExtensions.GetPrefab` instead!")]
            public static GameObject GetGordo(Identifiable.Id gordoPrefab) => gordoPrefab.GetPrefab();

            [EditorBrowsable(EditorBrowsableState.Never)]
            [Obsolete("Legacy method (as of ShortcutLib Rewrite). Use `EnumExtensions.GetSlimeDefinition` instead!")]
            public static SlimeDefinition GetSlimeDef(Identifiable.Id slimePrefab) => slimePrefab.GetSlimeDefinition();

            [EditorBrowsable(EditorBrowsableState.Never)]
            [Obsolete(
                "Legacy method (as of ShortcutLib Rewrite). Use `ShortcutLib.SR.SlimeCut.GetSlimeAppearance` instead!")]
            public static SlimeAppearance GetSlimeApp(SlimeDefinition slimeDefinition) =>
                slimeDefinition.GetSlimeAppearance(0, true);

            [EditorBrowsable(EditorBrowsableState.Never)]
            [Obsolete(
                "Legacy method (as of ShortcutLib Rewrite). Use `ShortcutLib.SR.SlimeCut.CreateBaseSlime` instead!")]
            public static (SlimeDefinition, GameObject, SlimeAppearance) CreateSlime(Identifiable.Id slimePrefab,
                Identifiable.Id slimeObjectPrefab, Identifiable.Id newSlimeID, string newSlimeName, Sprite newIcon,
                Color vacColor, Color SplatColor1, [Optional] Color SplatColor2, [Optional] Color SplatColor3,
                [Optional] Color AmmoColor, Vacuumable.Size vacSetting = Vacuumable.Size.NORMAL)
            {
                SlimeCut.CreateBaseSlime(slimePrefab, newSlimeID, newSlimeName, newIcon,
                    BaseSlime.Diet.CreateFromDiet(GetSlimeDef(slimePrefab).Diet),
                    new ColorPalette(SplatColor1, SplatColor2, SplatColor3, AmmoColor), out BaseSlime baseSlime);
                return (baseSlime.Definition, baseSlime.Prefab, baseSlime.Appearance);
            }

            [EditorBrowsable(EditorBrowsableState.Never)]
            [Obsolete("Legacy method (as of ShortcutLib Rewrite). There is no replacement available.")]
            public static Material ColorSlime(Identifiable.Id slimePrefab, Identifiable.Id slimeMaterial, Color Color1,
                Color Color2, Color Color3, Color Color4, float Shininess = 1f, float Gloss = 1f)
            {
                SlimeAppearance slimeAppearance = SRSingleton<GameContext>.Instance.SlimeDefinitions
                    .GetSlimeByIdentifiableId(slimePrefab).AppearancesDefault[0];

                Material material = UnityEngine.Object.Instantiate(SRSingleton<GameContext>.Instance.SlimeDefinitions
                    .GetSlimeByIdentifiableId(slimeMaterial).AppearancesDefault[0].Structures[0].DefaultMaterials[0]);
                material.SetColor("_TopColor", Color1);
                material.SetColor("_MiddleColor", Color2);
                material.SetColor("_BottomColor", Color3);
                material.SetColor("_SpecColor", Color4);
                material.SetFloat("_Shininess", Shininess);
                material.SetFloat("_Gloss", Gloss);
                slimeAppearance.Structures[0].DefaultMaterials[0] = material;

                return slimeAppearance.Structures[0].DefaultMaterials[0];
            }

            [EditorBrowsable(EditorBrowsableState.Never)]
            [Obsolete("Legacy method (as of ShortcutLib Rewrite). Use `ShortcutLib.SR.SlimeCut.CreateBasePlort` instead!")]
            public static GameObject CreatePlort(Identifiable.Id plortPrefab, Identifiable.Id newPlortID,
                string newPlortName, Sprite newIcon, Color32 vacColor, float plortPrice = 12, float plortSaturation = 5,
                Vacuumable.Size vacSetting = Vacuumable.Size.NORMAL)
            {
                SlimeCut.CreateBasePlort(plortPrefab, newPlortID, newPlortName, newIcon, plortPrice, plortSaturation,
                    new ColorPalette(ammo: vacColor), out var basePlort);
                return basePlort.Prefab;
            }

            [EditorBrowsable(EditorBrowsableState.Never)]
            [Obsolete("Legacy method (as of ShortcutLib Rewrite). There is no replacement available.")]
            public static GameObject ColorPlort(Identifiable.Id plortPrefab, Color Color1, Color Color2, Color Color3,
                [Optional] Identifiable.Id plortMaterial, [Optional] Color RockColor1, [Optional] Color RockColor2,
                [Optional] Color RockColor3, bool hasRocks = false)
            {
                GameObject PlortPrefab = Prefab.GetPrefab(plortPrefab);

                if (plortMaterial == Identifiable.Id.NONE)
                {
                    plortMaterial = Identifiable.Id.PINK_PLORT;
                }

                Material plortMatPrefab = Prefab.QuickPrefab(plortMaterial).GetComponent<MeshRenderer>().material;
                PlortPrefab.GetComponent<MeshRenderer>().material = plortMatPrefab;

                PlortPrefab.GetComponent<MeshRenderer>().material.SetColor("_TopColor", Color1);
                PlortPrefab.GetComponent<MeshRenderer>().material.SetColor("_MiddleColor", Color2);
                PlortPrefab.GetComponent<MeshRenderer>().material.SetColor("_BottomColor", Color3);

                if (hasRocks)
                {
                    PlortPrefab.transform.Find("rocks").GetComponent<MeshRenderer>().material
                        .SetColor("_TopColor", RockColor1);
                    PlortPrefab.transform.Find("rocks").GetComponent<MeshRenderer>().material
                        .SetColor("_MiddleColor", RockColor2);
                    PlortPrefab.transform.Find("rocks").GetComponent<MeshRenderer>().material
                        .SetColor("_BottomColor", RockColor3);
                }

                return PlortPrefab;
            }

            // NOT IMPLEMENTED IN V2 YET

            // public static (SlimeDefinition, GameObject) CreateGordo(Identifiable.Id gordoPrefab, Identifiable.Id basePrefab, Identifiable.Id newGordoID, Sprite newGordoIcon, string newGordoName, string mapMarkerName, ZoneDirector.Zone gordoZone, int feedCount, List<GameObject> gordoRewards, Vacuumable.Size vacSetting = Vacuumable.Size.GIANT)
            // {
            //     GameObject GordoPrefab = Prefab.ObjectPrefab(Slime.GetGordo(gordoPrefab));
            //     GordoPrefab.name = newGordoName;
            //     GameObject BasePrefab = Prefab.QuickPrefab(basePrefab);
            //     BasePrefab.GetComponent<Vacuumable>().size = vacSetting;
            //     SlimeDefinition BasePrefabDef = GetSlimeDef(basePrefab);
            //
            //     Material ModelMat = BasePrefabDef.AppearancesDefault[0].Structures[0].DefaultMaterials[0];
            //
            //     SlimeEyeComponents baseSlimeEyes = BasePrefab.GetComponent<SlimeEyeComponents>();
            //     SlimeMouthComponents baseSlimeMouth = BasePrefab.GetComponent<SlimeMouthComponents>();
            //
            //     GordoFaceComponents GordoFace = GordoPrefab.GetComponent<GordoFaceComponents>();
            //     GordoFace.strainEyes = baseSlimeEyes.scaredEyes;
            //     GordoFace.strainMouth = baseSlimeMouth.chompClosedMouth;
            //     GordoFace.blinkEyes = baseSlimeEyes.blinkEyes;
            //     GordoFace.chompOpenMouth = baseSlimeMouth.chompOpenMouth;
            //     GordoFace.happyMouth = baseSlimeMouth.happyMouth;
            //
            //     GordoDisplayOnMap disp = GordoPrefab.GetComponent<GordoDisplayOnMap>();
            //     GameObject MarkerPrefab = Prefab.ObjectPrefab(disp.markerPrefab.gameObject);
            //     MarkerPrefab.name = mapMarkerName;
            //     MarkerPrefab.GetComponent<Image>().sprite = newGordoIcon;
            //     
            //     disp.markerPrefab = MarkerPrefab.GetComponent<MapMarker>();
            //
            //     GordoIdentifiable iden = GordoPrefab.GetComponent<GordoIdentifiable>();
            //     iden.id = newGordoID;
            //     iden.nativeZones = new ZoneDirector.Zone[1] { gordoZone };
            //
            //     GordoEat eat = GordoPrefab.GetComponent<GordoEat>();
            //     SlimeDefinition oldDefinition = (SlimeDefinition)Prefab.DeepPrefab(eat.slimeDefinition);
            //
            //     oldDefinition.AppearancesDefault = BasePrefabDef.AppearancesDefault;
            //     oldDefinition.Diet = BasePrefabDef.Diet;
            //     oldDefinition.IdentifiableId = newGordoID;
            //     oldDefinition.name = newGordoName;
            //     eat.slimeDefinition = oldDefinition;
            //     eat.targetCount = feedCount;
            //
            //     GordoRewards GordoRewards = GordoPrefab.GetComponent<GordoRewards>();
            //     GordoRewards.rewardPrefabs = gordoRewards.ToArray();
            //     GordoRewards.slimePrefab = GameContext.Instance.LookupDirector.GetPrefab(basePrefab);
            //     GordoRewards.rewardOverrides = new GordoRewards.RewardOverride[0];
            //
            //     GameObject child = GordoPrefab.transform.Find("Vibrating/slime_gordo").gameObject;
            //     SkinnedMeshRenderer render = child.GetComponent<SkinnedMeshRenderer>();
            //     render.sharedMaterial = ModelMat;
            //     render.sharedMaterials[0] = ModelMat;
            //     render.material = ModelMat;
            //     render.materials[0] = ModelMat;
            //
            //     Translate.TranslatePedia("t." + newGordoID.ToString().ToLower(), newGordoName);
            //     Identifiable.GORDO_CLASS.Add(newGordoID);
            //     LookupRegistry.RegisterGordo(GordoPrefab);
            //
            //     return (oldDefinition, GordoPrefab);
            // }
        }
        
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("Legacy class (as of ShortcutLib Rewrite). Refer to `ShortcutLib.SR.TranslationCut` instead!")]
        public static class Translate
        {
            [EditorBrowsable(EditorBrowsableState.Never)]
            [Obsolete("Legacy method (as of ShortcutLib Rewrite). There is no replacement available.")]
            public static void TranslateActor(string actorKey, string actorTranslated)
            { TranslationPatcher.AddActorTranslation(actorKey, actorTranslated); }

            [EditorBrowsable(EditorBrowsableState.Never)]
            [Obsolete("Legacy method (as of ShortcutLib Rewrite). There is no replacement available.")]
            public static void TranslatePedia(string pediaKey, string pediaTranslated)
            { TranslationPatcher.AddPediaTranslation(pediaKey, pediaTranslated); }

            [EditorBrowsable(EditorBrowsableState.Never)]
            [Obsolete("Legacy method (as of ShortcutLib Rewrite). There is no replacement available.")]
            public static void TranslateUI(string uiKey, string uiTranslated)
            { TranslationPatcher.AddUITranslation(uiKey, uiTranslated); }

            [EditorBrowsable(EditorBrowsableState.Never)]
            [Obsolete("Legacy method (as of ShortcutLib Rewrite). There is no replacement available.")]
            public static void TranslateKey(string bundle, string key, string value)
            { TranslationPatcher.AddTranslationKey(bundle, key, value); }

            [EditorBrowsable(EditorBrowsableState.Never)]
            [Obsolete("Legacy method (as of ShortcutLib Rewrite). There is no replacement available.")]
            public static void TranslateAchieve(string achieveKey, string achieveTranslated)
            { TranslationPatcher.AddAchievementTranslation(achieveKey, achieveTranslated); }

            [EditorBrowsable(EditorBrowsableState.Never)]
            [Obsolete("Legacy method (as of ShortcutLib Rewrite). There is no replacement available.")]
            public static void TranslateExchange(string exchangeKey, string exchangeTranslated)
            { TranslationPatcher.AddExchangeTranslation(exchangeKey, exchangeTranslated); }

            [EditorBrowsable(EditorBrowsableState.Never)]
            [Obsolete("Legacy method (as of ShortcutLib Rewrite). There is no replacement available.")]
            public static void TranslateGlobal(string globalKey, string globalTranslated)
            { TranslationPatcher.AddGlobalTranslation(globalKey, globalTranslated); }

            [EditorBrowsable(EditorBrowsableState.Never)]
            [Obsolete("Legacy method (as of ShortcutLib Rewrite). There is no replacement available.")]
            public static void TranslateMail(string mailKey, string mailTranslated)
            { TranslationPatcher.AddMailTranslation(mailKey, mailTranslated); }

            [EditorBrowsable(EditorBrowsableState.Never)]
            [Obsolete("Legacy method (as of ShortcutLib Rewrite). There is no replacement available.")]
            public static void TranslateSRMLError(MessageDirector.Lang language, string errorKey, string errorTranslated)
            { TranslationPatcher.AddSRMLErrorUITranslation(language, errorKey, errorTranslated); }

            [EditorBrowsable(EditorBrowsableState.Never)]
            [Obsolete("Legacy method (as of ShortcutLib Rewrite). There is no replacement available.")]
            public static void TranslateTutorial(string tutorialKey, string tutorialTranslated)
            { TranslationPatcher.AddTutorialTranslation(tutorialKey, tutorialTranslated); }

            public static void CreateSlimepedia(Identifiable.Id id, PediaDirector.Id entry, Sprite icon, string pediaTitle, string pediaIntro, string pediaDiet, string pediaFavorite, string pediaSlimeology, string pediaRisks, string pediaPlortonomics)
            {
                PediaRegistry.RegisterIdEntry(entry, icon);
                PediaRegistry.RegisterIdentifiableMapping((PediaDirector.Id)1, id);
                PediaRegistry.RegisterIdentifiableMapping(entry, id);
                PediaRegistry.SetPediaCategory(entry, (PediaRegistry.PediaCategory)1);
                new SlimePediaEntryTranslation(entry)
                    .SetTitleTranslation(pediaTitle)
                    .SetIntroTranslation(pediaIntro)
                    .SetDietTranslation(pediaDiet)
                    .SetFavoriteTranslation(pediaFavorite)
                    .SetSlimeologyTranslation(pediaSlimeology)
                    .SetRisksTranslation(pediaRisks)
                    .SetPlortonomicsTranslation(pediaPlortonomics);
            }

            public static void CreateResourcePedia(Identifiable.Id id, PediaDirector.Id entry, Sprite icon, string pediaTitle, string pediaIntro, string pediaResourceType, string pediaFavoredBy, string pediaDescription)
            {
                PediaRegistry.RegisterIdEntry(entry, icon);
                PediaRegistry.RegisterIdentifiableMapping((PediaDirector.Id)2, id);
                PediaRegistry.RegisterIdentifiableMapping(entry, id);
                PediaRegistry.SetPediaCategory(entry, (PediaRegistry.PediaCategory)2);
                new SlimePediaEntryTranslation(entry).SetTitleTranslation(pediaTitle).SetIntroTranslation(pediaIntro);
                TranslationPatcher.AddPediaTranslation("m.resource_type." + entry.ToString().ToLower(), pediaResourceType);
                TranslationPatcher.AddPediaTranslation("m.favored_by." + entry.ToString().ToLower(), pediaFavoredBy);
                TranslationPatcher.AddPediaTranslation("m.desc." + entry.ToString().ToLower(), pediaDescription);
            }
        }
    }
}