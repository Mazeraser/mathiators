namespace Assets.Codebase.Character
{
    public interface ICharacter
    {
        int DP { get; set; }

        public void Attack(ILive target);
    }
}