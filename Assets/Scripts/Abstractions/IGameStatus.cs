using System;

/// <summary>
/// Абстракция статуса игры
/// </summary>
public interface IGameStatus
{
    IObservable<int> Status { get; }
}