using System;

public abstract class BaseAwaiter<TAwaited> : IAwaiter<TAwaited>
{
    public TAwaited Result { get; set; }
    public bool IsCompleted { get; set; }

    public event Action Continuation;

    public TAwaited GetResult() => Result;

    protected virtual void onNewValue(TAwaited obj)
    {
        Result = obj;
        IsCompleted = true;
        Continuation?.Invoke();
    }

    protected virtual void onStop()
    {
        IsCompleted = true;
        Continuation?.Invoke();
    }

    public void OnCompleted(Action continuation)
    {
        if (IsCompleted)
        {
            continuation?.Invoke();
        }
        else
        {
            Continuation = continuation;
        }
    }
}