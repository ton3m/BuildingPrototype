namespace _Project.Code.Core.Motor.Movement
{
    public interface IComponentCollisionDetector
    {
        bool IsColliding<T>(out T component);
    }
}