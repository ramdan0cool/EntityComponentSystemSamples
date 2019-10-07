using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Jobs;
using Unity.Transforms;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Burst;
using Unity.Collections;

public class PlayerMovementSystem : JobComponentSystem
{
    [BurstCompile]
    struct PlayerMovementJob : IJobForEach<Translation, PlayerMovementSpeed>
    {
        public Vector2 PlayerInput;
        public float DeltaTime;

        public void Execute(ref Translation c0, [ReadOnly] ref PlayerMovementSpeed c1)
        {
            float3 playerDest = new float3(PlayerInput.x * c1.Speed * DeltaTime, 0, PlayerInput.y * c1.Speed * DeltaTime);
            c0.Value = (c0.Value + playerDest);
        }
    }

    protected override JobHandle OnUpdate(JobHandle inputDeps)
    {
        var job = new PlayerMovementJob
        {
            DeltaTime = Time.deltaTime,
            PlayerInput = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"))
        };

        return job.Schedule(this, inputDeps);
    }
}
