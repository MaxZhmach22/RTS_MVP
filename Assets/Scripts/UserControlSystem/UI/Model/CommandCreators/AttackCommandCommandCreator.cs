using Zenject;
using System;
public class AttackCommandCommandCreator : CommandCreatorBase<IAttackCommand>
{
    [Inject] private AssetsContext _context;
    private Action<IAttackCommand> _creationCallback;

    [Inject]
    private void Init(SelectableValue target)
    {
        target.OnNewValue += onNewValue;
    }

    private void onNewValue(ISelectable target)
    {
        if (target != null)
        {
            _creationCallback?.Invoke(_context.Inject(new AttackCommand(target)));
            _creationCallback = null;
        }
       
    }

    protected override void classSpecificCommandCreation(Action<IAttackCommand> creationCallback)
    {
        _creationCallback = creationCallback;
    }
    public override void ProcessCancel()
    {
        base.ProcessCancel();
        _creationCallback = null;
    }
}