using System;
using UnityEngine;
using Zenject;

[CreateAssetMenu(fileName = nameof(GameSettingsInstaller), menuName = "Installers/" + nameof(GameSettingsInstaller))]
public class GameSettingsInstaller : ScriptableObjectInstaller<GameSettingsInstaller>
{
    [SerializeField] private AssetsContext _legacyContext;
    [SerializeField] private Vector3Value _vector3Value;
    [SerializeField] private AttackableValue _targetForAttack;
    [SerializeField] private SelectableValue _selectableValue;
    public override void InstallBindings()
    {
        Container.Bind<AttackableValue>().FromInstance(_targetForAttack);
        Container.Bind<Vector3Value>().FromInstance(_vector3Value);
        Container.Bind<SelectableValue>().FromInstance(_selectableValue);
        Container.Bind<IAwaitable<Vector3>>().FromInstance(_vector3Value);
        Container.Bind<IAwaitable<IAttackable>>().FromInstance(_targetForAttack);
        Container.Bind<IAwaitable<ISelectable>>().FromInstance(_selectableValue);
        Container.Bind<AssetsContext>().FromInstance(_legacyContext);
        Container.Bind<IObservable<ISelectable>>().FromInstance(_selectableValue);

    }
}