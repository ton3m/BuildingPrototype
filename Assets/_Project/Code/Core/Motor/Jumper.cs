using UnityEngine;

namespace _Project.Code.Core.Motor.Jumping
{
    public class Jumper
    {
        private readonly Rigidbody _rigidbody;
        private readonly float _jumpVelocity;

        public Jumper(Rigidbody rigidbody, float jumpVelocity)
        {
            _rigidbody = rigidbody;
            _jumpVelocity = jumpVelocity;
        }

        public void Jump()
        {
            var velocity = _rigidbody.velocity;

            velocity.y = _jumpVelocity;
            
            _rigidbody.velocity = velocity;
        }
    }
}