using UnityEngine;

namespace _Project.Code.Core.Motor.Movement._2D
{
    public class GroundChecker 
    {
        private readonly Transform _groundCheckPoint;
        private readonly float _rayLength = 0.1f;

        public GroundChecker(Transform groundCheckPoint)
        {
            _groundCheckPoint = groundCheckPoint;
        }

        public bool IsGrounded() => 
            Physics.Raycast(_groundCheckPoint.position, Vector3.down, _rayLength);
    }
}