using System;

namespace _Project.Code.Core.HealthSystem
{
    public class Health : IHealth
    {
        public float Value { get; private set; }
        public float MaxValue { get; private set; }

        public Health(float value, float maxValue)
        {
            Value = value;
            MaxValue = maxValue;
        }

        public void TakeDamage(float damage)
        {
            if (damage < 0) 
                throw new ArgumentException("Damage must be positive");
        
            Value -= damage;
        
            if (Value < 0) Value = 0;
        }
    }
}