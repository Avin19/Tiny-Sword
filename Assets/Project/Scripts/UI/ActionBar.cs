using UnityEngine.UI;
using UnityEngine;
using System.Collections.Generic;

public class ActionBar : MonoBehaviour
{
    [SerializeField] private Image _image;
    [SerializeField] private ActionButton _actionButtonPrefab;
    private Color _originalColor;
    private List<ActionButton> actionBtns = new List<ActionButton>();
    private void Awake()
    {
        _originalColor = _image.color;
    }

    public void RegisterAction()
    {
        var actionButtons = Instantiate(_actionButtonPrefab, transform);
        actionBtns.Add(actionButtons);
    }

    public void ClearActions()
    {
        for (int i = actionBtns.Count - 1; i >= 0; i--)
        {
            Destroy(actionBtns[i].gameObject);
            actionBtns.RemoveAt(i);
        }
    }

    public void Show()
    {
        _image.color = _originalColor;
    }
    public void Hide()
    {
        _image.color = new Color(1, 1, 1, 0);
    }
}