using System.Collections;
using UnityEngine.SceneManagement;

namespace _Project.Code.Architecture
{
    public interface ISceneLoader
    {
        IEnumerator LoadAsync(string sceneName, LoadSceneMode loadSceneMode = LoadSceneMode.Single);
        IEnumerator UnloadAsync(string sceneName);
    }
}