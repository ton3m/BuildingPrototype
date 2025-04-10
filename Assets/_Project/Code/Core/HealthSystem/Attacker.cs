namespace _Project.Code.Core.HealthSystem
{
    public class Attacker : IAttacker
    {
        private readonly float _damage;

        public Attacker(float damage)
        {
            _damage = damage;
        }
        
        public void Attack(IHealth health) => health.TakeDamage(_damage); 
    }
    
    public interface IAttacker
    {
        void Attack(IHealth health);
    }
}