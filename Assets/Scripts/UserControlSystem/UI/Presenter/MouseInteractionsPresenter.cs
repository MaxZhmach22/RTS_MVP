using System.Linq;
using UnityEngine;
using UnityEngine.EventSystems;
using Zenject;
public class MouseInteractionsPresenter : MonoBehaviour
{
    [SerializeField] private EventSystem _eventSystem;
    [SerializeField] private Camera _camera;
    [SerializeField] private SelectableValue _selectedObject;
    [SerializeField] private SelectableValue _targetForAttack;
    [SerializeField] private Vector3Value _groundClicksRMB;
    [SerializeField] private Transform _groundTransform;

    private Plane _groundPlane;

    private void Start()
    {
        _groundPlane = new Plane(_groundTransform.up, 0);
    }

    private void Update()
    {
        if (!Input.GetMouseButtonUp(0) && !Input.GetMouseButton(1))
            return;
        if (_eventSystem.IsPointerOverGameObject())
            return;

        var ray = _camera.ScreenPointToRay(Input.mousePosition);

        if (Input.GetMouseButtonUp(0))
        {
            var selectable = CheckClickedObject(ray);
            _selectedObject.SetValue(selectable);
        }
        else
        {
            if (_groundPlane.Raycast(ray, out var enter))
                _groundClicksRMB.SetValue(ray.origin + ray.direction * enter); //TODO 1.Устанавливаем значение в Vector3value
            var selectable = CheckClickedObject(ray);
            if (selectable != _selectedObject.CurrentValue)
                _targetForAttack.SetValue(selectable);
        }
    }

    private ISelectable CheckClickedObject(Ray ray)
    {
        var hits = Physics.RaycastAll(ray);
        if (hits.Length == 0)
        {
            return null;
        }
        var selectable = hits
        .Select(hit =>
        hit.collider.GetComponentInParent<ISelectable>())
        .Where(c => c != null)
        .FirstOrDefault();
        return selectable;
    }
}