using UnityEngine;
using UnityEngine.UI;
using UniRx;
using Zenject;

public class MenuPresenter : MonoBehaviour
{
    [SerializeField] private Button _backButton;
    [SerializeField] private Button _exitButton;

    [Inject]
    private void Init(ITimeModel timeModel)
    {
        _backButton.OnClickAsObservable().Subscribe(_ => gameObject.SetActive(false));
        _exitButton.OnClickAsObservable().Subscribe(_ => Application.Quit());
    }

}