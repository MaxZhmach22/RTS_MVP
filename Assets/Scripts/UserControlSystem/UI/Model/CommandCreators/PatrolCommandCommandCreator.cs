using UnityEngine;
using Zenject;
public class PatrolCommandCommandCreator :
CancellableCommandCreatorBase<IPatrolCommand, Vector3>
{
    protected override IPatrolCommand createCommand(Vector3 argument) => new
        PatrolCommand(argument);
}