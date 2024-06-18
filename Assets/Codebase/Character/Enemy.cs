using Assets.Codebase.ExpressionGenerator;
using System.Collections;
using UnityEngine;

namespace Assets.Codebase.Character
{
    public sealed class Enemy : Character_abstraction, IActive
    {

        public override void Start()
        {
            base.Start();
            GameplayExpressionGenerator.WrongAnswerEvent +=
                delegate {
                    Attack(_target);
                };
            ChangeTarget();
        }

        public void ChangeTarget()
        {
            _target = GameObject.FindWithTag("Player").GetComponent<ILive>();
        }
    }
}