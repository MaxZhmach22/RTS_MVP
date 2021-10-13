using UnityEngine;

public class PatrolCommand : IPatrolCommand
{

    public Vector3 PointToPatrol { get; }

    public PatrolCommand(Vector3 pointToPatrol)
    {
        PointToPatrol = pointToPatrol;
    }

}
