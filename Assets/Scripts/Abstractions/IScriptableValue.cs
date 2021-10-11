using System;
public interface IScriptableValue<T> 
{
    T CurrentValue { get; set; }
    bool IsSelected { get; set; }

    event Action<T> OnNewValue;
    void SetValue(T value);
   
}