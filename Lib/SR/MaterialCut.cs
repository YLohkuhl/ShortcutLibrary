using System.Collections.Generic;
using ShortcutLib.Utils.Extensions;
using UnityEngine;
// ReSharper disable ShaderLabShaderReferenceNotResolved

namespace ShortcutLib.SR
{
    public static class MaterialCut
    {
        private static readonly int PrimaryTex = Shader.PropertyToID("_PrimaryTex");

        public static void CreateBasicMaterial(string name, Texture2D texture, out Material material)
        {
            material = new Material(Shader.Find("SR/Paintlight/Basic"))
            {
                name = name
            };
            material.SetTexture(PrimaryTex, texture);
        }

        public static void CreateBaseSlimeMaterial(Identifiable.Id baseId, SlimeAppearance.AppearanceSaveSet saveSet,
            out Material material, Dictionary<string, object> properties = null)
        {
            material = baseId.GetSlimeDefinition().GetSlimeAppearance(saveSet).Structures[0].DefaultMaterials[0];
            if (properties != null)
                material.SetProperties(properties);
        }
    }
}