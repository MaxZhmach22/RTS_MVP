using System.Threading.Tasks;
using UnityEngine;

public class UnitAttack : CommandExecutorBase<IAttackCommand>
{
    public override async Task ExecuteSpecificCommand(IAttackCommand command)
    {
        Debug.Log($"{name} is attacking {command.Target}");
    }
}
