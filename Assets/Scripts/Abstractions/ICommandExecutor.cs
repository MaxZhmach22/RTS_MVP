/// <summary>
/// Общий интерфейс для всех исполнителей команд
/// </summary>
public interface ICommandExecutor
{
    void ExecuteCommand(object command);
}