using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class MainBuilding : CommandExecutorBase<IProduceUnitCommand>, ISelectable, IAttackable
{
    [SerializeField] private Transform _unitsParent;
    [SerializeField] BaseBuildingConfig _buildingConfig;
    [SerializeField] private RaceType _raceType;

    private float _health;
    private float _maxHealth;
    private Sprite _icon;

    public float Health => _health;

    public float MaxHealth => _maxHealth;

    public Sprite Icon => _icon;

    public Transform PivotPoint => throw new System.NotImplementedException();

    private void Awake()
    {
        _health = _buildingConfig.Health;
        _maxHealth = _buildingConfig.MaxHealth;
        _icon = _buildingConfig.Icon;
        CheckRaceType(_raceType);
    }

    private void CheckRaceType(RaceType raceType)
    {
        switch (raceType)
        {
            case RaceType.Red:
                ChangeColorOfStripes(_buildingConfig.RedRaceMaterial);
                break;
            case RaceType.Blue:
                ChangeColorOfStripes(_buildingConfig.BlueRaceMaterial);
                break;
            case RaceType.Brown:
                ChangeColorOfStripes(_buildingConfig.BrownRaceMaterial);
                break;
        }
    }

    private void ChangeColorOfStripes(Material material)
    {
        MeshRenderer[] meshRenderers = gameObject.GetComponentsInChildren<MeshRenderer>();
        Material[] newMeshRenderersMaterials = new Material[2];
        int oldMaterial = 0;
        int newMaterial = 1;

        foreach(var meshRenderer in meshRenderers)
        {
            newMeshRenderersMaterials[oldMaterial] = meshRenderer.material;
            newMeshRenderersMaterials[newMaterial] = material;
            meshRenderer.materials = newMeshRenderersMaterials;
        }

    }

    public async override void ExecuteSpecificCommand(IProduceUnitCommand command)
    {
        await Task.Delay((int)command.TimeToSpawn);
        Instantiate(command.UnitPrefab, new Vector3(Random.Range(-10, 10), 0,
        Random.Range(-10, 10)), Quaternion.identity, _unitsParent);
    }
}
