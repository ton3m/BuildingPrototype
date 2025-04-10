using UnityEngine;

namespace _Project.Code.Core.Motor.Movement
{
    public class OverlapCollisionDetector2D : IComponentCollisionDetector
    {
        private readonly Transform _point;
        private readonly float _radius;
        private readonly LayerMask _layerMask;

        private readonly Collider2D[] _colliders = new Collider2D[10];

        public OverlapCollisionDetector2D(Transform point, float radius, LayerMask layerMask)
        {
            _point = point;
            _radius = radius;
            _layerMask = layerMask;
        }

        public Collider2D[] GetCollidingObjects()
        {
            Physics2D.OverlapCircleNonAlloc(_point.position, _radius, _colliders, _layerMask);
            return _colliders;
        }
        
        public bool IsColliding<T>(out T component)
        {
            component = default;
            
            foreach (var collider in GetCollidingObjects())
            {
                if (collider && collider.TryGetComponent(out component))
                    return true;
            }

            return false;
        }
    }
}