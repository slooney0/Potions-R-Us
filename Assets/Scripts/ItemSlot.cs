using UnityEngine;
using UnityEngine.EventSystems;

public class ItemSlot : MonoBehaviour, IDropHandler
{

    public void OnDrop(PointerEventData eventData)
    {
        //Debug.Log("OnDrop");
        if (eventData.pointerDrag != null)
        {
            //eventData.pointerDrag.gameObject.transform.position = gameObject.transform.position;
            eventData.pointerDrag.GetComponent<DragDrop>().inSlot = true;
            //eventData.pointerDrag.GetComponent<Rigidbody2D>().gravityScale = 0f;
            //eventData.pointerDrag.GetComponent<Rigidbody2D>().linearVelocity = Vector2.zero;
        }
    }
}
