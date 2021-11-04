using UnityEngine;
public interface IGatheringPoint : ICommand
{
    Vector3 GatheringPoint { get; }
}