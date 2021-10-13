using System;
using UnityEngine;

public abstract class BaseScriptableValue<T> : ScriptableObject, IScriptableValue<T> /*TODO IAwaitable<T>*/
{
    public class NewValueNotifier<TAwaited>  /*TODO IAwaiter<TAwaited>*/
    {
        private readonly BaseScriptableValue<TAwaited> _baseScriptableValue;
        private TAwaited _result;
        private Action _continuation;
        private bool _isCompleted;

        public NewValueNotifier(BaseScriptableValue<TAwaited> baseScriptableValue)
        {
            _baseScriptableValue = baseScriptableValue;
            _baseScriptableValue.OnNewValue += onNewValue;
        }

        private void onNewValue(TAwaited obj)
        {
            _baseScriptableValue.OnNewValue -= onNewValue;
            _result = obj;
            _isCompleted = true;
            _continuation?.Invoke();
        }

        public void OnCompleted(Action continuation)
        {
            if (_isCompleted)
            {
                continuation?.Invoke();
            }
            else
            {
                _continuation = continuation;
            }
        }
        public bool IsComppleted => _isCompleted;
        public TAwaited GetResult() => _result;
    }

    public T CurrentValue { get ; set ; }
    public bool IsSelected { get ; set ; }

    public event Action<T> OnNewValue;

    public void SetValue(T value)
    {
        CurrentValue = value;
        OnNewValue?.Invoke(value);
    }

    //TODO public IAwaiter<T> GetAwaiter()
    //{
    //    return new NewValueNotifier<T>(this);
    //}

}