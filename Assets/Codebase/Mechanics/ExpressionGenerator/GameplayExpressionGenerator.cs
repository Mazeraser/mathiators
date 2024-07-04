using System;
using UnityEngine;
using Assets.Codebase.Infrastructure;
using System.Data;

namespace Assets.Codebase.Mechanics.ExpressionGenerator
{
    public sealed class GameplayExpressionGenerator : MonoBehaviour
    {
        public static event Action RightAnswerEvent;
        public static event Action WrongAnswerEvent;
        public static event Action<string> ExpressionGeneratedEvent;

        private MathExpressionGenerator _generator;

        [SerializeField]
        [Range(2,10)]
        private int _expressionMinLength;
        [SerializeField]
        [Range(2,10)]
        private int _expressionMaxLength;
        [SerializeField]
        private int _minNumber;
        [SerializeField]
        private int _maxNumber;

        private int _expression;

        private void Start()
        {
            if(PlayerPrefs.HasKey("Minimal number"))
            {
                _expressionMinLength = PlayerPrefs.GetInt("Minimal expression length");
                _expressionMaxLength = PlayerPrefs.GetInt("Maximum expression length");
                _minNumber = PlayerPrefs.GetInt("Minimal number");
                _maxNumber = PlayerPrefs.GetInt("Maximum number");
            }

            _generator = new MathExpressionGenerator(_expressionMinLength,_expressionMaxLength);

            GenerateNewExpression();
        }
        private void Awake()
        {
            GameplayService.UpdateExpressionEvent += CheckAnswer;
        }
        private void OnDestroy()
        {
            GameplayService.UpdateExpressionEvent -= CheckAnswer;
        }

        private void GenerateNewExpression()
        {
        again:
            var expression = _generator.GenerateExpression();
            _expression = Convert.ToInt32(new DataTable().Compute(expression,null));
            if (
                Convert.ToDouble(new DataTable().Compute(expression, null)) - Convert.ToInt32(new DataTable().Compute(expression, null)) == 0
                && (_expression>=_minNumber&& _expression<=_maxNumber)
                )
                ExpressionGeneratedEvent?.Invoke(expression);
            else
                goto again;
        }

        public void CheckAnswer(string value)
        {
            if (Convert.ToInt32(new DataTable().Compute(value, null)) == _expression)
                RightAnswerEvent?.Invoke();
            else
                WrongAnswerEvent?.Invoke();
            GenerateNewExpression();
        }
    }
}