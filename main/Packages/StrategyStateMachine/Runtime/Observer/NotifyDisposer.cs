using System;

namespace StateMachine.Observer
{
    public class NotifyDisposer : IDisposable
    {
        private Action disposeAction;

        public NotifyDisposer(Action disposeAction)
        {
            this.disposeAction = disposeAction;
        }

        public void Dispose()
        {
            if(disposeAction != null)
                disposeAction();
            disposeAction = null;
        }
    }
}