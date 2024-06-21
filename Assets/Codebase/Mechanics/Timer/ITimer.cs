namespace Assets.Codebase.Mechanics.Timer
{
    public interface ITimer
    {
        public float TimeRemaining { get; }
        public bool TimeHasGone { get; }

        public void UpdateTimer();
    }
}