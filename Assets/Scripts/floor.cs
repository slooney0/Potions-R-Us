using UnityEngine;

public class floor : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public GameManager gManager;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Item")
        {
            gManager.loseScore(25);

            collision.gameObject.GetComponent<DragDrop>().newItem.GetComponent<CanvasGroup>().blocksRaycasts = true;

            GameObject.Destroy(collision.gameObject);
        }
    }
}
