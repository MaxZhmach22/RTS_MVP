public class UnitStop : CommandExecutorBase<IStopCommand>
{
    public override void ExecuteSpecificCommand(IStopCommand command)
    {
        command.Stop();
    }
}
