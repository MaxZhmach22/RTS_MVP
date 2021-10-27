using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class CommandButtonsView : MonoBehaviour
{
    public Action<ICommandExecutor, ICommandsQueue> OnClick;

    [SerializeField] private GameObject _attackButton;
    [SerializeField] private GameObject _moveButton;
    [SerializeField] private GameObject _patrolButton;
    [SerializeField] private GameObject _stopButton;
    [SerializeField] private GameObject _produceUnitButton;
    [SerializeField] private GameObject _gatheringPointButton;

    private Dictionary<Type, GameObject> _buttonsByExecutorType;
    private void Start()
    {
        _buttonsByExecutorType = new Dictionary<Type, GameObject>();
        _buttonsByExecutorType
        .Add(typeof(ICommandExecutor<IAttackCommand>),
        _attackButton);
        _buttonsByExecutorType
        .Add(typeof(ICommandExecutor<IMoveCommand>),
        _moveButton);
        _buttonsByExecutorType
        .Add(typeof(ICommandExecutor<IPatrolCommand>),
        _patrolButton);
        _buttonsByExecutorType
        .Add(typeof(ICommandExecutor<IStopCommand>),
        _stopButton);
        _buttonsByExecutorType
        .Add(typeof(ICommandExecutor<IProduceUnitCommand>),
        _produceUnitButton);
        _buttonsByExecutorType
        .Add(typeof(ICommandExecutor<IGatheringPoint>),
        _gatheringPointButton);
    }
    public void BlockInteractions(ICommandExecutor ce)
    {
        UnblockAllInteractions();
        GetButtonGameObjectByType(ce.GetType())
        .GetComponent<Selectable>().interactable = false;
    }

    public void UnblockAllInteractions() => SetInteractible(true); //TODO синтаксис на заметку!

    private void SetInteractible(bool value)
    {
        _attackButton.GetComponent<Selectable>().interactable = value;
        _moveButton.GetComponent<Selectable>().interactable = value;
        _patrolButton.GetComponent<Selectable>().interactable = value;
        _stopButton.GetComponent<Selectable>().interactable = value;
        _produceUnitButton.GetComponent<Selectable>().interactable = value;
        _gatheringPointButton.GetComponent<Selectable>().interactable = value;

    }
    /// <summary>
    /// Получаем список скриптов комманд <see cref="ICommandExecutor"></see> от выбранного объекта,
    /// методом <see cref="GetButtonGameObjectByType"></see> получаем конткретную кнопку. Сделали её активной, получили компонент
    /// Button и подписали методом-пустышкой, который всего лишь вызыввает событие <see cref="OnClick"/> и передает (currentExecutor);
    /// </summary>
    /// <param name="commandExecutors"></param>
    public void MakeLayout(IEnumerable<ICommandExecutor> commandExecutors, ICommandsQueue queue)
    {
        foreach (var currentExecutor in commandExecutors)
        {
            var buttonGameObject =
            GetButtonGameObjectByType(currentExecutor.GetType());
            buttonGameObject.SetActive(true);
            var button = buttonGameObject.GetComponent<Button>();
            button.onClick.AddListener(() => OnClick?.Invoke(currentExecutor, queue));
        }
    }

    /// <summary>
    /// Метод ищет в словаре <see cref="_buttonsByExecutorType"/> первое First() значение Value(), ключ которого
    /// можно присвоить экземпляру типа указанного в аргументе(executorInstanceType).
    /// </summary>
    /// <param name="executorInstanceType"></param>
    /// <returns></returns>
    private GameObject GetButtonGameObjectByType(Type executorInstanceType) //TODO синтаксис на заметку!
    {
        return _buttonsByExecutorType
        .Where(type =>
        type.Key.IsAssignableFrom(executorInstanceType))
        .First()
        .Value;
    }

    public void Clear()
    {
        foreach (var kvp in _buttonsByExecutorType)
        {
            kvp.Value
            .GetComponent<Button>().onClick.RemoveAllListeners();
            kvp.Value.SetActive(false);
        }
    }
}