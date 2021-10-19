using System;
using UnityEngine;

[CreateAssetMenu(fileName = nameof(AttackableValue), menuName = "Strategy Game/" + nameof(AttackableValue), order = 0)]
public sealed class AttackableValue : StatelessScriptableObjectValueBase<IAttackable>
{

}
