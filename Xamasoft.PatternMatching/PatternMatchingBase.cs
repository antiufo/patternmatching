using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Xamasoft.Functional
{
    public abstract class PatternMatchingBase<TResult>
    {
        public abstract Maybe<TResult> Result();

        public Maybe<TNewResult> SelectResult<TNewResult>(Func<TResult, TNewResult> selector)
        {
            var r = Result();
            return r.HasValue ? Maybe<TNewResult>.Some(selector(r.Value)) : Maybe<TNewResult>.None;
        }

    }
}
