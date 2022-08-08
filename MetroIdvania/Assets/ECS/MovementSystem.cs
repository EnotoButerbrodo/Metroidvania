using Leopotam.Ecs;
using UnityEngine;

namespace NTC.Source.Code.Ecs
{
    sealed class MovementSystem :  IEcsRunSystem
    {
        private readonly EcsWorld _world = null;
        private readonly EcsFilter<ModelComponent,MovablaComponent,DirectionComponent> _movableFilter = null;

        public void Run()
        {
            foreach (var item in _movableFilter)
            {
                ref var modelComponent = ref _movableFilter.Get1(item);
                ref var movableComponent = ref _movableFilter.Get2(item);
                ref var directionComponent = ref _movableFilter.Get3(item);
               // ref var gravityComponent = ref _movableFilter.Get4(item);
 
                ref var direction = ref directionComponent.Direction;
                ref var transfrom = ref modelComponent.ModelTransfrom;

                ref var characterController = ref movableComponent._charactercontroller;
                ref var speed = ref movableComponent.Speed;
              //  ref var _velocity = ref gravityComponent.velocity;
              //  var Velocity = new Vector3();
               // Velocity.y += -9.81f * Time.deltaTime;


                var rawDirection = 
                (transfrom.right * direction.x) + (transfrom.forward * direction.z);

                characterController.Move(rawDirection * speed* Time.deltaTime);

              //  characterController.Move(Velocity * Time.deltaTime);
            }
        }
    }
}