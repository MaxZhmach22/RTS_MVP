/// <summary>
/// Чтобы юниту атаковать кого-то, нужна система определения «свой-чужой». 
/// </summary>
public interface IFactionMember
{
    int FactionId { get; }
}