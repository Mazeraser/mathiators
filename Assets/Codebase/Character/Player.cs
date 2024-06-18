using Assets.Codebase.ExpressionGenerator;
using UnityEngine;

namespace Assets.Codebase.Character
{
    public sealed class Player : Character_abstraction, IActive
    {

        public override void Start()
        {
            base.Start();
            GameplayExpressionGenerator.RightAnswerEvent +=
                delegate {
                    Attack(_target); 
                };
            ChangeTarget();
        }

        public void ChangeTarget()
        {
            _target = GameObject.FindWithTag("Enemy").GetComponent<ILive>(); //TODO: potential bug - a few enemies can not be detected
        }
    }
}