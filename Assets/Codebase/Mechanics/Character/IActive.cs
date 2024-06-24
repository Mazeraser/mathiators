namespace Assets.Codebase.Mechanics.Character
{
    public interface IActive
    {
        public ILive FoundTarget(); //TODO: refactor(remove finding in scene)
    }
}