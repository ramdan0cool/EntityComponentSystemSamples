using System;
using Unity.Entities;

[Serializable]
public struct PlayerMovementSpeed : IComponentData
{
    public float Speed;
}
