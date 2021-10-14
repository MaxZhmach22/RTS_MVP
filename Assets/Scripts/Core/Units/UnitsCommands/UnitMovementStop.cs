using System;
using UnityEngine;
using UnityEngine.AI;

public class UnitMovementStop : MonoBehaviour, IAwaitable<AsyncExtensions.Void>
{
    public class StopAwaiter : BaseAwaiter<AsyncExtensions.Void>
    {
        private readonly UnitMovementStop _unitMovementStop;

        public StopAwaiter(UnitMovementStop unitMovementStop)
        {
            _unitMovementStop = unitMovementStop;
            _unitMovementStop.OnStop += onStop;
        }
        protected override void onStop()
        {
            _unitMovementStop.OnStop -= onStop;
            base.onStop();
        }
    }

    public event Action OnStop;
    public bool IsMoving { get; private set; }

    [SerializeField] private NavMeshAgent _agent;
    void Update()
    {
        if (!_agent.pathPending)
        {
            if (_agent.remainingDistance <= _agent.stoppingDistance)
            {
                if (!_agent.hasPath || _agent.velocity.sqrMagnitude == 0f)
                {
                    OnStop?.Invoke();
                    IsMoving = false;
                }
                IsMoving = true;
            }
        }
    }
    public IAwaiter<AsyncExtensions.Void> GetAwaiter() => new StopAwaiter(this);
}


