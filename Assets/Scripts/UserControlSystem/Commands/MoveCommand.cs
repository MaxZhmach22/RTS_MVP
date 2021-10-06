using UnityEngine;

public class MoveCommand : IMoveCommand 
{
    public void Move() =>
        Debug.Log("IsMoving");
}
