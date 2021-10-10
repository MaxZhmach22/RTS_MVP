public class UnitAttack : CommandExecutorBase<IAttackCommand>
{
    public override void ExecuteSpecificCommand(IAttackCommand command)
    {
        command.Attack();
    }
}
