using UnityEngine;

public class GatheringPointCommand : IGatheringPoint
{
    public Vector3 GatheringPoint { get; }

    public GatheringPointCommand(Vector3 gatheringPoint) =>
        GatheringPoint = gatheringPoint;
}

