using Leopotam.Ecs;
using UnityEngine;

namespace NTC.Source.Code.Ecs
{
    sealed class GravitySystem :  IEcsRunSystem
    {
        private readonly EcsWorld _world = null;
        private readonly EcsFilter<MovablaComponent,GravityComponent> _movableFilter = null;

        public void Run()
        {
            foreach (var item in _movableFilter)
            {
               
                ref var movableComponent = ref _movableFilter.Get1(item);
                ref var gravityComponent = ref _movableFilter.Get2(item);
         

                ref var characterController = ref movableComponent._charactercontroller;
                ref var _velocity = ref gravityComponent.Gravity;
                var Velocity = new Vector3();
                Velocity.y += _velocity * Time.deltaTime;

                characterController.Move(Velocity * Time.deltaTime);
            }
        }
    }
}