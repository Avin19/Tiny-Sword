using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class ActionButton : MonoBehaviour
{
    [Header(" Button Image ")]
    [SerializeField] private Image _iconImage;
    [SerializeField] private Button _buttonImage;

    void Oestroy()
    {
        _buttonImage.onClick.RemoveAllListeners();
    }
    public void Init(Sprite icon, UnityAction action)
    {
        _iconImage.sprite = icon;
        _buttonImage.onClick.AddListener(action);


    }

}