using Leopotam.Ecs;
using System;
using UnityEngine;

namespace ShooterRange.Shotgun
{
    [Serializable]
    public struct ShotgunTag : IEcsIgnoreInFilter { }

    [Serializable]
    public struct ShotgunTransform
    {
        public Transform value;
    }

    [Serializable]
    public struct RotationSpeed
    {
        public float value;
    }

    [Serializable]
    public struct WeaponHolderTransform
    {
        public Transform value;
    }

    [Serializable]
    public struct WeaponSway
    {
        public float smooth;
        public float multiplier;
    }

    [Serializable]
    public struct MovementScreenSpeed
    {
        public float value;
    }
}