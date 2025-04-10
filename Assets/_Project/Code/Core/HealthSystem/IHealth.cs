namespace _Project.Code.Core.HealthSystem
{
    public interface IHealth 
    {
        float Value { get; }
        float MaxValue { get; }
        public void TakeDamage(float damage);

    }
}