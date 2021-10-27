using System;

/// <summary>
/// Базовый класс для всех создателей комманд. Он проверяет на соответсвие аргумента типу <see cref="CommandCreatorBase{T}"/>
/// </summary>
/// <typeparam name="T"></typeparam>
public abstract class CommandCreatorBase<T> where T : ICommand
{
    public ICommandExecutor ProcessCommandExecutor(ICommandExecutor commandExecutor, Action<T> callback)
    {
        var classSpecificExecutor = commandExecutor as ICommandExecutor<T>;
        if(classSpecificExecutor != null)
        {
            classSpecificCommandCreation(callback);
        }
        return commandExecutor;
    }

    protected abstract void classSpecificCommandCreation(Action<T> creationCallback);

    public virtual void ProcessCancel() { }
}