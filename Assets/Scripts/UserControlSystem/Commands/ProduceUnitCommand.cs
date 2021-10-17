using UnityEngine;
public class ProduceUnitCommand : IProduceUnitCommand
{
    public GameObject UnitPrefab => _unitPrefab;

    public float TimeToSpawn => 2000f;

    [InjectAsset("Chomper")] private GameObject _unitPrefab;

}