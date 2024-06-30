using Assets.Codebase.Mechanics.ExpressionGenerator;
using UnityEngine;

namespace Assets.Codebase.Mechanics.Character
{
    public sealed class Enemy : Character_abstraction
    {

        public override void Start()
        {
            base.Start();
            transform.position = new Vector3(5, -2, 0);
            GameplayExpressionGenerator.WrongAnswerEvent += Attack;
        }
        private void OnDestroy()
        {
            GameplayExpressionGenerator.WrongAnswerEvent -= Attack;
        }

        public override ILive FoundTarget()
        {
            return GameObject.FindWithTag("Player").GetComponent<ILive>();
        }
    }
}