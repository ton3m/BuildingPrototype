using System.Collections;
using UnityEngine;

namespace _Project.Code.Architecture
{
    public class CoroutinePerformer : MonoBehaviour
    {
        public Coroutine StartPerform(IEnumerator coroutineFunction)
            => StartCoroutine(coroutineFunction);

        public void StopPerform(Coroutine coroutine)
            => StopCoroutine(coroutine);
    }
}