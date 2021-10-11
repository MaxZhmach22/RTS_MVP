using UnityEngine;

public class OutlinePresenter : MonoBehaviour
{
    [SerializeField] private SelectableValue _selectable;

    private Outline[] _outlines;
    private ISelectable _currentSelectable;

    private void Start()
    {
        _selectable.OnNewValue += onSelected;
        onSelected(_selectable.CurrentValue);
    }

    private void onSelected(ISelectable selectable)
    {
        if (_currentSelectable == selectable)
            return; 

        _currentSelectable = selectable;
        setSelected(_outlines, false);
        _outlines = null;

        if (selectable != null)
        {
            _outlines = (selectable as
            Component).GetComponentsInParent<Outline>();
            setSelected(_outlines, true);
        }

        static void setSelected(Outline[] selectors, bool value)
        {
            if (selectors != null)
            {
                for (int i = 0; i < selectors.Length; i++)
                {
                    selectors[i].enabled = value;
                }
            }
        }
    }
}

