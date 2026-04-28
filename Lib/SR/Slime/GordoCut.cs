using System.Collections.Generic;
using System.Linq;
using RichPresence;
using SRML.SR;
using SRML.SR.SaveSystem;
using UnityEngine;

namespace ShortcutLib.SR
{
    public static partial class SlimeCut
    {
        public static GameObject GetGordo(Identifiable.Id identifiable) => GameContext.Instance.LookupDirector.GetGordo(identifiable);

        // /// <summary>
        // /// Positions a gordo in the world based on the parent <see cref="Transform"/> and position <see cref="Vector3"/>.
        // /// </summary>
        // /// <param name="identifiable">The <see cref="Identifiable.Id"/> of the gordo.</param>
        // /// <param name="persistentId">The persistent id <see cref="string"/> of the gordo. This can be whatever you want but do not choose an existing ID, it is for saving.</param>
        // /// <param name="parent">The parent <see cref="Transform"/> that the gordo should be parented to.</param>
        // /// <param name="position">The position <see cref="Vector3"/> that the gordo should be positioned at.</param>
        // /// <param name="rotationAngle">The rotation angle <see cref="float"/> of the gordo to rotate in the correct direction. Leave 0 if not needed.</param>
        // /// <returns><see cref="GameObject"/></returns>
        // public static GameObject PositionGordo(Identifiable.Id identifiable, string persistentId, Transform parent,
        //     Vector3 position, float rotationAngle)
        // {
        //     GameObject instantiatedGordo =
        //         GetGordo(identifiable).InstantiateInactive(position, Quaternion.identity, parent, true);
        //     instantiatedGordo.transform.RotateAround(instantiatedGordo.transform.position,
        //         instantiatedGordo.transform.up, rotationAngle);
        //
        //     var gordoEat = instantiatedGordo.GetComponent<GordoEat>();
        //
        //     gordoEat.director = gordoEat.GetComponentInParent<IdDirector>();
        //     gordoEat.director.persistenceDict.Add(gordoEat, ModdedStringRegistry.ClaimID("gordo", persistentId));
        //
        //     instantiatedGordo.SetActive(true);
        //     return instantiatedGordo;
        // }
        //
        // public static GameObject CreateGordoBase(Identifiable.Id baseIdentifiable, Identifiable.Id identifiable,
        //     Identifiable.Id slimeIdentifiable, Sprite icon, string name, int feedCount, ZoneDirector.Zone[] nativeZones,
        //     List<GameObject> gordoRewards)
        // {
        //     GameObject prefab = GetGordo(baseIdentifiable).CreatePrefabCopy();
        //     prefab.name = "gordo" + name.Replace(" ", "").Replace("Gordo", "");
        //
        //     SlimeDefinition slimeDefinition = Shortcut.Slime.GetSlimeDefinition(slimeIdentifiable);
        //     Material slimeMaterial = slimeDefinition.AppearancesDefault[0].Structures[0].DefaultMaterials[0];
        //     SlimeFace slimeFace = slimeDefinition.AppearancesDefault[0].Face;
        //
        //     GordoFaceComponents gordoFace = prefab.GetComponent<GordoFaceComponents>();
        //     gordoFace.strainEyes = slimeFace.ExpressionFaces
        //         .First(x => x.SlimeExpression == SlimeFace.SlimeExpression.Scared).Eyes;
        //     gordoFace.strainMouth = slimeFace.ExpressionFaces
        //         .First(x => x.SlimeExpression == SlimeFace.SlimeExpression.ChompClosed).Mouth;
        //     gordoFace.blinkEyes = slimeFace.ExpressionFaces
        //         .First(x => x.SlimeExpression == SlimeFace.SlimeExpression.Blink).Eyes;
        //     gordoFace.chompOpenMouth = slimeFace.ExpressionFaces
        //         .First(x => x.SlimeExpression == SlimeFace.SlimeExpression.ChompOpen).Mouth;
        //     gordoFace.happyMouth = slimeFace.ExpressionFaces
        //         .First(x => x.SlimeExpression == SlimeFace.SlimeExpression.Happy).Mouth;
        //
        //     prefab.GetComponent<GordoEat>().slimeDefinition = slimeDefinition;
        //     prefab.GetComponent<GordoEat>().targetCount = feedCount;
        //     prefab.GetComponent<GordoRewards>().rewardPrefabs = gordoRewards.ToArray();
        //     prefab.GetComponent<GordoRewards>().slimePrefab = Shortcut.Prefab.GetPrefab(slimeIdentifiable);
        //     prefab.GetComponent<GordoIdentifiable>().id = identifiable;
        //     prefab.GetComponent<GordoIdentifiable>().nativeZones = nativeZones;
        //
        //     GordoDisplayOnMap displayOnMap = prefab.GetComponent<GordoDisplayOnMap>();
        //     GameObject markerPrefab = displayOnMap.markerPrefab.gameObject.CreatePrefabCopy();
        //     markerPrefab.name = "Gordo" + name.Replace(" ", "").Replace("Gordo", "") + "Marker";
        //     markerPrefab.GetComponent<Image>().sprite = icon;
        //
        //     displayOnMap.gordoEat = prefab.GetComponent<GordoEat>();
        //     displayOnMap.markerPrefab = markerPrefab.GetComponent<MapMarker>();
        //
        //     GameObject slime_gordo = prefab.transform.Find("Vibrating/slime_gordo").gameObject;
        //     slime_gordo.GetComponent<SkinnedMeshRenderer>().sharedMaterial = slimeMaterial;
        //
        //     Identifiable.GORDO_CLASS.Add(identifiable);
        //     Translate.Pedia("t." + identifiable.ToString().ToLower(), name);
        //     LookupRegistry.RegisterGordo(prefab);
        //     return prefab;
        // }
    }
}