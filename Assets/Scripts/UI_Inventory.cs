using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UI_Inventory : MonoBehaviour
{
    public void ActivateItem(GameObject item)
    {
        ItemObject iObj = item.GetComponent<ItemObject>();
        if (iObj != null)
        {
            iObj.active();
        }

        CanvasGroup cGroup = item.GetComponent<CanvasGroup>();
        cGroup.alpha = 1f;
        cGroup.interactable = true;
        cGroup.blocksRaycasts = true;
    }

}
