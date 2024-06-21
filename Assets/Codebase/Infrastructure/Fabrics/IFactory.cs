using Assets.Codebase.Mechanics.Character;

namespace Assets.Codebase.Infrastructure.Fabrics
{
    public interface IFactory<T>
    {
        ILive CurrentEnemy { get; }
        T Create();
        void Remove();
    }
}