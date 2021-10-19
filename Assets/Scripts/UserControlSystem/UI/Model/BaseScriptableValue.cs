using System;
using System.Collections.Generic;
using UniRx;
using UnityEngine;

public abstract class BaseScriptableValue<T> : ScriptableObject, IScriptableValue<T>, IAwaitable<T>
{
    public class NewValueNotifier<TAwaited> : BaseAwaiter<TAwaited>
    {
        private readonly BaseScriptableValue<TAwaited> _baseScriptableValue;

        public NewValueNotifier(BaseScriptableValue<TAwaited> baseScriptableValue)
        {
            _baseScriptableValue = baseScriptableValue;
            _baseScriptableValue.OnNewValue += onNewValue;
        }

        protected override void onNewValue(TAwaited obj)
        {
            _baseScriptableValue.OnNewValue -= onNewValue;
            base.onNewValue(obj);
        }
    }

    public T CurrentValue { get ; set ; }
    public bool IsSelected { get ; set ; }

    public event Action<T> OnNewValue;

    public virtual void SetValue(T value)
    {
        CurrentValue = value;
        OnNewValue?.Invoke(value);
    }

    public IAwaiter<T> GetAwaiter()
    {
        return new NewValueNotifier<T>(this); //Возвращаемый объект должен реализовывать IAwaiter
    }

}