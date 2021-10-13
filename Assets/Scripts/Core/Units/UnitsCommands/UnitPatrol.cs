using UnityEngine;

public class UnitPatrol : CommandExecutorBase<IPatrolCommand>
{
    public override void ExecuteSpecificCommand(IPatrolCommand command)
    {
        Debug.Log($"{name} is patrolling between {gameObject.transform.position} & {command.PointToPatrol}");
    }
}
