using System.Threading.Tasks;
using UnityEngine;
/// <summary>
/// Задача класса — перенаправлять вызовы интерфейса generic-методу. Теперь мы можем
/// работать и с generic, и с не-generic версией API
/// </summary>
/// <typeparam name="T"></typeparam>
public abstract class CommandExecutorBase<T> : MonoBehaviour, ICommandExecutor<T> where T : class, ICommand
{
    public async Task TryExecuteCommand(object command)
    {
        var specificCommand = command as T;
        if (specificCommand != null)
        {
            await ExecuteSpecificCommand(specificCommand);
        }
    }

    public abstract Task ExecuteSpecificCommand(T command);

}