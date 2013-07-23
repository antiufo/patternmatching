using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Xamasoft
{
    public static partial class PatternMatching
    {
        public struct Maybe<T>
        {
            private T value;
            private bool hasValue;
            public static readonly Maybe<T> None;

            public static Maybe<T> Some(T value)
            {
                return new Maybe<T>(value);
            }

            public Maybe(T value)
            {
                this.value = value;
                this.hasValue = true;
            }


            public T Value
            {
                get
                {
                    if (!hasValue) throw new InvalidOperationException();
                    return value;
                }
            }

            public bool HasValue
            {
                get
                {
                    return hasValue;
                }
            }



            public bool IsNone
            {
                get
                {
                    return !hasValue;
                }
            }


        }
    }
}
