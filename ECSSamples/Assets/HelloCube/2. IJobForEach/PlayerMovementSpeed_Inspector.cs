using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;

[RequiresEntityConversion]
public class PlayerMovementSpeed_Inspector : MonoBehaviour, IConvertGameObjectToEntity
{
    [SerializeField] private float speed = 10f;

    public void Convert(Entity entity, EntityManager dstManager, GameObjectConversionSystem conversionSystem)
    {
        var data = new PlayerMovementSpeed { Speed = speed };
        dstManager.AddComponentData(entity, data);
    }
}
