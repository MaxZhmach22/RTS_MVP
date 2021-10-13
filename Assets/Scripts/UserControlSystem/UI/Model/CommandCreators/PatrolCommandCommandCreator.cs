using Zenject;
using System;
using UnityEngine;

public class PatrolCommandCommandCreator : CommandCreatorBase<IPatrolCommand>
{
    [Inject] private AssetsContext _context;
    private Action<IPatrolCommand> _creationCallback;

    [Inject]
    private void Init(Vector3Value pointTopatrol)
    {
        pointTopatrol.OnNewValue += onNewValue;
    }

    private void onNewValue(Vector3 pointTopatrol)
    {
        if (pointTopatrol != null)
        {
            _creationCallback?.Invoke(_context.Inject(new PatrolCommand(pointTopatrol)));
            _creationCallback = null;
        }

    }

    protected override void classSpecificCommandCreation(Action<IPatrolCommand> creationCallback)
    {
        _creationCallback = creationCallback;
    }
    public override void ProcessCancel()
    {
        base.ProcessCancel();
        _creationCallback = null;
    }
}