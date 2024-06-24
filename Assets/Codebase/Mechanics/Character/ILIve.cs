namespace Assets.Codebase.Mechanics.Character
{
    public interface ILive
    {
        int MaxHP { get; }
        int CurrentHP {  get; set; }

        int PermanentShield { get; }

        void TakeDamage(int damage);
        bool IsDead();

    }
}