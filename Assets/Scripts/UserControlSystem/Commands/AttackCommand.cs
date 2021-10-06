using UnityEngine;

public class AttackCommand : IAttackCommand
{
    public void Attack() =>
        Debug.Log("Is Attacking");

}
