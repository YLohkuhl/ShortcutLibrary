// using SRML.SR.Utils;
// using SRML.Utils;
//
// namespace ShortcutLib.SR;
//
// public static class LiquidCut
// {
//     public static (LiquidDefinition, GameObject, Material) CreateLiquid(Identifiable.Id liquidPrefab, Identifiable.Id newLiquidID, string liquidName, Texture2D colorRamp, Color liquidColor, Color vacColor, Sprite liquidIcon)
//             {
//                 // PREFAB
//                 GameObject LiquidPrefab = PrefabUtils.CopyPrefab(SRSingleton<GameContext>.Instance.LookupDirector.GetPrefab(liquidPrefab));
//                 LiquidDefinition liquidDefinition = ScriptableObject.CreateInstance<LiquidDefinition>();
//                 GameObject liquidIncomingFX = Prefab.ObjectPrefab(SRSingleton<GameContext>.Instance.LookupDirector.GetLiquidIncomingFX(liquidPrefab));
//                 GameObject liquidVacFailFX = Prefab.ObjectPrefab(SRSingleton<GameContext>.Instance.LookupDirector.GetLiquidVacFailFX(liquidPrefab));
//
//                 LiquidPrefab.name = liquidName;
//                 LiquidPrefab.GetComponent<Identifiable>().id = newLiquidID;
//                 liquidDefinition.name = liquidName;
//
//                 // MATERIAL
//                 GameObject SpherePrefab = LiquidPrefab.FindChild("Sphere");
//                 MeshRenderer LiquidRenderer = SpherePrefab.GetComponent<MeshRenderer>();
//                 Material liquidMaterial = UnityEngine.Object.Instantiate(LiquidRenderer.sharedMaterial);
//                 liquidMaterial.name = liquidName;
//                 liquidMaterial.SetTexture("_ColorRamp", colorRamp);
//                 LiquidRenderer.sharedMaterial = liquidMaterial;
//
//                 // PARTICLE
//                 GameObject fxWaterSplat = Prefab.ObjectPrefab(Assets.LoadResource<GameObject>("FX waterSplat"));
//                 liquidIncomingFX.transform.Find("Water Glops").GetComponent<ParticleSystemRenderer>().sharedMaterial = LiquidPrefab.transform.Find("Sphere").GetComponent<MeshRenderer>().sharedMaterial;
//                 var SprinklerSystemMain = LiquidPrefab.transform.Find("Sphere").Find("FX Sprinkler 1").GetComponent<ParticleSystem>().main;
//                 var SprinklerSystemOvertime = LiquidPrefab.transform.Find("Sphere").Find("FX Sprinkler 1").GetComponent<ParticleSystem>().colorOverLifetime;
//                 SprinklerSystemMain.startColor = new ParticleSystem.MinMaxGradient(liquidColor);
//                 SprinklerSystemOvertime.color = new ParticleSystem.MinMaxGradient(liquidColor);
//
//                 LiquidPrefab.transform.Find("Sphere").Find("FX Water Glops").GetComponent<ParticleSystemRenderer>().sharedMaterial = LiquidPrefab.transform.Find("Sphere").GetComponent<MeshRenderer>().sharedMaterial;
//                 fxWaterSplat.transform.Find("Water Glops").GetComponent<ParticleSystemRenderer>().sharedMaterial = LiquidPrefab.transform.Find("Sphere").GetComponent<MeshRenderer>().sharedMaterial;
//
//                 var MainSystemMain = fxWaterSplat.GetComponent<ParticleSystem>().main;
//                 // var MainSystemMainOvertime = fxWaterSplat.GetComponent<ParticleSystem>().colorOverLifetime;
//
//                 var HitSystemMain = fxWaterSplat.transform.Find("Hit").GetComponent<ParticleSystem>().main;
//                 // var HitSystemOvertime = fxWaterSplat.transform.Find("Hit").GetComponent<ParticleSystem>().colorOverLifetime;
//
//                 var BubblesSystemMain = fxWaterSplat.transform.Find("Bubbles").GetComponent<ParticleSystem>().main;
//                 var BubblesSystemOvertime = fxWaterSplat.transform.Find("Bubbles").GetComponent<ParticleSystem>().colorOverLifetime;
//
//                 var SparklesSystemMain = fxWaterSplat.transform.Find("Sparkles").GetComponent<ParticleSystem>().main;
//                 // var SparklesSystemOvertime = fxWaterSplat.transform.Find("Sparkles").GetComponent<ParticleSystem>().colorOverLifetime;
//
//                 var WaveSystemMain = fxWaterSplat.transform.Find("Wave").GetComponent<ParticleSystem>().main;
//                 // var WaveSystemOvertime = fxWaterSplat.transform.Find("Wave").GetComponent<ParticleSystem>().colorOverLifetime;
//
//                 MainSystemMain.startColor = new ParticleSystem.MinMaxGradient(liquidColor, new Color(liquidColor.r, liquidColor.g, liquidColor.b, 0));
//                 // MainSystemMainOvertime.color = new ParticleSystem.MinMaxGradient(liquidColor, new Color(liquidColor.r, liquidColor.g, liquidColor.b, 0));
//
//                 HitSystemMain.startColor = new ParticleSystem.MinMaxGradient(liquidColor, new Color(liquidColor.r, liquidColor.g, liquidColor.b, 0));
//                 // HitSystemOvertime.color = new ParticleSystem.MinMaxGradient(liquidColor, new Color(liquidColor.r, liquidColor.g, liquidColor.b, 0));
//
//                 BubblesSystemMain.startColor = new ParticleSystem.MinMaxGradient(liquidColor, new Color(liquidColor.r, liquidColor.g, liquidColor.b, 0));
//                 BubblesSystemOvertime.color = new ParticleSystem.MinMaxGradient(liquidColor, new Color(liquidColor.r, liquidColor.g, liquidColor.b, 0));
//
//                 SparklesSystemMain.startColor = new ParticleSystem.MinMaxGradient(liquidColor, new Color(liquidColor.r, liquidColor.g, liquidColor.b, 0));
//                 // SparklesSystemOvertime.color = new ParticleSystem.MinMaxGradient(liquidColor, new Color(liquidColor.r, liquidColor.g, liquidColor.b, 0));
//
//                 WaveSystemMain.startColor = new ParticleSystem.MinMaxGradient(liquidColor, new Color(liquidColor.r, liquidColor.g, liquidColor.b, 0));
//                 // WaveSystemOvertime.color = new ParticleSystem.MinMaxGradient(liquidColor, new Color(liquidColor.r, liquidColor.g, liquidColor.b, 0));
//
//                 LiquidPrefab.GetComponent<DestroyOnTouching>().destroyFX = fxWaterSplat;
//
//                 // DEFINITION
//                 typeof(LiquidDefinition).GetField("id", BindingFlags.Instance | BindingFlags.NonPublic).SetValue(liquidDefinition, newLiquidID);
//                 typeof(LiquidDefinition).GetField("inFX", BindingFlags.Instance | BindingFlags.NonPublic).SetValue(liquidDefinition, liquidIncomingFX);
//                 typeof(LiquidDefinition).GetField("vacFailFX", BindingFlags.Instance | BindingFlags.NonPublic).SetValue(liquidDefinition, liquidVacFailFX);
//
//                 // REGISTER
//                 Identifiable.LIQUID_CLASS.Add(newLiquidID);
//                 Translate.TranslatePedia("t." + newLiquidID.ToString().ToLower(), liquidName);
//                 LookupRegistry.RegisterLiquid(liquidDefinition);
//                 LookupRegistry.RegisterIdentifiablePrefab(LiquidPrefab);
//                 LookupRegistry.RegisterVacEntry(newLiquidID, vacColor, liquidIcon);
//                 AmmoRegistry.RegisterPlayerAmmo(PlayerState.AmmoMode.DEFAULT, newLiquidID);
//
//                 return (liquidDefinition, LiquidPrefab, liquidMaterial);
//             }
//
//     public static GameObject CreateBaseFountain(Identifiable.Id id, string name, Transform parent, Vector3 position, string dictionaryName)
//     {
//         // OBJECT
//         GameObject ParentObject = GameObject.Find(parent);
//         GameObject FountainObject = GameObjectUtils.InstantiateInactive(GameObject.Find(fountainObject));
//         FountainObject.transform.parent = ParentObject.transform;
//         FountainObject.name = fountainName;
//         FountainObject.transform.position = position;
//
//         // LIQUID
//         LiquidSource componentInChildren = FountainObject.GetComponentInChildren<LiquidSource>();
//         componentInChildren.director = IdHandlerUtils.GlobalIdDirector;
//         componentInChildren.director.persistenceDict.Add(componentInChildren, dictionaryName);
//         componentInChildren.liquidId = liquidObject;
//         FountainObject.SetActive(true);
//
//         return FountainObject;
//     }
//
//             public static void ColorFountain(GameObject fountainObject, Color mainColor, Color mistColor, Color hitColor, Color dripsColor, Color waveColor, Color rippleColor, Color tinyDripsColor, Color glowColor, Color sparklesColor)
//             {
//                 PooledSceneParticle ParticlePrefab = fountainObject.GetComponentInChildren<PooledSceneParticle>();
//                 GameObject FountainParticle = Prefab.ObjectPrefab(ParticlePrefab.particlePrefab);
//
//                 var MainSystemMain = FountainParticle.GetComponent<ParticleSystem>().main;
//                 // var MainSystemMainOvertime = FountainParticle.GetComponent<ParticleSystem>().colorOverLifetime;
//
//                 var MistSystemMain = FountainParticle.transform.Find("Mist").GetComponent<ParticleSystem>().main;
//                 var MistSystemOvertime = FountainParticle.transform.Find("Mist").GetComponent<ParticleSystem>().colorOverLifetime;
//
//                 var HitSystemMain = FountainParticle.transform.Find("Hit").GetComponent<ParticleSystem>().main;
//                 // var HitSystemOvertime = FountainParticle.transform.Find("Hit").GetComponent<ParticleSystem>().colorOverLifetime;
//
//                 var DripsSystemMain = FountainParticle.transform.Find("Drips").GetComponent<ParticleSystem>().main;
//                 // var DripsSystemOvertime = FountainParticle.transform.Find("Drips").GetComponent<ParticleSystem>().colorOverLifetime;
//
//                 var WaveSystemMain = FountainParticle.transform.Find("Wave").GetComponent<ParticleSystem>().main;
//                 // var WaveSystemOvertime = FountainParticle.transform.Find("Wave").GetComponent<ParticleSystem>().colorOverLifetime;
//
//                 var RippleSystemMain = FountainParticle.transform.Find("Ripple").GetComponent<ParticleSystem>().main;
//                 // var RippleSystemOvertime = FountainParticle.transform.Find("Ripple").GetComponent<ParticleSystem>().colorOverLifetime;
//
//                 var TinyDripsSystemMain = FountainParticle.transform.Find("Tiny Drips").GetComponent<ParticleSystem>().main;
//                 var TinyDripsSystemOvertime = FountainParticle.transform.Find("Tiny Drips").GetComponent<ParticleSystem>().colorOverLifetime;
//
//                 var GlowSystemMain = FountainParticle.transform.Find("Glow").GetComponent<ParticleSystem>().main;
//                 // var GlowSystemOvertime = FountainParticle.transform.Find("Glow").GetComponent<ParticleSystem>().colorOverLifetime;
//
//                 var SparklesSystemMain = FountainParticle.transform.Find("Sparkles").GetComponent<ParticleSystem>().main;
//                 var SparklesSystemOvertime = FountainParticle.transform.Find("Sparkles").GetComponent<ParticleSystem>().colorOverLifetime;
//
//                 MainSystemMain.startColor = new ParticleSystem.MinMaxGradient(mainColor, new Color(mainColor.r, mainColor.g, mainColor.b, 0));
//                 // MainSystemMainOvertime.color = new ParticleSystem.MinMaxGradient(mainColor, new Color(mainColor.r, mainColor.g, mainColor.b, 0));
//
//                 MistSystemMain.startColor = new ParticleSystem.MinMaxGradient(mistColor, new Color(mistColor.r, mistColor.g, mistColor.b, 0));
//                 MistSystemOvertime.color = new ParticleSystem.MinMaxGradient(mistColor, new Color(mistColor.r, mistColor.g, mistColor.b, 0));
//
//                 HitSystemMain.startColor = new ParticleSystem.MinMaxGradient(hitColor, new Color(hitColor.r, hitColor.g, hitColor.b, 0));
//                 // HitSystemOvertime.color = new ParticleSystem.MinMaxGradient(hitColor, new Color(hitColor.r, hitColor.g, hitColor.b, 0));
//
//                 DripsSystemMain.startColor = new ParticleSystem.MinMaxGradient(dripsColor, new Color(dripsColor.r, dripsColor.g, dripsColor.b, 0));
//                 // DripsSystemOvertime.color = new ParticleSystem.MinMaxGradient(dripsColor, new Color(dripsColor.r, dripsColor.g, dripsColor.b, 0));
//
//                 WaveSystemMain.startColor = new ParticleSystem.MinMaxGradient(waveColor, new Color(waveColor.r, waveColor.g, waveColor.b, 0));
//                 // WaveSystemOvertime.color = new ParticleSystem.MinMaxGradient(waveColor, new Color(waveColor.r, waveColor.g, waveColor.b, 0));
//
//                 RippleSystemMain.startColor = new ParticleSystem.MinMaxGradient(rippleColor, new Color(rippleColor.r, rippleColor.g, rippleColor.b, 0));
//                 // RippleSystemOvertime.color = new ParticleSystem.MinMaxGradient(rippleColor, new Color(rippleColor.r, rippleColor.g, rippleColor.b, 0));
//
//                 TinyDripsSystemMain.startColor = new ParticleSystem.MinMaxGradient(tinyDripsColor, new Color(tinyDripsColor.r, tinyDripsColor.g, tinyDripsColor.b, 0));
//                 TinyDripsSystemOvertime.color = new ParticleSystem.MinMaxGradient(tinyDripsColor, new Color(tinyDripsColor.r, tinyDripsColor.g, tinyDripsColor.b, 0));
//
//                 GlowSystemMain.startColor = new ParticleSystem.MinMaxGradient(glowColor, new Color(glowColor.r, glowColor.g, glowColor.b, 0));
//                 // GlowSystemOvertime.color = new ParticleSystem.MinMaxGradient(glowColor, new Color(glowColor.r, glowColor.g, glowColor.b, 0));
//
//                 SparklesSystemMain.startColor = new ParticleSystem.MinMaxGradient(sparklesColor, new Color(sparklesColor.r, sparklesColor.g, sparklesColor.b, 0));
//                 SparklesSystemOvertime.color = new ParticleSystem.MinMaxGradient(sparklesColor, new Color(sparklesColor.r, sparklesColor.g, sparklesColor.b, 0));
//
//                 ParticlePrefab.particlePrefab = FountainParticle;
//             }
// }