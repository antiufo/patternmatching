using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Xamasoft.Functional
{
    public class PatternMatching<T1, TResult> : PatternMatchingBase<TResult>
    {

        private T1 arg1;

        public PatternMatching(T1 arg1)
        {
            this.arg1 = arg1;
        }

        public override Maybe<TResult> Result()
        {
            throw new NotImplementedException();
        }

        public PatternMatching<T1, TResult> With<TSub1>(Func<TSub1, TResult> func, Func<TSub1, bool> guard = null) where TSub1 : T1
        {
            throw new NotImplementedException();
        }

        public PatternMatching<T1, TResult> Else(Func<T1, TResult> func)
        {
            throw new NotImplementedException();
        }

    }


    public class PatternMatching<T1, T2, TResult> : PatternMatchingBase<TResult>
    {

        private T1 arg1;
        private T2 arg2;

        public PatternMatching(T1 arg1, T2 arg2)
        {
            this.arg1 = arg1;
            this.arg2 = arg2;
        }

        public override Maybe<TResult> Result()
        {
            throw new NotImplementedException();
        }

        public PatternMatching<T1, T2, TResult> With<TSub1, TSub2>(Func<TSub1, TSub2, TResult> func, Func<TSub1, TSub2, bool> guard = null)
            where TSub1 : T1
            where TSub2 : T2
        {
            throw new NotImplementedException();
            //return new PatternMatching<T1,T2,TResult>(arg1, arg2
        }



        public PatternMatching<T1, T2, TResult> WithActivePattern(Func<T1, T2, Maybe<TResult>> activePattern)
        {
            throw new NotImplementedException();
        }


    }






}
