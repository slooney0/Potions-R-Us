using UnityEngine;

public class trashCan : MonoBehaviour
{

    public GameManager gManager;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Item")
        {
            gManager.loseScore(10);

            collision.gameObject.GetComponent<DragDrop>().newItem.GetComponent<CanvasGroup>().blocksRaycasts = true;

            GameObject.Destroy(collision.gameObject);
        }
    }
}
