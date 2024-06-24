using Assets.Codebase.Mechanics.ExpressionGenerator;
using System.Collections;
using UnityEditor;
using UnityEngine;

namespace Assets.Codebase.Mechanics.Character
{
    public sealed class Enemy : Character_abstraction
    {

        public override void Start()
        {
            base.Start();
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