using UniRx;
using UnityEngine;
using Random = UnityEngine.Random;

/// <summary>
/// Класс, производящий юнитов.
/// </summary>

public class ProduceUnitCommandExecutor : CommandExecutorBase<IProduceUnitCommand>, IUnitProducer
{
    public IReadOnlyReactiveCollection<IUnitProductionTask> Queue => _queue;

    [SerializeField] private Transform _unitsParent;
    [SerializeField] private int _maximumUnitsInQueue = 6;

    private ReactiveCollection<IUnitProductionTask> _queue = new ReactiveCollection<IUnitProductionTask>();

    private void Update()
    {
        if (_queue.Count == 0)
            return;
       
        UnitProduce();
    }
    /// <summary>
    /// Метод, ищущий первую в реактивной коллеции задачу(Task) и 
    /// проверяющий каждый кадр значение таймера <see cref="UnitProductionTask.TimeLeft"/>,
    /// если проверка пройдена, то убираем методом <see cref="removeTaskAtIndex(int)"/> из коллекции Item под индексом 0 
    /// и инстанциируем префаб <see cref="UnitProductionTask.UnitPrefab"/>.
    /// </summary>
    private void UnitProduce()
    {
        var innerTask = (UnitProductionTask)_queue[0];
        innerTask.TimeLeft -= Time.deltaTime;
        if (innerTask.TimeLeft <= 0)
        {
            removeTaskAtIndex(0);
            Instantiate(innerTask.UnitPrefab, new
            Vector3(Random.Range(-10, 10), 0, Random.Range(-10, 10)),
            Quaternion.identity, _unitsParent);
        }
    }

    /// <summary>
    /// Метод Cancel, принимающий индекс отменяемого задания. Объявлен в интерфейсе <see cref="IUnitProducer"/>
    /// </summary>
    /// <param name="index"></param>
    public void Cancel(int index) => removeTaskAtIndex(index);
    /// <summary>
    /// Метод удаления removeTaskAtIndex делает следующее:
    /// a) сдвигает все значения на пункт вниз, чтобы сработали публикации в поток ObserveReplace;
    /// b) удаляет последний элемент, чтобы сработала публикация в поток ObserveRemove.
    /// </summary>
    /// <param name="index"></param>
    private void removeTaskAtIndex(int index)
    {
        for (int i = index; i < _queue.Count-1; i++)
            _queue[i] = _queue[i + 1];

        _queue.RemoveAt(_queue.Count-1);
    }

    /// <summary>
    /// При вызове метода происходит добавление в реактивную коллекцию item типа <see cref="IUnitProductionTask"/>
    /// </summary>
    /// <param name="command"></param>
    public override void ExecuteSpecificCommand(IProduceUnitCommand command)
    {
        _queue.Add(new UnitProductionTask(command.ProductionTime, command.Icon, command.UnitPrefab, command.UnitName));
    }
}
