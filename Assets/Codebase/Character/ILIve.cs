namespace Assets.Codebase.Character
{
    public interface ILive
    {
        int HP { get; set; }
        void TakeDamage(int damage);
        bool IsDead();

        int PermanentShield { get; }
    }
}