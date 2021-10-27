using System;
using UnityEngine;

public class GatheringPointCommandCreator : CancellableCommandCreatorBase<IGatheringPoint, Vector3>
{
    protected override IGatheringPoint createCommand(Vector3 argument) =>
        new GatheringPointCommand(argument);
    
}