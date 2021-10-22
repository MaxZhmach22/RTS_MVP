using UnityEngine;
public interface IProduceUnitCommand : ICommand, IIconHolder
{
    float ProductionTime { get; }
    Sprite Icon { get; }
    GameObject UnitPrefab { get; }
    string UnitName { get; }
    int TimeToSpawn { get; }
}