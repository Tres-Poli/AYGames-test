using UnityEngine;

public abstract class ScreenBase : MonoBehaviour
{
    protected CanvasGroup _group;

    protected void InitBase()
    {
        _group = GetComponent<CanvasGroup>();
    }

    public void Hide(bool hide)
    {
        _group.alpha = hide ? 0f : 1f;
        _group.blocksRaycasts = !hide;
    }
}
