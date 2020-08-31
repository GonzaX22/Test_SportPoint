using System;
using System.Collections.Generic;
using System.Text;

namespace SportPoint.Framework
{
    public abstract class BaseStateAwareViewModel<T> : BaseViewModel 
        where T : struct
    {
        private T currentState;

        public T CurrentState
        {
            get => currentState;
            set => SetAndRaisePropertyChanged(ref currentState, value);
        }
    }
}
