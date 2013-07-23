using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamasoft.Functional;

namespace Xamasoft
{
    public static class PatternMatching
    {
        public static PatternMatching<T, TResult> Match<T, TResult>(T arg)
        {
            return new PatternMatching<T, TResult>(arg);
        }
        public static PatternMatching<T1, T2, TResult> Match<T1, T2, TResult>(T1 arg1, T2 arg2)
        {
            return new PatternMatching<T1, T2, TResult>(arg1, arg2);
        }
    }
}
