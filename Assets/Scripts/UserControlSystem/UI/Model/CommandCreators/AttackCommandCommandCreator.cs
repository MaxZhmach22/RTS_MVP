using Zenject;
using System;
using System.Threading;

public sealed class AttackCommandCommandCreator : CancellableCommandCreatorBase<IAttackCommand, IAttackable>
{
    protected override IAttackCommand CreateCommand(IAttackable argument) => new AttackCommand(argument);
}
