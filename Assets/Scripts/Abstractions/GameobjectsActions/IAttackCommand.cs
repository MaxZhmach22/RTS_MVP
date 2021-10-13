public interface IAttackCommand : ICommand
{
    ISelectable Target { get; }
}