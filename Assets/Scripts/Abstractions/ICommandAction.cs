using System;

public interface ICommandAction
{
    event Action OnCommandAction;
}

public interface ICommadAction<T>
{
    event Action<T> OnCommandAction;
}