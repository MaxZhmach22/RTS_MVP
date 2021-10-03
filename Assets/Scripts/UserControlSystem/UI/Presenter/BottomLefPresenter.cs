using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class BottomLefPresenter : MonoBehaviour
{
    [SerializeField] private Image _selectedImage;
    [SerializeField] private Slider _healthSlider;
    [SerializeField] private TextMeshProUGUI _text;
    [SerializeField] private Image _sliderBackground;
    [SerializeField] private Image _sliderFillImage;
    [SerializeField] private SelectableValue _selectedValue;

    private ISelectable _beforeSelectedObject;

    private void Start()
    {
        _selectedValue.OnSelected += OnSelected;
        OnSelected(_selectedValue.CurrentValue);
    }
    private void OnSelected(ISelectable selected)
    {
        _selectedImage.enabled = selected != null;
        _healthSlider.gameObject.SetActive(selected != null);
        _text.enabled = selected != null;
        if (selected != null)
        {
            _beforeSelectedObject = selected;
            _selectedImage.sprite = selected.Icon;
            _text.text = $"{selected.Health}/{selected.MaxHealth}";
            _healthSlider.minValue = 0;
            _healthSlider.maxValue = selected.MaxHealth;
            _healthSlider.value = selected.Health;
            var color = Color.Lerp(Color.red, Color.green, selected.Health /
            (float)selected.MaxHealth);

            _sliderBackground.color = color * 0.5f;
            _sliderFillImage.color = color;
            _sliderFillImage.fillAmount = _healthSlider.value / _healthSlider.maxValue;
            selected.ShowOutline(true);
        }
        else
            CheckBeforeSelectedObject();

    }

    private void CheckBeforeSelectedObject()
    {
        if (_beforeSelectedObject == null)
            return;

        _beforeSelectedObject.ShowOutline(false);
    }
}