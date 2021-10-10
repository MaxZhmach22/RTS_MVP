using System;
using System.Collections.Generic;
using UnityEngine;

public class CommandButtonsPresenter : MonoBehaviour
{
    [SerializeField] private SelectableValue _selectable;
    [SerializeField] private CommandButtonsView _view;
    [SerializeField] private AssetsContext _context;

    private ISelectable _currentSelectable;

    private void Start()
    {
        _selectable.OnSelected += onSelected;
        onSelected(_selectable.CurrentValue);
        _view.OnClick += onButtonClick;
    }
    private void onSelected(ISelectable selectable)
    {
        if (_currentSelectable == selectable)
        {
            return;
        }
        _currentSelectable = selectable;
        _view.Clear();
        if (selectable != null)
        {
            var commandExecutors = new List<ICommandExecutor>();
            commandExecutors.AddRange((selectable as
            Component).GetComponentsInParent<ICommandExecutor>());
            _view.MakeLayout(commandExecutors);
        }
        
    }
    private void onButtonClick(ICommandExecutor commandExecutor)
    { 
        var unitProducer = commandExecutor as
        CommandExecutorBase<IProduceUnitCommand>;
        if (unitProducer != null)
        {
            unitProducer.ExecuteSpecificCommand(_context.Inject(new ProduceUnitCommandHeir()));
            return;
        }
        var attack = commandExecutor as CommandExecutorBase<IAttackCommand>;
        if (attack != null)
        {
            attack.ExecuteCommand(new AttackCommand());
            return;
        }
        var move = commandExecutor as CommandExecutorBase<IMoveCommand>;
        if (move != null)
        {
            move.ExecuteCommand(new MoveCommand());
            return;
        }  
        var patrol = commandExecutor as CommandExecutorBase<IPatrolCommand>;
        if (patrol != null)
        {
            patrol.ExecuteCommand(new PatrolCommand());
            return;
        }
        var stop = commandExecutor as CommandExecutorBase<IStopCommand>;
        if (stop != null)
        {
            stop.ExecuteCommand(new StopCommand());
            return;
        }
        throw new
        ApplicationException($"{nameof(CommandButtonsPresenter)}.{nameof(onButtonClick)}: Unknown type of commands executor: { commandExecutor.GetType().FullName }!");
    }

}