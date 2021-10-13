using System.Linq;
using UnityEngine;
using UnityEngine.EventSystems;
using System;

public class KeyboardInteractionsPresenter : MonoBehaviour
{
    public bool KeyIsPressed { get; private set; }
    public Action<bool> PKeyIsPrerssed;
    public Action<bool> SKeyIsPrerssed;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            KeyIsPressed = true;
            PKeyIsPrerssed?.Invoke(KeyIsPressed);
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            KeyIsPressed = true;
            SKeyIsPrerssed?.Invoke(KeyIsPressed);
        }
    }
}