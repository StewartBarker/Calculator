using Barker.Calculator.Core;
using System;

namespace Barker.Calculator.Model
{
    public class Calculator
    {
        private const string ErrorMessage = "ERROR";
        public string Result { get; set; } = "0";
        public string Expression { get; set; } = string.Empty;

        private bool resetResult = false;

        public void AddNumber(string number)
        {
            if (resetResult)
            {
                Expression = number;
            }
            else
            {
                Expression += number;
            }
            if (Result == "0" || Result == ErrorMessage)
            {
                Result = number;
                resetResult = false;
            }
            else
            {
                Result += number;
            }                    
        }

        public void Delete()
        {
            Result = "0";
            resetResult = true;
            Expression = string.Empty;
        }

        public void AddOperand(string calculatorOperator)
        {
            calculatorOperator = ValidatedOperand(calculatorOperator);
            Result = "0";
            Expression += $"{calculatorOperator}";
            resetResult = false;
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
                return EvaluatedExpression.ToString("0.######");                
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
                resetResult = true;
            }
        }
    }
}
