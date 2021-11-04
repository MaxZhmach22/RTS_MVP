using UnityEngine;
public sealed class MoveCommandCommandCreator : CancellableCommandCreatorBase<IMoveCommand, Vector3>
{
    protected override IMoveCommand CreateCommand(Vector3 argument) => new MoveCommand(argument);
}