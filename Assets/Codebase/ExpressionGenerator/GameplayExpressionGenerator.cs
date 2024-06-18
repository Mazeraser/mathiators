﻿using System;
using UnityEngine;
using org.matheval;

namespace Assets.Codebase.ExpressionGenerator
{
    public sealed class GameplayExpressionGenerator : MonoBehaviour
    {
        public static event Action RightAnswerEvent;
        public static event Action WrongAnswerEvent;

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

        private Expression _expression;

        private void Start()
        {
            _generator = new MathExpressionGenerator(_expressionMinLength,_expressionMaxLength,_minNumber,_maxNumber);

            GenerateNewExpression();
        }

        private void GenerateNewExpression()
        {
        again:
            var expression = _generator.GenerateExpression();
            _expression = new Expression(expression);
            if (_expression.Eval<double>() - _expression.Eval<int>() == 0)
                Debug.Log(expression + " = " + _expression.Eval<int>());
            else
                goto again;
        }

        public void CheckAnswer(string value)
        {
            Expression answer = new Expression(value);
            if (answer.Eval<int>() == _expression.Eval<int>())
                RightAnswerEvent?.Invoke();
            else
                WrongAnswerEvent?.Invoke();
            GenerateNewExpression();
        }
    }
}