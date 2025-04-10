using UnityEngine;

namespace _Project.Code.Architecture
{
    [CreateAssetMenu(fileName = "GameConfig", menuName = "GameConfig")]
    public class GameConfig : ScriptableObject
    {
        [field: SerializeField] public string StartScene { get; private set; }
    }
}