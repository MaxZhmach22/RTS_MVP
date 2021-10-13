using UnityEngine;
using Zenject;

[CreateAssetMenu(fileName = nameof(GameSettingsInstaller) , menuName = "Installers/" + nameof(GameSettingsInstaller))]
public class GameSettingsInstaller : ScriptableObjectInstaller<GameSettingsInstaller>
{
    [SerializeField] private AssetsContext _legacyContext;
    [SerializeField] private Vector3Value _vector3Value;
    [SerializeField] private SelectableValue _targetForAttack;

    public override void InstallBindings()
    {
        Container.Bind<Vector3Value>().FromInstance(_vector3Value);
        Container.Bind<SelectableValue>().FromInstance(_targetForAttack);
        Container.Bind<AssetsContext>().FromInstance(_legacyContext);
        Container.Bind<CommandCreatorBase<IProduceUnitCommand>>()
        .To<ProduceUnitCommandCommandCreator>().AsTransient();
        Container.Bind<CommandCreatorBase<IAttackCommand>>()
        .To<AttackCommandCommandCreator>().AsTransient();
        Container.Bind<CommandCreatorBase<IMoveCommand>>()
        .To<MoveCommandCommandCreator>().AsTransient();
        Container.Bind<CommandCreatorBase<IPatrolCommand>>()
        .To<PatrolCommandCommandCreator>().AsTransient();
        Container.Bind<CommandCreatorBase<IStopCommand>>()
        .To<StopCommandCommandCreator>().AsTransient();
        Container.Bind<CommandButtonsModel>().AsTransient();
    }
}