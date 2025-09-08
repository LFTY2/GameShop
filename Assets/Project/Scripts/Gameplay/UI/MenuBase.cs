using UnityEngine;

public class MenuBase : MonoBehaviour
{
    [SerializeField] private CanvasGroup _canvasGroup;

#if UnityEditor
    private void OnValidate()
    {
        if (_canvasGroup!=null)
        {
            _canvasGroup = GetComponent<CanvasGroup>();
        }
    }
#endif
    public virtual void Open()
    {
        _canvasGroup.interactable = true;
    }
    
    public virtual void Close()
    {
        _canvasGroup.interactable = false;
    }
}