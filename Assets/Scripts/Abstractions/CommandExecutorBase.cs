using UnityEngine;
/// <summary>
/// Задача класса — перенаправлять вызовы интерфейса generic-методу. Теперь мы можем
/// работать и с generic, и с не-generic версией API
/// </summary>
/// <typeparam name="T"></typeparam>
public abstract class CommandExecutorBase<T> : MonoBehaviour, ICommandExecutor where T: ICommand
{
    public void ExecuteCommand(object command) =>
        ExecuteSpecificCommand((T)command);
    public abstract void ExecuteSpecificCommand(T command);
}