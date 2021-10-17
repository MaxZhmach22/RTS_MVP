using System.Collections.Generic;
using UnityEngine;

public class BaseUnitConfig : ScriptableObject
{
    [field: SerializeField] public float Health { get; private set; }

    [field: SerializeField] public float MaxHealth { get; private set; }

    [field: SerializeField] public Sprite Icon { get; private set; }

    [field: SerializeField] public float TimeToSpawn { get; private set; }

}