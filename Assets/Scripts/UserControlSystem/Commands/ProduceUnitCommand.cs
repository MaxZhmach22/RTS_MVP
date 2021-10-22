using UnityEngine;
using Zenject;

public class ProduceUnitCommand : IProduceUnitCommand
{
    [Inject(Id = "Chomper")] public string UnitName { get; }
    [Inject(Id = "Chomper")] public Sprite Icon { get; }
    [Inject(Id = "Chomper")] public float ProductionTime { get; }
    public GameObject UnitPrefab => _unitPrefab;

    public int TimeToSpawn => 0;

    [InjectAsset("Chomper")] private GameObject _unitPrefab;

}