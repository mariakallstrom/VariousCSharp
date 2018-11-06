using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace CodeWars
{
    class Evaluator
    {
        public static double Evaluate(string expression)
        {
            expression = Regex.Replace(expression, @"\s+", "");
            DataTable dt = new DataTable();
            var result = dt.Compute(expression, "");
            return Math.Round(Convert.ToDouble(result), 6);
             
        }

        //private static double Calculate(string expression)
        //{
        //    expression = Regex.Replace(expression, @"\s+", "");
        //    var opPattern = @"(\+|\-|\/|\*)";
        //    var exp = expression.ToList();
        //    double sum = 0.0;
          
        //        if(Regex.IsMatch(expression, @"^-?\d*\,{0,1}\d+$"))
        //        {
        //            return Convert.ToDouble(expression);
        //        }
                
        //        if (expression.Contains("("))
        //        {
        //            int startIndex = expression.IndexOf('(');
        //            int endIndex = expression.IndexOf(')');
        //            var length = endIndex - startIndex -1;
        //            var result = expression.Substring(startIndex +1, length);

        //            var temp = expression.Remove(startIndex, 1).Insert(startIndex, " ");
        //            expression = temp.Remove(endIndex, 1).Insert( endIndex, " ");

        //            var opMatch = Regex.Match(result, opPattern);
        //            var op = opMatch.Value;

                    
        //            var x = Convert.ToDouble(result.Substring(0, opMatch.Index).Trim());
        //            var y = Convert.ToDouble(result.Substring(opMatch.Index +1).Trim());

        //            if (op == "+") sum = Add(x, y);
        //            if (op == "-") sum = Substract(x, y);
        //            if (op == "*") sum = Multiply(x, y);
        //            if (op == "/") sum = Divide(x, y);

        //            expression = expression.Replace(result, sum.ToString());
        //            Calculate(expression);
        //        }
        //        if (expression.Contains("*"))
        //        {
        //            //2/5*4-6
        //            var result = Regex.Match(expression, @"-?\d*\,{0,1}\d+\*-?\d*\,{0,1}\d+").ToString();
        //            var opMatch = Regex.Match(result, opPattern);
        //            var x = Convert.ToDouble(result.Substring(0, opMatch.Index).Trim());
        //            var y = Convert.ToDouble(result.Substring(opMatch.Index + 1).Trim());
        //            sum = Multiply(x, y);
        //            expression = expression.Replace(result, sum.ToString());
        //            Calculate(expression);
        //         }
        //        if (expression.Contains("/"))
        //        {
        //            var result = Regex.Match(expression, @"-?\d*\,{0,1}\d+\/-?\d*\,{0,1}\d+").ToString();
        //            var opMatch = Regex.Match(result, opPattern);
        //            var x = Convert.ToDouble(result.Substring(0, opMatch.Index).Trim());
        //            var y = Convert.ToDouble(result.Substring(opMatch.Index + 1).Trim());
        //            sum = Divide(x, y);
        //            expression = expression.Replace(result, sum.ToString());
        //            Calculate(expression);
        //        }
        //        if (expression.Contains("+"))
        //        {
        //            var result = Regex.Match(expression, @"-?\d*\,{0,1}\d+\+-?\d*\,{0,1}\d+").ToString();
        //            var opMatch = Regex.Match(result, opPattern);
        //            var x = Convert.ToDouble(result.Substring(0, opMatch.Index).Trim());
        //            var y = Convert.ToDouble(result.Substring(opMatch.Index + 1).Trim());
        //            sum = Add(x, y);
        //            expression = expression.Replace(result, sum.ToString());
        //            Calculate(expression);
        //        }
        //        if (expression.Contains("-"))
        //        {
        //            var result = Regex.Match(expression, @"-?\d*\,{0,1}\d+\--?\d*\,{0,1}\d+").ToString();
        //            var opMatch = Regex.Match(result, opPattern);
        //            var x = result.Substring(0, opMatch.Index).Trim();
        //            var y = Convert.ToDouble(result.Substring(opMatch.Index + 1).Trim());
        //            sum = Substract(Convert.ToDouble(x), y);
        //            expression = expression.Replace(result, sum.ToString());
        //            Calculate(expression);
        //        }

        //    return Convert.ToDouble(expression);
        //}

        //private static double Add(double x, double y)
        //{
        //    return x + y;
        //}
        //private static double Substract(double x, double y)
        //{
        //    return x - y;
        //}
        //private static double Multiply(double x, double y)
        //{
        //    return x * y;
        //}
        //private static double Divide(double x, double y)
        //{
        //    return x / y;
        //}

    }
}
