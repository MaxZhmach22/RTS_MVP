using UnityEngine;

class GatheringPointCommandCreator : CancellableCommandCreatorBase<IGatheringPoint, Vector3>
{
    protected override IGatheringPoint CreateCommand(Vector3 argument) =>
            new GatheringPointCommand(argument);
}