using Assets.Codebase.Mechanics.Character;

namespace Assets.Codebase.Infrastructure.Fabrics
{
    public interface IFactory<T>
    {
        T Create();
        void Remove();
    }
}