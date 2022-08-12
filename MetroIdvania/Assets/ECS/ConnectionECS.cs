using UnityEngine;
using Leopotam.Ecs;
using Voody.UniLeo;


namespace NTC.Source.Code.Ecs
{
    public sealed class ConnectionECS : MonoBehaviour
    {

        private EcsWorld _world;
        private  EcsSystems _systems;
    // Start is called before the first frame update
        void Start()
        {
            _world = new EcsWorld();
            _systems = new EcsSystems(_world);

            _systems.ConvertScene();

            AddInjections();
            AddOneFrames();
            AddSystems();
            _systems.Init();
        }


        private  void AddInjections()
        {

        }
        private void AddSystems()
        {
            _systems.
                    Add(new GetPointScreenSystem()).
                    Add(new CreatMagicSystem());
                    
        }

        private void AddOneFrames()
        {

        }


        void Update()
        {
            _systems.Run();
        }
        private void OnDestroy()
        {
            if(_systems == null) return;
            _systems.Destroy();
            _systems = null;
            _world.Destroy();
            _world = null;
        }
    }
}
