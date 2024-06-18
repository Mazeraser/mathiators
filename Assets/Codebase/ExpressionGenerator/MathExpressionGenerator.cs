using System;

namespace Assets.Codebase.ExpressionGenerator
{
    public interface IGenerator<T>
    {
        public T GenerateExpression();
    }
    public class MathExpressionGenerator: IGenerator<string>
    {
        private readonly Random _random;
        private readonly int _minNum;
        private readonly int _maxNum;
        private readonly int _minLength;
        private readonly int _maxLength;

        public MathExpressionGenerator(int minLength, int maxLength, int minNum, int maxNum)
        {
            _random = new Random();
            _minLength = minLength;
            _maxLength = maxLength;
            _minNum = minNum;
            _maxNum = maxNum;
        }

        public string GenerateExpression()
        {
            var expression = "";

            for(int i = 0; i < _random.Next(_minLength,_maxLength+1); i++) 
            {
                expression+=_random.Next(_minNum,_maxNum);
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