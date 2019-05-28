namespace Barker.Calculator.Core
{
    using Microsoft.CodeAnalysis.CSharp.Scripting;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text.RegularExpressions;
    using System.Xml.XPath;

    public static class Parser
    {
        public static decimal Parse(string Expression)
        {
            //return Convert.ToDecimal(CSharpScript.EvaluateAsync(Expression).Result);

            var xsltExpression =
            string.Format("number({0})",
                new Regex(@"([\+\-\*])").Replace(Expression, " ${1} ")
                                        .Replace("/", " div ")
                                        .Replace("%", " mod "));
            return Convert.ToDecimal(new XPathDocument
                (new StringReader("<r/>"))
                    .CreateNavigator()
                    .Evaluate(xsltExpression));
        }
    }
}
