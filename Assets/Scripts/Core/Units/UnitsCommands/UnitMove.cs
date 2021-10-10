public class UnitMove : CommandExecutorBase<IMoveCommand>
{
    public override void ExecuteSpecificCommand(IMoveCommand command)
    {
        command.Move();
    }
}
