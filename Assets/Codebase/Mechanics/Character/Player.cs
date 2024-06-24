using Assets.Codebase.Mechanics.ExpressionGenerator;
using UnityEngine;

namespace Assets.Codebase.Mechanics.Character
{
    public sealed class Player : Character_abstraction 
    { 
        public override void Start()
        {
            base.Start();
            GameplayExpressionGenerator.RightAnswerEvent += Attack;
        }
        private void OnDestroy()
        {
            GameplayExpressionGenerator.RightAnswerEvent -= Attack;
        }

        public override ILive FoundTarget()
        {
            return GameObject.FindWithTag("Enemy").GetComponent<ILive>(); //TODO: potential bug - a few enemies can not be detected
        }
    }
}