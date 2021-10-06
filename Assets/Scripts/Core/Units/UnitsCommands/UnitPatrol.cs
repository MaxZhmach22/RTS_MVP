
public class UnitPatrol : CommandExecutorBase<IPatrolCommand>
{
    public override void ExecuteSpecificCommand(IPatrolCommand command)
    {
        command.Patrol();
    }
}
