using System.Collections.Generic;
using UnityEngine;
using Zenject;
using UniRx;
using System;

public class CommandButtonsPresenter : MonoBehaviour
{
    [SerializeField] private CommandButtonsView _view;
    [Inject] private CommandButtonsModel _model;
    [Inject] private IObservable<ISelectable> _selectedValues;


    private ISelectable _currentSelectable;
    private void Start()
    {
        _selectedValues.Subscribe(onSelected); //�������� �� ���������� ��������

        _view.OnClick += _model.OnCommandButtonClicked; // OnClick �������� ��� 
        _model.OnCommandSent += _view.UnblockAllInteractions;
        _model.OnCommandCancel += _view.UnblockAllInteractions;
        _model.OnCommandAccepted += _view.BlockInteractions;
    }


    /// <summary>
    /// ������������� ���� ������� �� ��������� �������� _selectedValue <see cref="IObservable{T}"/>, ����� ��� �������, 
    /// ������� ��������� <see cref="ICommandExecutor"/> � �������� <see cref="CommandButtonsView"/> ������ ��� ��������� Layout
    /// </summary>
    /// <param name="selectable"></param>
    private void onSelected(ISelectable selectable)
    {
        if (_currentSelectable == selectable)
        {
            return;
        }
        if (_currentSelectable != null)
        {
            _model.OnSelectionChanged();
        }
        _currentSelectable = selectable;
        _view.Clear();

        if (selectable != null)
        {
            var commandExecutors = new List<ICommandExecutor>(); //������� ������ executor
            commandExecutors.AddRange((selectable as
            Component).GetComponentsInParent<ICommandExecutor>());
            var queue = (selectable as Component).GetComponentInParent<ICommandsQueue>();
            _view.MakeLayout(commandExecutors, queue);
        }
    }

}