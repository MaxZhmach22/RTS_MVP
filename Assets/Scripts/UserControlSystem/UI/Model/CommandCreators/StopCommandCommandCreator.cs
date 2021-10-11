using Zenject;
using System;
public class StopCommandCommandCreator : CommandCreatorBase<IStopCommand>
{
    [Inject] private AssetsContext _context;
    private Action<IStopCommand> _creationCallback;

    //[Inject]
    //private void Init(SelectableValue target)
    //{
    //    target.OnNewValue += onNewValue;
    //}

    protected override void classSpecificCommandCreation(Action<IStopCommand> creationCallback)
    {
        creationCallback?.Invoke(_context.Inject(new StopCommand()));
    }
}