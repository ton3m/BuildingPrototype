using UnityEngine;

namespace _Project.Code.Core.Motor.Movement
{
    public class RigidbodyMover
    {
        private readonly Rigidbody _rigidbody;
        private readonly float _speed;

        public RigidbodyMover(Rigidbody rigidbody, float speed)
        {
            _rigidbody = rigidbody;
            _speed = speed;
        }

        public void Move(Vector3 direction) =>
            _rigidbody.velocity = direction * _speed;

        public void Move(float x, float z) =>
            _rigidbody.velocity = new Vector3(x * _speed, _rigidbody.velocity.y, z * _speed);
    }
}