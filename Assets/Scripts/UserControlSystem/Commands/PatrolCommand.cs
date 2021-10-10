using UnityEngine;

public class PatrolCommand : IPatrolCommand
{
    public void Patrol() =>
        Debug.Log("IsPatroling");
    
}
