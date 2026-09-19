using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class ItemObject : MonoBehaviour
{
    public Item.ItemType type;

    public GameObject lockObj;

    public bool isLocked;

    public void unlock()
    {
        isLocked = false;
        lockObj.SetActive(false);
    }
}
