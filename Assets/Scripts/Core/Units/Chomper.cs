using UnityEngine;

public class Chomper : MonoBehaviour, ISelectable, IAttackable
{
    [SerializeField] private ChomperConfig _chomperConfig;
    
    private float _timeToSpawn;
    public float Health { get; private set; }

    public float MaxHealth { get; private set; }

    public Sprite Icon { get; private set; }

    public float TimeToSpawn => _timeToSpawn;

    public Transform PivotPoint => throw new System.NotImplementedException();

    void Start()
    {
        Health = _chomperConfig.Health;
        MaxHealth = _chomperConfig.MaxHealth;
        Icon = _chomperConfig.Icon;
        _timeToSpawn = _chomperConfig.TimeToSpawn;
    }

}
