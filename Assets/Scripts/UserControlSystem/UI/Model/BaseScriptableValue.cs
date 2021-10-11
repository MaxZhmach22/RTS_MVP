using System;
using UnityEngine;

public abstract class BaseScriptableValue<T> : ScriptableObject, IScriptableValue<T>
{
    public T CurrentValue { get ; set ; }
    public bool IsSelected { get ; set ; }

    public event Action<T> OnNewValue;

    public void SetValue(T value)
    {
        CurrentValue = value;
        OnNewValue?.Invoke(value);
    }
}