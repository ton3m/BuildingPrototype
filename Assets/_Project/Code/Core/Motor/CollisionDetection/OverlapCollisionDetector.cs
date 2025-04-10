using UnityEngine;

namespace _Project.Code.Core.Motor.Movement
{
    public class OverlapCollisionDetector : IComponentCollisionDetector
    {
        private readonly Transform _point;
        private readonly float _radius;
        private readonly LayerMask _layerMask;

        private readonly Collider[] _colliders = new Collider[10];

        public OverlapCollisionDetector(Transform point, float radius, LayerMask layerMask)
        {
            _point = point;
            _radius = radius;
            _layerMask = layerMask;
        }

        public Collider[] GetCollidingObjects()
        {
            Physics.OverlapSphereNonAlloc(_point.position, _radius, _colliders, _layerMask);
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