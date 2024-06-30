using UnityEngine;

namespace Assets.Codebase.Mechanics.Difficulty
{
    [CreateAssetMenu(menuName ="Create difficulty", fileName = "new Difficulty")]
    public class DifficultyAbsctraction : ScriptableObject
    {
        [Range(2,10)]
        public int MinimalExpressionLength;
        [Range(2,10)]
        public int MaximalExpressionLength;
        [Range(1,1000)]
        public int MinimalNumber;
        [Range(1,1000)]
        public int MaximumNumber;
        [Range(4,60)]
        public float DecideTime;
    }
}