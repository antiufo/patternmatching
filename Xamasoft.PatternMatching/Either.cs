using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Xamasoft
{
    public struct Either<T1, T2>
    {
        private int tag;
        private T1 val1;
        private T2 val2;

        public T1 As1 { get { return val1; } }
        public T2 As2 { get { return val2; } }

        private void EnsureTagged(int tag)
        {
            if (this.tag != tag) throw new InvalidCastException("Invalid Either<> casting.");
        }

        public static explicit operator T1(Either<T1, T2> val)
        {
            val.EnsureTagged(1);
            return val.val1;
        }

        public static explicit operator T2(Either<T1, T2> val)
        {
            val.EnsureTagged(2);
            return val.val2;
        }

        public static implicit operator Either<T1, T2>(T1 val)
        {
            return new Either<T1, T2>() { tag = 1, val1 = val };
        }

        public static implicit operator Either<T1, T2>(T2 val)
        {
            return new Either<T1, T2>() { tag = 2, val2 = val };
        }


        public override string ToString()
        {
            if (tag == 1) return Convert.ToString(val1);
            if (tag == 2) return Convert.ToString(val2);
            return "(None)";
        }

    }



}
