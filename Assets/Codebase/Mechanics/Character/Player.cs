using Assets.Codebase.Infrastructure;
using Assets.Codebase.Mechanics.ExpressionGenerator;
using UnityEngine;

namespace Assets.Codebase.Mechanics.Character
{
    public sealed class Player : Character_abstraction 
    {

        public override void Start()
        {
            base.Start();
            transform.position = new Vector3(-5, -2, 0);
            LoadCharacteristics();

            GameplayService.Balance_Points = 0;
            GameplayService.Balance_Points += MaxHP;
            GameplayService.Balance_Points += DP;
            GameplayService.Balance_Points += PermanentShield;
        }

        private void Awake()
        {
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