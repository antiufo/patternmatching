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

namespace Xamasoft
{
    public static partial class PatternMatching
    {
        public static PatternMatching<Tuple<T1, T2>, TRet> Tuple<T1, T2, TRet>(this PatternMatching<Tuple<T1, T2>, TRet> x, Func<T1, T2, TRet> action)
        {
            return x.With<Tuple<T1, T2>>(pair => action(pair.Item1, pair.Item2));
        }

        public static PatternMatching<Tuple<T1, T2, T3>, TRet> Tuple<T1, T2, T3, TRet>(this PatternMatching<Tuple<T1, T2, T3>, TRet> x, Func<T1, T2, T3, TRet> action)
        {
            return x.With<Tuple<T1, T2, T3>>(pair => action(pair.Item1, pair.Item2, pair.Item3));
        }

        public static PatternMatching<Maybe<T>, TRet> Some<T, TRet>(this PatternMatching<Maybe<T>, TRet> x, Func<T, TRet> f)
        {
            return x.With<Maybe<T>>(b => b.HasValue, b => f(Value(b)));
        }

        public static PatternMatching<Maybe<T>, TRet> Some<T, TRet>(this PatternMatching<Maybe<T>, TRet> x, T expected, Func<TRet> f)
        {
            return x.With<Maybe<T>>(b => b.HasValue && Value(b).Equals(expected), _ => f());
        }

        public static PatternMatching<Maybe<T>, TRet> None<T, TRet>(this PatternMatching<Maybe<T>, TRet> x, Func<TRet> f)
        {
            return x.With<Maybe<T>>(b => b.IsNone, b => f());
        }

        private static T Value<T>(Maybe<T> b)
        {
            return b.Value;
        }

        public static PatternMatching<T, TRet> Value<T, TRet>(this PatternMatching<T, TRet> x, T expected, Func<TRet> f)
        {
            return x.With<T>(b => Equals(expected, b), b => f());
        }

        public static PatternMatching<IEnumerable<T>, TRet> List<T, TRet>(this PatternMatching<IEnumerable<T>, TRet> x, Func<T, IEnumerable<T>, TRet> f)
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
