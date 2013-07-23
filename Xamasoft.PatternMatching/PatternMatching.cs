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

namespace Xamasoft
{


    public static partial class PatternMatching
    {
        public static UntypedPatternMatching<T> Match<T>(this T obj)
        {
            return new UntypedPatternMatching<T>() { OriginalValue = obj };
        }

        public static PatternMatching<T, TResult> Default<T, TResult>(this PatternMatching<T, TResult> x, Func<T, TResult> f)
        {
            return x.With<T>(b => f(b));
        }

        public struct UntypedPatternMatching<T>
        {
            internal T OriginalValue;
            public PatternMatching<T, TResult> Returning<TResult>()
            {
                var val = OriginalValue;
                return new PatternMatching<T, TResult>(() => new PatternMatching<T, TResult>.Match() { OriginalValue = val });
            }
        }
    }

    public struct PatternMatching<T, TResult>
    {

        internal struct Match
        {
            public T OriginalValue;
            public TResult Value;
            public bool Success;
        }

        private readonly Func<Match> _f;

        internal PatternMatching(Func<Match> f)
        {
            _f = f;
        }

        public PatternMatching<T, TResult> With<TSubType>(Func<TSubType, TResult> f)
        {
            return With(null, f);
        }

        public PatternMatching<T, TResult> With<TSubType>(Func<TSubType, bool> p, Func<TSubType, TResult> f)
        {
            var __f = _f;
            return new PatternMatching<T, TResult>(
                () =>
                {
                    var obj = __f();
                    if (obj.Success) return obj;
                    if (obj.OriginalValue is TSubType)
                    {
                        var casted = (TSubType)(object)obj.Value;
                        if (p == null || p(casted))
                        {
                            return new Match
                            {
                                Value = f(casted),
                                Success = true
                            };
                        }
                    }
                    return obj;
                });
        }


        public PatternMatching<T, TResult> Any(Func<TResult> f)
        {
            var __f = _f;
            return new PatternMatching<T, TResult>(
                () =>
                {
                    var obj = __f();
                    return obj.Success ? obj : new Match { Value = f(), Success = true };
                });
        }

        public TResult Return()
        {
            var ret = _f();
            if (ret.Success)
                return ret.Value;
            throw new MatchFailureException(String.Format("Failed to match: {0}", ret.Value.GetType()));
        }
    }

    public class MatchFailureException : Exception
    {
        public MatchFailureException(string message)
            : base(message)
        { }
    }
}