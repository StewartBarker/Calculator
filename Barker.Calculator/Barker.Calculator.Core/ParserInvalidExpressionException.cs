using System;
using System.Runtime.Serialization;

namespace Barker.Calculator.Core
{
    [Serializable]
    internal class ParserInvalidExpressionException : Exception
    {
        public ParserInvalidExpressionException()
        {
        }

        public ParserInvalidExpressionException(string message) : base(message)
        {
        }

        public ParserInvalidExpressionException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected ParserInvalidExpressionException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}