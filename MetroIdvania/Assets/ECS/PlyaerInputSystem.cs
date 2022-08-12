using Leopotam.Ecs;
using UnityEngine;

namespace NTC.Source.Code.Ecs
{
    sealed class PlyaerInputSystem : IEcsRunSystem
    {
        private readonly EcsFilter<PlayerTag,DirectionComponent> _directionFiler = null;

        private float moveX;
        private float moveZ;
        public void Run()
        {
            SetDirection();
            foreach(var item in _directionFiler)
            {
                ref var directionComponent = ref _directionFiler.Get2(item);
              
                
                ref var direction = ref directionComponent.Direction;

                direction.x = moveX; 
                direction.z = moveZ; 
            }
        }


        private void SetDirection()
        {
            moveX = Input.GetAxis("Horizontal");
            moveZ = Input.GetAxis("Vertical");
        }
    }
}