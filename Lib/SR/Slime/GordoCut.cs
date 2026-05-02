using System;
using System.Collections.Generic;
using System.Linq;
using RichPresence;
using ShortcutLib.Utils.Classes;
using ShortcutLib.Utils.Extensions;
using SRML.SR;
using SRML.SR.SaveSystem;
using UnityEngine;
using UnityEngine.UI;

namespace ShortcutLib.SR
{
    public static partial class SlimeCut
    {
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

        public static void CreateBaseGordo(Identifiable.Id baseId, Identifiable.Id id, string name, Sprite icon, BaseSlime baseSlime,
            ZoneDirector.Zone[] zones, GameObject[] rewards, out BaseGordo baseGordo, int feedCount = 30, Type[] behaviours = null,
            string persistentId = null)
        {
            // *** PREFAB *** \\

            var prefab = baseId.CopyPrefab();
            prefab.name = "gordo" + name.NoSpace().Replace("Gordo", "");

            var identifiable = prefab.GetComponent<GordoIdentifiable>();
            identifiable.id = id;
            identifiable.nativeZones = zones;

            var eat = prefab.GetComponent<GordoEat>();
            eat.slimeDefinition = baseSlime.Definition;
            eat.targetCount = feedCount;

            var rwd = prefab.GetComponent<GordoRewards>();
            rwd.rewardPrefabs = rewards;
            rwd.slimePrefab = baseSlime.Prefab;

            var displayOnMap = prefab.GetComponent<GordoDisplayOnMap>();
            var marker = displayOnMap.markerPrefab.gameObject.CopyPrefab();
            marker.name = "Gordo" + name.NoSpace().Replace("Gordo", "") + "Marker";
            marker.GetComponent<Image>().sprite = icon;

            displayOnMap.gordoEat = eat;
            displayOnMap.markerPrefab = marker.GetComponent<MapMarker>();

            if (behaviours != null)
                foreach (var behaviour in behaviours)
                    prefab.AddComponent(behaviour);
            
            // *** APPEARANCE *** \\

            var expressionFaces = baseSlime.Appearance.Face.ExpressionFaces;
            var face = prefab.GetComponent<GordoFaceComponents>();
            face.blinkEyes = expressionFaces.First(x => x.SlimeExpression == SlimeFace.SlimeExpression.Blink).Eyes;
            face.chompOpenMouth = expressionFaces.First(x => x.SlimeExpression == SlimeFace.SlimeExpression.ChompOpen).Mouth;
            face.happyMouth = expressionFaces.First(x => x.SlimeExpression == SlimeFace.SlimeExpression.Happy).Mouth;
            face.strainEyes = expressionFaces.First(x => x.SlimeExpression == SlimeFace.SlimeExpression.Scared).Eyes;
            face.strainMouth = expressionFaces.First(x => x.SlimeExpression == SlimeFace.SlimeExpression.ChompClosed).Mouth;

            prefab.transform.Find("Vibrating/slime_gordo").gameObject.GetComponent<SkinnedMeshRenderer>().sharedMaterial =
                baseSlime.Appearance.Structures[0].DefaultMaterials[0];

            // *** END *** \\

            Identifiable.GORDO_CLASS.Add(id);
            TranslationPatcher.AddPediaTranslation(TranslationCut.CreateKey("t", id.ToLower()), name);
            LookupRegistry.RegisterGordo(prefab);

            baseGordo = new BaseGordo(id, name, icon, baseSlime, prefab, rewards, zones, feedCount, behaviours, persistentId);
        }
    }
}