using UnityEngine;

public interface IPatrolCommand : ICommand
{
   Vector3 PointToPatrol { get; }
}