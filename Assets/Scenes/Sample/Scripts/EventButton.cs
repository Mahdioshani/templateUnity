using TMPro;
using UnityEngine;
using UnityEngine.UI;

public abstract class EventButton : MonoBehaviour
{
    [SerializeField] private GameObject _eventButtonGameObject;
    [SerializeField] private Button _sendEventButton;
    [SerializeField] private TextMeshProUGUI _buttonTitle;

    private void Start()
    {
        _sendEventButton.onClick.AddListener(OnEventButtonClicked);
        var eventName = GetType().Name;
        _eventButtonGameObject.gameObject.name = eventName;
        _buttonTitle.text = eventName;
    }
    private void OnDestroy()
    {
        _sendEventButton.onClick.RemoveListener(OnEventButtonClicked);
    }
    protected abstract void OnEventButtonClicked();
}
