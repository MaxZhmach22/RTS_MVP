using Zenject;
using System;
public class AttackCommandCommandCreator : CommandCreatorBase<IAttackCommand>
{
    [Inject] private AssetsContext _context;
    [Inject] private SelectableValue _targetToAttack; //TODO проверить на работу

    protected override async void classSpecificCommandCreation(Action<IAttackCommand> creationCallback)
    {
        //TODO creationCallback?.Invoke(_context.Inject(new AttackCommand(await _targetToAttack)));
    }
}