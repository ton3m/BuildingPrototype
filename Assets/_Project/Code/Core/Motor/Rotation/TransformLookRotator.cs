using UnityEngine;

namespace _Project.Code.Core.Motor.Rotation
{
    public class TransformLookRotator
    {
        private readonly Transform _transform;
        private readonly float _rotationSpeed;
        private readonly float _threshold;

        public TransformLookRotator(Transform transform, float rotationSpeed, float threshold = 0.1f)
        {
            _transform = transform;
            _rotationSpeed = rotationSpeed;
            _threshold = threshold;
        }

        public void Rotate(Vector3 to, float deltaTime)
        {
            if (to.magnitude < _threshold) return;

            Quaternion targetRotation = Quaternion.LookRotation(to);

            float delta = _rotationSpeed * deltaTime;
        
            _transform.rotation =
                Quaternion.RotateTowards(_transform.rotation, targetRotation, delta);
        }
    }
}