using System;
using HarmonyLib;
using ShortcutLib.Utils.Classes;
using UnityEngine;

namespace ShortcutLib.SR
{
    public static partial class SlimeCut
    {
        public static SlimeAppearanceStructure GetStructure(this SlimeDefinition slimeDefinition, int index,
            SlimeAppearance.AppearanceSaveSet saveSet = SlimeAppearance.AppearanceSaveSet.CLASSIC) =>
            new(slimeDefinition.GetAppearanceForSet(saveSet).Structures[index]);

        public static void CreateStructureElement(string name, SlimeAppearanceObject[] prefabs, out SlimeAppearanceElement element)
        {
            element = ScriptableObject.CreateInstance<SlimeAppearanceElement>();
            element.name = name;
            element.Prefabs = prefabs;
        }
        
        public static void AddBaseStructure(BaseSlime baseSlime, BaseStructure baseStructure,
            SlimeAppearanceElement element,
            out SlimeAppearanceStructure structure, params Material[] materials)
        {
            structure = new SlimeAppearanceStructure(baseSlime.Appearance.Structures[0])
            {
                DefaultMaterials = materials,
                Element = element,
                SupportsFaces = baseStructure.SupportsFaces,
                FaceRules = baseStructure.FaceRules
            };
            baseSlime.Appearance.Structures = baseSlime.Appearance.Structures.AddToArray(structure);
        }

        public static void CreateBaseStructure(Mesh mesh, string name, RubberBoneEffect.RubberType rubberType,
            BaseStructure.Bones bones, out BaseStructure baseStructure, bool deformable = false,
            bool ignoreLODIndex = false, bool supportsFaces = false, SlimeFaceRules[] faceRules = null, Type[] behaviours = null)
        {
            var prefab =
                deformable ? MeshCut.CreateSkinnedObject(mesh, name) : MeshCut.CreateObject(mesh, name);
            prefab.Prefabitize();

            var appearanceObject = prefab.AddComponent<SlimeAppearanceObject>();
            appearanceObject.RubberType = rubberType;
            appearanceObject.RootBone = bones.Root;
            appearanceObject.ParentBone = bones.Parent;
            appearanceObject.AttachedBones = bones.Attached;
            appearanceObject.IgnoreLODIndex = ignoreLODIndex;
            appearanceObject.AttachRubberBoneEffect = deformable;

            if (behaviours != null)
                foreach (var behaviour in behaviours)
                    prefab.AddComponent(behaviour);

            baseStructure =
                new BaseStructure(mesh, prefab, appearanceObject, ignoreLODIndex, supportsFaces, faceRules, behaviours);
        }
    }
}