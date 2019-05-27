using Barker.Calculator.Core;
using System;

namespace Barker.Calculator.Model
{
    public class Calculator
    {
        private const string ErrorMessage = "ERROR";
        public string Result { get; set; } = "0";
        public string Expression { get; set; } = string.Empty;

        public void AddNumber(string number)
        {
            if (Result == "0" || Result == ErrorMessage)
            {
                Result = number;
            }
            else
            {
                Result += number;
            }
            Expression += $"{number}";
        }

        public void Delete()
        {
            Result = "0";
            Expression = string.Empty;
        }

        public void AddOperand(string calculatorOperator)
        {
            calculatorOperator = ValidatedOperand(calculatorOperator);
            Result = "0";
            Expression += $"{calculatorOperator}";
        }

        private string ValidatedOperand(string calculatorOperator)
        {
            if (calculatorOperator == "x")
                return "*";
            if (calculatorOperator == "÷")
                return "/";
            return calculatorOperator;
        }

        public string CalculateExpression()
        {            
            try
            {
                var EvaluatedExpression = Parser.Parse(Expression);
                Expression = EvaluatedExpression.ToString();
                return EvaluatedExpression.ToString();                
            }
            catch(ParserInvalidExpressionException ex)
            {
                // log ex
                Expression = string.Empty;                
                return ErrorMessage;                
            }
            finally
            {
                Result = "0";                
            }
        }
    }
}
