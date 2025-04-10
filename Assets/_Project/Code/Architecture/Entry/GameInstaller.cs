using Zenject;

namespace _Project.Code.Architecture
{
    public class GameInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<ISceneLoader>().To<DefaultSceneLoader>().AsSingle();
            Container.Bind<ResourcesLoader>().AsSingle();

            Container.Bind<GameConfig>()
                .FromScriptableObjectResource(ResourcesPaths.GameConfigPath)
                .AsSingle();
            
            Container.Bind<CoroutinePerformer>()
                .FromComponentInNewPrefabResource(ResourcesPaths.CoroutinePerformerPath)
                .AsSingle();
            
            Container.Bind<LoadingCurtain>()
                .FromComponentInNewPrefabResource(ResourcesPaths.LoadingCurtainPath)
                .AsSingle();
        }
    }
}