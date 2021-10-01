using System.Collections.Generic;
using UnityEngine;

public class BaseBuildingConfig : ScriptableObject
{
    [field: SerializeField] public float Health { get; private set; }

    [field: SerializeField] public float MaxHealth { get; private set; }

    [field: SerializeField] public Sprite Icon { get; private set; }

    [field: Header("Race Materials")]
    [field: SerializeField] public Material RedRaceMaterial { get; private set; }
    [field: SerializeField] public Material BlueRaceMaterial { get; private set; }
    [field: SerializeField] public Material BrownRaceMaterial { get; private set; }
}