using System;
using ShortcutLib.Utils.Extensions;
using UnityEngine;

namespace ShortcutLib.SR
{
    public static class MeshCut
    {
        /// <summary>
        /// Creates a mesh <see cref="GameObject"/> using a <see cref="MeshFilter"/>.
        /// </summary>
        /// <param name="mesh"></param>
        /// <param name="name"></param>
        /// <returns><see cref="GameObject"/></returns>
        public static GameObject CreateObject(Mesh mesh, string name)
        {
            var obj = new GameObject(name);
            obj.Prefabitize();
            obj.AddComponent<MeshFilter>().sharedMesh = mesh;
            obj.AddComponent<MeshRenderer>();
            return obj;
        }

        public static GameObject CreateObject(Mesh mesh, string name, Type collider)
        {
            var obj = CreateObject(mesh, name);
            obj.AddComponent(collider);
            return obj;
        }

        public static GameObject CreateObject(Mesh mesh, string name, Type collider, Vector3 size)
        {
            var obj = CreateObject(mesh, name, collider);
            obj.transform.localScale = size;
            return obj;
        }

        public static GameObject CreateObject(Mesh mesh, string name, Type collider, int layer)
        {
            var obj = CreateObject(mesh, name, collider);
            obj.SetLayerMask(layer);
            return obj;
        }

        public static GameObject CreateObject(Mesh mesh, string name, Type collider, string layerName)
        {
            var obj = CreateObject(mesh, name, collider);
            obj.SetLayerMask(layerName);
            return obj;
        }

        /// <summary>
        /// Creates a mesh <see cref="GameObject"/> using a <see cref="SkinnedMeshRenderer"/>.
        /// </summary>
        /// <param name="mesh"></param>
        /// <param name="name"></param>
        /// <returns><see cref="GameObject"/></returns>
        public static GameObject CreateSkinnedObject(Mesh mesh, string name)
        {
            var obj = new GameObject(name);
            obj.Prefabitize();
            obj.AddComponent<SkinnedMeshRenderer>().sharedMesh = mesh;
            return obj;
        }

        public static GameObject CreateSkinnedObject(Mesh mesh, string name, Type collider)
        {
            var obj = CreateSkinnedObject(mesh, name);
            obj.AddComponent(collider);
            return obj;
        }

        public static GameObject CreateSkinnedObject(Mesh mesh, string name, Type collider, Vector3 size)
        {
            var obj = CreateSkinnedObject(mesh, name, collider);
            obj.transform.localScale = size;
            return obj;
        }

        public static GameObject CreateSkinnedObject(Mesh mesh, string name, Type collider, int layer)
        {
            var obj = CreateSkinnedObject(mesh, name, collider);
            obj.SetLayerMask(layer);
            return obj;
        }

        public static GameObject CreateSkinnedObject(Mesh mesh, string name, Type collider, string layerName)
        {
            var obj = CreateSkinnedObject(mesh, name, collider);
            obj.SetLayerMask(layerName);
            return obj;
        }
    }
}