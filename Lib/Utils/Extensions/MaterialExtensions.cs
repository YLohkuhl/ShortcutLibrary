using System;
using System.Collections.Generic;
using System.Linq;
using ShortcutLib.Utils.Classes;
using UnityEngine;

namespace ShortcutLib.Utils.Extensions
{
    /// <summary>
    /// <see cref="Material"/>-oriented extensions for <see cref="ShortcutLib"/>.
    /// </summary>
    public static class MaterialExtensions
    {
        private static readonly int topColor = Shader.PropertyToID("_TopColor");
        private static readonly int middleColor = Shader.PropertyToID("_MiddleColor");
        private static readonly int bottomColor = Shader.PropertyToID("_BottomColor");

        /// <summary>
        /// Sets the <c>_TopColor</c> <c>_MiddleColor</c> <c>_BottomColor</c> properties of a material
        /// using <see cref="ColorPalette"/> properties.
        /// </summary>
        /// <param name="material">The <see cref="Material"/> to have it's properties set.</param>
        /// <param name="colorPalette">The <see cref="ColorPalette"/> to be utilized for obtaining the colors.</param>
        public static void SetColors(this Material material, ColorPalette colorPalette) => 
            material.SetColors(colorPalette.Top, colorPalette.Middle, colorPalette.Bottom);

        /// <summary>
        /// Sets the <c>_TopColor</c> <c>_MiddleColor</c> <c>_BottomColor</c> properties of a material.
        /// </summary>
        /// <param name="material">The <see cref="Material"/> to have it's properties set.</param>
        /// <param name="top">The <c>_TopColor</c> property of the material.</param>
        /// <param name="middle">The <c>_MiddleColor</c> property of a material.</param>
        /// <param name="bottom">The <c>_BottomColor</c> property of a material.</param>
        public static void SetColors(this Material material, Color top, Color middle, Color bottom)
        {
            material.SetColor(topColor, top);
            material.SetColor(middleColor, middle);
            material.SetColor(bottomColor, bottom);
        }

        public static void SetProperties(this Material material, Dictionary<string, object> properties)
        {
            foreach (var property in properties.Where(property => !property.Key.IsNullOrEmpty()))
            {
                switch (property.Value)
                {
                    case int value:
                    {
                        material.SetInt(property.Key, value);
                        break;
                    }
                    
                    case float value:
                    {
                        material.SetFloat(property.Key, value);
                        break;
                    }
                    
                    case Color value:
                    {
                        material.SetColor(property.Key, value);
                        break;
                    }
                    
                    case Texture2D value:
                    {
                        material.SetTexture(property.Key, value);
                        break;
                    }

                    case Vector4 value:
                    {
                        material.SetVector(property.Key, value);
                        break;
                    }
                    
                    case Matrix4x4 value:
                    {
                        material.SetMatrix(property.Key, value);
                        break;
                    }
                    
                    case ComputeBuffer value:
                    {
                        material.SetBuffer(property.Key, value);
                        break;
                    }
                    
                    case float[] value:
                    {
                        material.SetFloatArray(property.Key, value);
                        break;
                    }
                    
                    case Color[] value:
                    {
                        material.SetColorArray(property.Key, value);
                        break;
                    }
                    
                    case Vector4[] value:
                    {
                        material.SetVectorArray(property.Key, value);
                        break;
                    }
                    
                    case Matrix4x4[] value:
                    {
                        material.SetMatrixArray(property.Key, value);
                        break;
                    }
                }
            }
        }
    }
}