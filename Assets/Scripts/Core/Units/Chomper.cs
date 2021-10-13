using UnityEngine;

public class Chomper : MonoBehaviour, ISelectable, IAttackable
{
    [SerializeField] private ChomperConfig _chomperConfig;
    
    public float Health { get; private set; }

    public float MaxHealth { get; private set; }

    public Sprite Icon { get; private set; }

    void Start()
    {
        Health = _chomperConfig.Health;
        MaxHealth = _chomperConfig.MaxHealth;
        Icon = _chomperConfig.Icon;
    }

}
