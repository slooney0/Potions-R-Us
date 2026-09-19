using UnityEngine;
using UnityEngine.EventSystems;

public class DragDrop : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler {

    private Canvas canvas;
    private RectTransform rectTransform;
    private CanvasGroup canvasGroup;

    public Transform parent;

    public GameObject newItem;

    public bool inSlot = false;


    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
        canvas = GameObject.FindGameObjectWithTag("Canvas").GetComponent<Canvas>();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        //Debug.Log("OnBeginDrag");
        canvasGroup.blocksRaycasts = false;
        canvasGroup.alpha = 0.6f;
        if (inSlot && eventData.pointerDrag != null)
        {
            newItem = Instantiate(eventData.pointerDrag.gameObject, parent);
            CanvasGroup cGroup = newItem.GetComponent<CanvasGroup>();
            cGroup.blocksRaycasts = false;
            cGroup.alpha = 1f;
            //Debug.Log("NewItem");
        }
        inSlot = false;
        if (eventData.pointerDrag != null)
        {
            eventData.pointerDrag.GetComponent<Rigidbody2D>().gravityScale = 0f;
            eventData.pointerDrag.GetComponent<Rigidbody2D>().linearVelocity = Vector2.zero;
            //Debug.Log("Gravity");
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        //Debug.Log("OnDrag");
        rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
    }

    public void OnEndDrag(PointerEventData eventData) //Might need to fix when cauldren is added
    {
        //Debug.Log("OnEndDrag");
        canvasGroup.blocksRaycasts = true;
        canvasGroup.alpha = 1f;

        if (newItem != null)
        {
            newItem.GetComponent<CanvasGroup>().blocksRaycasts = true;
        }

        if (eventData.pointerDrag != null && !inSlot)
        {
            eventData.pointerDrag.GetComponent<Rigidbody2D>().gravityScale = 30f;
        }
        else if (eventData.pointerDrag != null && inSlot)
        {
            GameObject.Destroy(eventData.pointerDrag.gameObject);
        }
    }

    public void OnPointerDown(PointerEventData eventData) {
        //Debug.Log("OnPointerDown");
    }
}
