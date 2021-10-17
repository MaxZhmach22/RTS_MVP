using UnityEngine;
using UnityEngine.AI;

public class UnitStop : CommandExecutorBase<IStopCommand>
{
    [SerializeField] private UnitMovementStop _stop;
    [SerializeField] private Animator _animator;

    public override async void ExecuteSpecificCommand(IStopCommand command)
    {
        if (_stop.IsMoving)
        {
            GetComponent<NavMeshAgent>().ResetPath();
            await _stop;
            _animator.SetTrigger("Idle");
        }
       
    }

}
