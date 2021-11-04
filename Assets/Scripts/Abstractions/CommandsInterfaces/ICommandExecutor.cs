/// <summary>
/// Общий интерфейс для всех исполнителей команд
/// </summary>
public interface ICommandExecutor
{
   
}
public interface ICommandExecutor<T>:ICommandExecutor where T:ICommand
{

}