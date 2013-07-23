using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Xamasoft.Functional;

namespace Xamasoft.Functional.Sandbox
{
    class Program
    {
        static void Main(string[] args)
        {

            Expression<Func<int, int>> expr = x => x + 1;

            //var str = PatternMatching.Match<Expression, int, string>(expr, 1)
            //    .With<LambdaExpression, int>((lambda, num) => lambda.Parameters.Take(num).ToString(), (lambda, num) => num > 0)
            //    .WithActivePattern((e, i) =>
            //    {
            //        return PatternMatching.Match<Expression, int, Tuple<MethodInfo, int>>(e, i)
            //            .WithActivePattern((ee, ii) => MethodCallWithName(ee, "Where"))
            //            .SelectResult<string>(x => x.Item1.Name.ToUpper());
            //    })
            //    .Result();

        }

        //public static Maybe<Tuple<MethodInfo, int>> MethodCallWithName(Expression expr, string name)
        //{
        //    return PatternMatching.Match<Expression, Tuple<MethodInfo, int>>(expr)
        //        .With<MethodCallExpression>(x => Tuple.Create(x.Method, x.Arguments.Count), x => x.Method.Name == name)
        //        .Else(x => null)
        //        .Result();
        //}

    }


}
