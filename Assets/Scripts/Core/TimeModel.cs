using System;
using UniRx;
using UnityEngine;
using Zenject;
public class TimeModel : ITimeModel, ITickable
{
    public IObservable<int> GameTime => _gameTime.Select(f => (int)f);

    public bool IsPaused { get; private set; } 

    private ReactiveProperty<float> _gameTime = new ReactiveProperty<float>();

    public void Tick()
    {
        _gameTime.Value += Time.deltaTime;
    }

    public void PauseGame()
    {
        if (!IsPaused)
        {
            Time.timeScale = 0;
            IsPaused = true;
        }
        else
        {
            Time.timeScale = 1;
            IsPaused = false;
        }
    }
}