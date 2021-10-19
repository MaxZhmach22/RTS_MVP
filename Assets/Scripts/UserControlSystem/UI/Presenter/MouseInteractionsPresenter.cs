using System.Linq;
using UnityEngine;
using UnityEngine.EventSystems;
using Zenject;
using UniRx;
using System;

public class MouseInteractionsPresenter : MonoBehaviour
{
    private enum MouseCLick
    {
        RightMouseClick,
        LeftMouseClick
    }

    [SerializeField] private EventSystem _eventSystem;
    [SerializeField] private Camera _camera;
    [SerializeField] private SelectableValue _selectedObject;
    [SerializeField] private AttackableValue _targetForAttack;
    [SerializeField] private Vector3Value _groundClicksRMB;
    [SerializeField] private Transform _groundTransform;

    private Plane _groundPlane;

    private void Start()
    {
        _groundPlane = new Plane(_groundTransform.up, 0);
        var leftMouseClickStream = Observable.EveryUpdate().Where(_ => Input.GetMouseButtonUp(0));
        leftMouseClickStream.Subscribe(lc => RaycastHit(MouseCLick.LeftMouseClick));
        var rightMouseClickStream = Observable.EveryUpdate().Where(_ => Input.GetMouseButtonUp(1));
        rightMouseClickStream.Subscribe(rc => RaycastHit(MouseCLick.RightMouseClick)); 
    }

    private void RaycastHit(MouseCLick mouseCLick)
    {
        if (_eventSystem.IsPointerOverGameObject())
            return;
        {
            var ray = _camera.ScreenPointToRay(Input.mousePosition);
            var hits = Physics.RaycastAll(ray);

            switch (mouseCLick)
            {
                case MouseCLick.LeftMouseClick:
                    if (WeHit<ISelectable>(hits, out var selectable))
                        _selectedObject.SetValue(selectable);
                    else
                        _selectedObject.SetValue(null);
                    break;
                case MouseCLick.RightMouseClick:
                    if (WeHit<IAttackable>(hits, out var attackable))
                        _targetForAttack.SetValue(attackable);
                    else if (_groundPlane.Raycast(ray, out var enter))
                        _groundClicksRMB.SetValue(ray.origin + ray.direction * enter);
                    break;
            }
        }
    }

    private bool WeHit<T>(RaycastHit[] hits, out T result) where T : class
    {
        result = default;
        if (hits.Length == 0)
        {
            return false;
        }
        result = hits
            .Select(hit => hit.collider.GetComponentInParent<T>())
            .FirstOrDefault(c => c != null);
        return result != default;
    }
}