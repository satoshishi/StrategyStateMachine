using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace StatMachine.Observer
{

    public class SimplyObservable<T> : IDisposable
    {
        private List<ISimplyObserver<T>> observers;

        public SimplyObservable()
        {
            observers = new List<ISimplyObserver<T>>();
        }

        public IDisposable Subscribe(ISimplyObserver<T> observer)
        {
            observers.Add(observer);
            return new NotifyDisposer(() =>
            {
                observers.Remove(observer);
//                UnityEngine.Debug.Log(observers.Count);
            });
        }

        public void SendMessage(T value)
        {
            for (int i = 0; i < observers.Count; i++)
                observers[i].OnNext(value);
        }

        public void Dispose()
        {
            observers.Clear();
            observers = null;
            observers = new List<ISimplyObserver<T>>();
        }
    }

}