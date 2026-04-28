using UnityEngine;

namespace ShortcutLib.Utils.Structs
{
    public struct VectorQuaternion
    {
        public VectorQuaternion(
            Vector3 pos,
            Quaternion rot)
        {
            Position = pos;
            Rotation = rot;
        }

        public Vector3 Position { get; }
        public Quaternion Rotation { get; }
    }
}