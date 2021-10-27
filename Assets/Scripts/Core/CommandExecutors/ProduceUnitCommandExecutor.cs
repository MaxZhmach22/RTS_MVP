using System.Threading.Tasks;
using UniRx;
using UnityEngine;
using Zenject;
using Random = UnityEngine.Random;

/// <summary>
/// Класс, производящий юнитов.
/// </summary>

public class ProduceUnitCommandExecutor : CommandExecutorBase<IProduceUnitCommand>, IUnitProducer
{
    public IReadOnlyReactiveCollection<IUnitProductionTask> Queue => _queue;

    [SerializeField] private Transform _unitsParent;
    [SerializeField] private int _maximumUnitsInQueue = 6;
    [Inject] private DiContainer _diContainer;

    private ReactiveCollection<IUnitProductionTask> _queue = new ReactiveCollection<IUnitProductionTask>();

    private void Update()
    {
        if (_queue.Count == 0)
            return;

        var innerTask = (UnitProductionTask)_queue[0];
        innerTask.TimeLeft -= Time.deltaTime;
        if (innerTask.TimeLeft <= 0)
        {
            removeTaskAtIndex(0);
            Instantiate(innerTask.UnitPrefab, new Vector3(Random.Range(-10, 10), 0, Random.Range(-10, 10)), Quaternion.identity, _unitsParent);
        }
    }
    /// <summary>
    /// Метод, ищущий первую в реактивной коллеции задачу(Task) и 
    /// проверяющий каждый кадр значение таймера <see cref="UnitProductionTask.TimeLeft"/>,
    /// если проверка пройдена, то убираем методом <see cref="removeTaskAtIndex(int)"/> из коллекции Item под индексом 0 
    /// и инстанциируем префаб <see cref="UnitProductionTask.UnitPrefab"/>.
    /// </summary>
    

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
    public override async Task ExecuteSpecificCommand(IProduceUnitCommand command)
    {
        var instance = _diContainer.InstantiatePrefab(command.UnitPrefab, transform.position, Quaternion.identity, _unitsParent);
        var queue = instance.GetComponent<ICommandsQueue>();
        var mainBuilding = GetComponent<MainBuilding>();
        queue.EnqueueCommand(new MoveCommand(mainBuilding.GatheringPoint));
    }
}
