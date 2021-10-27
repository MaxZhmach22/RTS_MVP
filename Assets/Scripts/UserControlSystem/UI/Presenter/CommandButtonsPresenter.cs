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
        _selectedValues.Subscribe(onSelected); //Подписка на реактивное свойство

        _view.OnClick += _model.OnCommandButtonClicked; // OnClick передает нам 
        _model.OnCommandSent += _view.UnblockAllInteractions;
        _model.OnCommandCancel += _view.UnblockAllInteractions;
        _model.OnCommandAccepted += _view.BlockInteractions;
    }


    /// <summary>
    /// Подписываемся этим методом на изменение значения _selectedValue <see cref="IObservable{T}"/>, берем все скрипты, 
    /// которые реализуют <see cref="ICommandExecutor"/> и передаем <see cref="CommandButtonsView"/> список для отрисовки Layout
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
            var commandExecutors = new List<ICommandExecutor>(); //Создаем список executor
            commandExecutors.AddRange((selectable as
            Component).GetComponentsInParent<ICommandExecutor>());
            var queue = (selectable as Component).GetComponentInParent<ICommandsQueue>();
            _view.MakeLayout(commandExecutors, queue);
        }
    }

}