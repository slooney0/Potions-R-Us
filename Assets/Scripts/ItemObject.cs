using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class ItemObject : MonoBehaviour
{
    public Item.ItemType type;

    private CanvasGroup cGroup;

    private void Start()
    {
        cGroup = GetComponent<CanvasGroup>();
    }

    public void active()
    {
        cGroup.alpha = 1f;
        cGroup.blocksRaycasts = true;
    }
}
