using Zenject;
using System;
using System.Threading;

public class AttackCommandCommandCreator : CancellableCommandCreatorBase<IAttackCommand, IAttackable>
{
    protected override IAttackCommand createCommand(IAttackable argument) => new
        AttackCommand(argument);
}
