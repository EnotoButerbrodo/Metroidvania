using Leopotam.Ecs;
using ECSMagicSystem;
using UnityEngine;

sealed class CreatMagicSystem : IEcsRunSystem
{
    private readonly EcsWorld _world = null;
    private readonly EcsFilter<MagicCreatingInputComponent,MagicComponent,SpeedMagicComponent,MagicCreationPoint,ReloadedComponent> _creatFilter = null;
    private float _timeRelouded = 1;
    public void Run()
    {
        foreach (var item in _creatFilter)
        {
            ref var inputPointer = ref _creatFilter.Get1(item);
            ref var magicComponent = ref _creatFilter.Get2(item);
            ref var speedComponent = ref _creatFilter.Get3(item);
            ref var creatComponent = ref _creatFilter.Get4(item);
            ref var relodedComponent = ref _creatFilter.Get5(item);


            if(Input.GetAxis("Fire1") == 1)
            {
                if(_timeRelouded >= relodedComponent.ReloadedTime)
                {
                    var bullet = Object.Instantiate(magicComponent.Magic, creatComponent.CreatPoint.position, Quaternion.identity);
                    bullet.gameObject.GetComponent<Rigidbody>().velocity = (inputPointer.Pointer - creatComponent.CreatPoint.position).normalized * speedComponent.Speed;
                    _timeRelouded = 0;
                }
            } else  _timeRelouded += Time.deltaTime;
        }
    }
}
