using System;

namespace Assets.Codebase.Mechanics.ExpressionGenerator
{
    public interface IGenerator<T>
    {
        public T GenerateExpression();
    }
    public class MathExpressionGenerator: IGenerator<string>
    {
        private readonly Random _random;
        private readonly int _minLength;
        private readonly int _maxLength;

        public MathExpressionGenerator(int minLength, int maxLength)
        {
            _random = new Random();
            _minLength = minLength;
            _maxLength = maxLength;
        }

        public string GenerateExpression()
        {
            var expression = "";

            for(int i = 0; i < _random.Next(_minLength,_maxLength+1); i++) 
            {
                expression+=_random.Next(1,100);
                expression+=GetRandomOperation();
            }

            return expression.Substring(0,expression.Length-1);
        }

        private char GetRandomOperation()
        {
            var operations = new[] { '+', '-', '*', '/' };
            return operations[_random.Next(operations.Length)];
        }
    }
}