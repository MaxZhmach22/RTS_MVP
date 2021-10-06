using UnityEngine;

public class StopCommand : IStopCommand
{
    public void Stop() =>
        Debug.Log("Stopped");
}
