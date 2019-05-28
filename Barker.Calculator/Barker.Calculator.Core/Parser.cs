namespace Barker.Calculator.Core
{
    using System;
    using System.IO;
    using System.Text.RegularExpressions;
    using System.Xml.XPath;

    public static class Parser
    {
        public static decimal Parse(string Expression)
        {          
            var xsltExpression =
            string.Format("number({0})",
                new Regex(@"([\+\-\*])").Replace(Expression, " ${1} ")
                                        .Replace("/", " div "));                                        
            return Convert.ToDecimal(new XPathDocument
                (new StringReader("<r/>"))
                    .CreateNavigator()
                    .Evaluate(xsltExpression));
        }
    }
}
