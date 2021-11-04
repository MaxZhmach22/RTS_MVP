using System;

/// <summary>
/// Базовый класс для всех создателей комманд. Он проверяет на соответсвие аргумента типу <see cref="CommandCreatorBase{T}"/>
/// </summary>
/// <typeparam name="T"></typeparam>
public abstract class CommandCreatorBase<T> where T : ICommand
{
    public ICommandExecutor ProcessCommandExecutor(ICommandExecutor commandExecutor, Action<T> callback)
    {
        if (commandExecutor is ICommandExecutor<T> classSpecificExecutor)
        {
            ClassSpecificCommandCreation(callback);
        }
        return commandExecutor;
    }

    protected abstract void ClassSpecificCommandCreation(Action<T> creationCallback);

    public virtual void ProcessCancel() { }
}