using System.Collections;
using _Project.Code.Core.HealthSystem;
using UnityEngine; 

namespace _Project.Code.Core
{
    public class Enemy : MonoBehaviour
    {
        private SkinnedMeshRenderer[] _skinnedMeshRenderers;
        private MeshRenderer[] _meshRenderers;
       
        [SerializeField] private int _healthValue = 3;

        private Health _health;
        
        public IHealth Health => _health;

        private void Awake()
        {
            _health = new Health(_healthValue, _healthValue);
            
            _skinnedMeshRenderers = GetComponentsInChildren<SkinnedMeshRenderer>();
            _meshRenderers = GetComponentsInChildren<MeshRenderer>();
        }

        public void TakeDamage(float damage)
        {
            _health.TakeDamage(damage);

            StartCoroutine(GetDamaged());

            if (_health.Value <= 0) Destroy(gameObject);
        }

        private IEnumerator GetDamaged()
        {
            foreach (var renderer in _skinnedMeshRenderers)
            {
                renderer.material.color = Color.red;
            }
        
            foreach (var renderer in _meshRenderers)
            {
                renderer.material.color = Color.red;
            }
        
            yield return new WaitForSeconds(0.1f);
        
            foreach (var renderer in _skinnedMeshRenderers)
            {
                renderer.material.color = Color.white;
            }
       
            foreach (var renderer in _meshRenderers)
            {
                renderer.material.color = Color.white;
            }
        }
    }
}