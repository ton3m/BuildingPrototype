using _Project.Code.Core.HealthSystem;
using _Project.Code.Core.Motor.Jumping;
using _Project.Code.Core.Motor.Movement;
using _Project.Code.Core.Motor.Movement._2D;
using _Project.Code.Core.Motor.Rotation;
using UnityEngine;
using UnityEngine.InputSystem;
using Zenject;

namespace _Project.Code.Core
{
    public interface IHeroMotor
    {
        void Move(Vector3 direction);
        void Rotate(Vector3 direction, float deltaTime);
        void Jump();
    }

    public class HeroMotor : IHeroMotor
    {
        private readonly Jumper _jumper;
        private readonly RigidbodyMover _mover;
        private readonly TransformLookRotator _rotator;
        private readonly GroundChecker _groundChecker;

        public HeroMotor(Rigidbody rigidbody, Transform groundCheckPoint, HeroConfig heroConfig)
        {
            _jumper = new Jumper(rigidbody, heroConfig.JumpSpeed);
            _mover = new RigidbodyMover(rigidbody, heroConfig.MoveSpeed);
            _rotator = new TransformLookRotator(rigidbody.transform, heroConfig.RotationSpeed);
            _groundChecker = new GroundChecker(groundCheckPoint);
        }

        public void Move(Vector3 direction) => _mover.Move(direction.x, direction.z);

        public void Rotate(Vector3 direction, float deltaTime) => _rotator.Rotate(direction, deltaTime);

        public void Jump()
        {
            if (_groundChecker.IsGrounded())
                _jumper.Jump();
        }
    }
    
    public interface IHeroAttacker
    {
        void Attack();
    }

    public class HeroAttacker : IHeroAttacker
    {
        private readonly Attacker _attacker;
        private readonly IComponentCollisionDetector _collisionDetector;

        public HeroAttacker(Transform attackPoint, float damage)
        {
            _attacker = new Attacker(damage);
            _collisionDetector = new OverlapCollisionDetector(attackPoint, 0.5f, ~0);
        }

        public void Attack()
        {
            if (_collisionDetector.IsColliding(out Enemy enemy))
                _attacker.Attack(enemy.Health);
        }
    }

    [System.Serializable]
    public class HeroConfig
    {
        public float JumpSpeed = 10;
        public float MoveSpeed = 10;
        public float RotationSpeed = 120;
        public float AttackDamage = 1;
    }
    
    [RequireComponent(typeof(Rigidbody))]
    public class Hero : MonoBehaviour
    {
        [SerializeField] private Transform _groundCheckPoint;
        [SerializeField] private Transform _attackPoint;
        [SerializeField] private HeroConfig _config;
        
        [Inject(Optional = true)] private IHeroMotor _heroMotor;
        [Inject(Optional = true)] private IHeroAttacker _heroAttacker;
        
        private HeroActions.PlayerActions _playerActions;

        private void Start()
        {
            _heroMotor ??= new HeroMotor(GetComponent<Rigidbody>(), _groundCheckPoint, _config);
            _heroAttacker ??= new HeroAttacker(_attackPoint, _config.AttackDamage);
            
            _playerActions = new HeroActions().Player;
            _playerActions.Enable();
        }

        private void Update()
        {
            var input = _playerActions.Move.ReadValue<Vector2>();
            var direction = new Vector3(input.x, 0, input.y);
            
            _heroMotor.Move(direction);
            _heroMotor.Rotate(direction, Time.deltaTime);

            if (_playerActions.Jump.triggered)
                _heroMotor.Jump();
            
            if (_playerActions.Attack.triggered)
                _heroAttacker.Attack();
        }
    }
}