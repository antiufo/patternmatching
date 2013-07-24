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

        public static PatternMatching<T, TResult> Else<T, TResult>(this PatternMatching<T, TResult> x, Func<T, TResult> f)
        {
            return x.With<T>(b => f(b));
        }

        public static T InThisCase<T>(this bool condition, Func<T> result)
        {
            if (condition) return result();
            return default(T);
        }

        public static T ProvidedThat<T>(this T value, Func<T, bool> guard)
        {
            if (value == null || !guard(value)) return default(T);
            return value;
        }

        public static Tuple<T1, T2> IfAllNonNulls<T1, T2>(this Tuple<T1, T2> tuple)
        {
            return
                tuple.Item1 != null &&
                tuple.Item2 != null ?
                tuple : null;
        }

        public static Tuple<T1, T2, T3> IfAllNonNulls<T1, T2, T3>(this Tuple<T1, T2, T3> tuple)
        {
            return
                tuple.Item1 != null &&
                tuple.Item2 != null &&
                tuple.Item3 != null ?
                tuple : null;
        }

        public static Tuple<T1, T2, T3, T4> IfAllNonNulls<T1, T2, T3, T4>(this Tuple<T1, T2, T3, T4> tuple)
        {
            return
                tuple.Item1 != null &&
                tuple.Item2 != null &&
                tuple.Item3 != null &&
                tuple.Item4 != null ?
                tuple : null;
        }

        public static Tuple<T1, T2, T3, T4, T5> IfAllNonNulls<T1, T2, T3, T4, T5>(this Tuple<T1, T2, T3, T4, T5> tuple)
        {
            return
                tuple.Item1 != null &&
                tuple.Item2 != null &&
                tuple.Item3 != null &&
                tuple.Item4 != null &&
                tuple.Item5 != null ?
                tuple : null;
        }

        public struct UntypedPatternMatching<T>
        {
            internal T OriginalValue;
            public PatternMatching<T, TResult> Returning<TResult>()
            {
                var val = OriginalValue;
                return new PatternMatching<T, TResult>(() => new PatternMatching<T, TResult>.Match() { OriginalValue = val });
            }

            public UntypedPatternMatchingWithPartialWithCase<T, TSubType> With<TSubType>() where TSubType : T
            {
                var val = OriginalValue;
                return new UntypedPatternMatchingWithPartialWithCase<T, TSubType>() { OriginalValue = val };
            }

            public PatternMatching<T, TResult> WithActivePattern<TIntermediate1, TResult>(Func<T, TIntermediate1> activePattern, Func<TIntermediate1, TResult> f)
            {
                var val = OriginalValue;
                return val.Match().Returning<TResult>().WithActivePattern(activePattern, f);
            }

            public PatternMatching<T, TResult> WithActivePattern<TIntermediate1, TIntermediate2, TResult>(Func<T, TIntermediate1> activePattern1, Func<TIntermediate1, TIntermediate2> activePattern2, Func<TIntermediate1, TIntermediate2, TResult> f)
            {
                var val = OriginalValue;
                return val.Match().Returning<TResult>().WithActivePattern(activePattern1, activePattern2, f);
            }

            public PatternMatching<T, TResult> WithActivePattern<TIntermediate1, TIntermediate2, TIntermediate3, TResult>(Func<T, TIntermediate1> activePattern1, Func<TIntermediate1, TIntermediate2> activePattern2, Func<TIntermediate1, TIntermediate2, TIntermediate3> activePattern3, Func<TIntermediate1, TIntermediate2, TIntermediate3, TResult> f)
            {
                var val = OriginalValue;
                return val.Match().Returning<TResult>().WithActivePattern(activePattern1, activePattern2, activePattern3, f);
            }

            public PatternMatching<T, TResult> WithActivePattern<TIntermediate1, TIntermediate2, TIntermediate3, TIntermediate4, TResult>(Func<T, TIntermediate1> activePattern1, Func<TIntermediate1, TIntermediate2> activePattern2, Func<TIntermediate1, TIntermediate2, TIntermediate3> activePattern3, Func<TIntermediate1, TIntermediate2, TIntermediate3, TIntermediate4> activePattern4, Func<TIntermediate1, TIntermediate2, TIntermediate3, TIntermediate4, TResult> f)
            {
                var val = OriginalValue;
                return val.Match().Returning<TResult>().WithActivePattern(activePattern1, activePattern2, activePattern3, activePattern4, f);
            }
            public PatternMatching<T, TResult> WithActivePattern<TIntermediate1, TIntermediate2, TIntermediate3, TIntermediate4, TIntermediate5, TResult>(Func<T, TIntermediate1> activePattern1, Func<TIntermediate1, TIntermediate2> activePattern2, Func<TIntermediate1, TIntermediate2, TIntermediate3> activePattern3, Func<TIntermediate1, TIntermediate2, TIntermediate3, TIntermediate4> activePattern4, Func<TIntermediate1, TIntermediate2, TIntermediate3, TIntermediate4, TIntermediate5> activePattern5, Func<TIntermediate1, TIntermediate2, TIntermediate3, TIntermediate4, TIntermediate5, TResult> f)
            {
                var val = OriginalValue;
                return val.Match().Returning<TResult>().WithActivePattern(activePattern1, activePattern2, activePattern3, activePattern4, activePattern5, f);
            }

        }


        public struct UntypedPatternMatchingWithPartialWithCase<T, TSubType>
        {
            internal T OriginalValue;
            public PatternMatching<T, TResult> _<TResult>(Func<TSubType, TResult> f)
            {
                return _(null, f);
            }
            public PatternMatching<T, TResult> _<TResult>(Func<TSubType, bool> p, Func<TSubType, TResult> f)
            {
                var val = OriginalValue;
                return val.Match().Returning<TResult>().With<TSubType>(p, f);
            }
        }


        public class MatchFailureException : Exception
        {
            public MatchFailureException(string message)
                : base(message)
            { }
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
                        var casted = (TSubType)(object)obj.OriginalValue;
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

        public PatternMatching<T, TResult> WithActivePattern<TIntermediate1>(Func<T, TIntermediate1> activePattern, Func<TIntermediate1, TResult> f)
        {
            TResult result = default(TResult);
            return this.With<T>(x =>
            {
                var result1 = activePattern(x);
                if (result1 == null) return false;
                result = f(result1);
                return result != null;
            }, x => result);
        }

        public PatternMatching<T, TResult> WithActivePattern<TIntermediate1, TIntermediate2>(Func<T, TIntermediate1> activePattern1, Func<TIntermediate1, TIntermediate2> activePattern2, Func<TIntermediate1, TIntermediate2, TResult> f)
        {
            TResult result = default(TResult);
            return this.With<T>(x =>
            {
                var result1 = activePattern1(x);
                if (result1 == null) return false;
                var result2 = activePattern2(result1);
                if (result2 == null) return false;
                result = f(result1, result2);
                return result != null;
            }, x => result);
        }

        public PatternMatching<T, TResult> WithActivePattern<TIntermediate1, TIntermediate2, TIntermediate3>(Func<T, TIntermediate1> activePattern1, Func<TIntermediate1, TIntermediate2> activePattern2, Func<TIntermediate1, TIntermediate2, TIntermediate3> activePattern3, Func<TIntermediate1, TIntermediate2, TIntermediate3, TResult> f)
        {
            TResult result = default(TResult);
            return this.With<T>(x =>
            {
                var result1 = activePattern1(x);
                if (result1 == null) return false;
                var result2 = activePattern2(result1);
                if (result2 == null) return false;
                var result3 = activePattern3(result1, result2);
                if (result3 == null) return false;
                result = f(result1, result2, result3);
                return result != null;
            }, x => result);
        }

        public PatternMatching<T, TResult> WithActivePattern<TIntermediate1, TIntermediate2, TIntermediate3, TIntermediate4>(Func<T, TIntermediate1> activePattern1, Func<TIntermediate1, TIntermediate2> activePattern2, Func<TIntermediate1, TIntermediate2, TIntermediate3> activePattern3, Func<TIntermediate1, TIntermediate2, TIntermediate3, TIntermediate4> activePattern4, Func<TIntermediate1, TIntermediate2, TIntermediate3, TIntermediate4, TResult> f)
        {
            TResult result = default(TResult);
            return this.With<T>(x =>
            {
                var result1 = activePattern1(x);
                if (result1 == null) return false;
                var result2 = activePattern2(result1);
                if (result2 == null) return false;
                var result3 = activePattern3(result1, result2);
                if (result3 == null) return false;
                var result4 = activePattern4(result1, result2, result3);
                if (result4 == null) return false;
                result = f(result1, result2, result3, result4);
                return result4 != null;
            }, x => result);
        }

        public PatternMatching<T, TResult> WithActivePattern<TIntermediate1, TIntermediate2, TIntermediate3, TIntermediate4, TIntermediate5>(Func<T, TIntermediate1> activePattern1, Func<TIntermediate1, TIntermediate2> activePattern2, Func<TIntermediate1, TIntermediate2, TIntermediate3> activePattern3, Func<TIntermediate1, TIntermediate2, TIntermediate3, TIntermediate4> activePattern4, Func<TIntermediate1, TIntermediate2, TIntermediate3, TIntermediate4, TIntermediate5> activePattern5, Func<TIntermediate1, TIntermediate2, TIntermediate3, TIntermediate4, TIntermediate5, TResult> f)
        {
            TResult result = default(TResult);
            return this.With<T>(x =>
            {
                var result1 = activePattern1(x);
                if (result1 == null) return false;
                var result2 = activePattern2(result1);
                if (result2 == null) return false;
                var result3 = activePattern3(result1, result2);
                if (result3 == null) return false;
                var result4 = activePattern4(result1, result2, result3);
                if (result4 == null) return false;
                var result5 = activePattern5(result1, result2, result3, result4);
                if (result5 == null) return false;
                result = f(result1, result2, result3, result4, result5);
                return result != null;
            }, x => result);
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
            throw new PatternMatching.MatchFailureException(String.Format("Failed to match: {0}", ret.Value.GetType()));
        }

        public TResult ReturnOrDefault()
        {
            var ret = _f();
            return ret.Value;
        }
    }
}