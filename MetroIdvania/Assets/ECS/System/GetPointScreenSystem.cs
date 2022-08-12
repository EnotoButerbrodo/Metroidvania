using Leopotam.Ecs;
using UnityEngine;
using ECSMagicSystem;

sealed class GetPointScreenSystem : IEcsRunSystem
{
    private readonly EcsWorld _world = null;
    private readonly EcsFilter<MagicCreatingInputComponent, CameraComponent> _screenFilter = null;

    // Vector3 конечный поинт / камера / 
    public void Run()
    {
        foreach (var item in _screenFilter)
        {
            ref var inputComponent = ref _screenFilter.Get1(item);
            ref var cameraComponent = ref _screenFilter.Get2(item);

            ref var point = ref inputComponent.Pointer;
            ref var Camera = ref cameraComponent.Camera;



            var Ray = Camera.ViewportPointToRay(new Vector3(0.5f,0.5f,0));
            RaycastHit Hit;
            if(Physics.Raycast(Ray,out Hit))
            {
                 point = Hit.point;
            } else point = Ray.GetPoint(1000);
        }
    }
}
