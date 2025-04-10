using System.Collections;
using UnityEngine;
using Zenject;

namespace _Project.Code.Architecture
{
    public class GameEntry : MonoBehaviour
    {
        [Inject] private ISceneLoader _sceneLoader;
        [Inject] private LoadingCurtain _loadingCurtain;
        [Inject] private CoroutinePerformer _coroutinePerformer;
        [Inject] private GameConfig _gameConfig;

        private void Awake() => _coroutinePerformer.StartPerform(Bootstrap());

        private IEnumerator Bootstrap()
        {
            yield return _loadingCurtain.Show();
            yield return _sceneLoader.LoadAsync(_gameConfig.StartScene);
            yield return _loadingCurtain.Hide();
        }
    }
}