using Barker.Calculator.Core;
using System;

namespace Barker.Calculator.Model
{
    public class Calculator
    {
        public string Result { get; set; } = "0";
        public string Expression { get; set; } = string.Empty;

        public void AddNumber(string number)
        {
            if (Result == "0")
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
            Result = "0";
            Expression += $"{calculatorOperator}";
        }

        public string CalculateExpression()
        {            
            try
            {
                var EvaluatedExpression = Parser.Parse(Expression);
                return EvaluatedExpression.ToString();
                
            }
            catch(ParserInvalidExpressionException ex)
            {
                // log ex
                return "ERROR";                
            }
            finally
            {
                Result = "0";
                Expression = string.Empty;
            }
        }
    }
}
