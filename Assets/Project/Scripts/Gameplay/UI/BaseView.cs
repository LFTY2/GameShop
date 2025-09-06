using UnityEngine;

public class BaseView : MonoBehaviour
{
    [SerializeField] private CanvasGroup _canvasGroup;

    public virtual void Open()
    {
        _canvasGroup.interactable = true;
    }
    
    public virtual void Close()
    {
        _canvasGroup.interactable = false;
    }
}