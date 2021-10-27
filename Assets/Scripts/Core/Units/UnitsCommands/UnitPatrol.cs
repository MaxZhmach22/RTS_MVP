using System.Threading.Tasks;
using UnityEngine;

public class UnitPatrol : CommandExecutorBase<IPatrolCommand>
{
    public override async Task ExecuteSpecificCommand(IPatrolCommand command)
    {
        Debug.Log($"{name} is patrolling between {gameObject.transform.position} & {command.PointToPatrol}");
    }
}
