using System;
using Zenject;
public class ProduceUnitCommandCommandCreator : CommandCreatorBase<IProduceUnitCommand>
{
    [Inject] private AssetsContext _context;
    [Inject] private DiContainer _diContainer;
    protected override void classSpecificCommandCreation(Action<IProduceUnitCommand> creationCallback)
    {
        var produceUnitCommand = _context.Inject(new ProduceUnitCommandHeir());
        //TODO синтаксис на заметку! У объекта типа DiContainer есть метод Inject, который позволяет прокинуть
        //зависимости в любой момент. Это очень кстати, если мы хотим сами контролировать
        //создание объекта.
        _diContainer.Inject(produceUnitCommand); 
                creationCallback?.Invoke(produceUnitCommand);
    }
}