using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainBuilding : MonoBehaviour, ISelectable, IUnitProducer
{
    [SerializeField] private GameObject _unitPrefab;
    [SerializeField] private Transform _unitsParent;
    [SerializeField] BaseBuildingConfig _buildingConfig;
    [SerializeField] private RaceType _raceType;
    [SerializeField] private Outline _outline;
    private float _health;
    private float _maxHealth;
    private Sprite _icon;

    public float Health => _health;

    public float MaxHealth => _maxHealth;

    public Sprite Icon => _icon;


    private void Awake()
    {
        _health = _buildingConfig.Health;
        _maxHealth = _buildingConfig.MaxHealth;
        _icon = _buildingConfig.Icon;
        CheckRaceType(_raceType);
        _outline.enabled = false;
    }

    public void ProduceUnit()
    {
        Instantiate(_unitPrefab, new Vector3(Random.Range(-10, 10), 0,
        Random.Range(-10, 10)), Quaternion.identity, _unitsParent);
    }
    private void CheckRaceType(RaceType raceType)
    {
        switch (raceType)
        {
            case RaceType.Red:
                ChangeColorOfStripes(_buildingConfig.RedRaceMaterial);
                _outline.OutlineColor = Color.red;
                break;
            case RaceType.Blue:
                ChangeColorOfStripes(_buildingConfig.BlueRaceMaterial);
                _outline.OutlineColor = Color.blue;
                break;
            case RaceType.Brown:
                ChangeColorOfStripes(_buildingConfig.BrownRaceMaterial);
                _outline.OutlineColor = Color.gray;
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

    public void ShowOutline(bool state)
    {
        _outline.enabled = state;
    }
}
