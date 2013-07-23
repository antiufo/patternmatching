#region License

/* ****************************************************************************
 * Copyright (c) Edmondo Pentangelo. 
 *
 * This source code is subject to terms and conditions of the Microsoft Public License. 
 * A copy of the license can be found in the License.html file at the root of this distribution. 
 * By using this source code in any fashion, you are agreeing to be bound by the terms of the 
 * Microsoft Public License.
 *
 * You must not remove this notice, or any other, from this software.
 * ***************************************************************************/

#endregion

using System;
using System.Collections.Generic;
using Xamasoft.Functional;

namespace Xamasoft
{
    public static class ActivePatterns
    {
        public static PatternMatching<Tuple<T1, T2>> Tuple<T1, T2, TRet>(this PatternMatching<Tuple<T1, T2>> x, Func<T1, T2, TRet> action)
        {
            return x.With<Tuple<T1, T2>>(pair => action(pair.Item1, pair.Item2));
        }

        public static PatternMatching<Tuple<T1, T2, T3>> Tuple<T1, T2, T3, TRet>(this PatternMatching<Tuple<T1, T2, T3>> x, Func<T1, T2, T3, TRet> action)
        {
            return x.With<Tuple<T1, T2, T3>>(pair => action(pair.Item1, pair.Item2, pair.Item3));
        }

        public static PatternMatching<Maybe<T>> Some<T>(this PatternMatching<Maybe<T>> x, Func<T, object> f)
        {
            return x.With<Maybe<T>>(b => b.HasValue, b => f(Value(b)));
        }

        public static PatternMatching<Maybe<T>> Some<T>(this PatternMatching<Maybe<T>> x, T expected, Func<object> f)
        {
            return x.With<Maybe<T>>(b => b.HasValue && Value(b).Equals(expected), _ => f());
        }

        public static PatternMatching<Maybe<T>> None<T>(this PatternMatching<Maybe<T>> x, Func<object> f)
        {
            return x.With<Maybe<T>>(b => b.IsNone, b => f());
        }

        private static T Value<T>(Maybe<T> b)
        {
            return b.Value;
        }

        public static PatternMatching<T> Value<T>(this PatternMatching<T> x, T expected, Func<object> f)
        {
            return x.With<T>(b => Equals(expected, b), b => f());
        }

        public static PatternMatching<IEnumerable<T>> List<T>(this PatternMatching<IEnumerable<T>> x, Func<T, IEnumerable<T>, object> f)
        {
            var head = default(T);
            IEnumerator<T> enumerator = null;
            return x.With<IEnumerable<T>>(b => !IsNotEmpty(b, out head, out enumerator), c => f(head, Tail(enumerator)));
        }

        private static bool IsNotEmpty<T>(IEnumerable<T> seq, out T head, out IEnumerator<T> enumerator)
        {
            enumerator = seq.GetEnumerator();
            if (enumerator.MoveNext())
            {
                head = enumerator.Current;
                return false;
            }
            head = default(T);
            return true;
        }

        private static IEnumerable<T> Tail<T>(IEnumerator<T> enumerator)
        {
            while (enumerator.MoveNext())
                yield return enumerator.Current;
        }
    }
}
