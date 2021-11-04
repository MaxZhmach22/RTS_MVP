using Zenject;
using System;
public sealed class StopCommandCommandCreator : CommandCreatorBase<IStopCommand>
{
    protected override void ClassSpecificCommandCreation(Action<IStopCommand> creationCallback)
        => creationCallback?.Invoke(new StopCommand());
}