using UnityEngine;
using UnityEngine.UI;

public class Cauldren : MonoBehaviour
{
    public Image item1;
    public GameObject item1ImageObj;
    public Image item2;
    public GameObject item2ImageObj;


    public Image items3item1;
    public GameObject items3item1ImageObj;

    public Image items3item2;
    public GameObject items3item2ImageObj;

    public Image items3item3;
    public GameObject items3item3ImageObj;

    public Button button;

    public GameObject buttonObj;


    public AudioSource bubbling;
    public AudioSource splash;


    private Item.ItemType item1Obj;
    private Item.ItemType item2Obj;
    private Item.ItemType item3Obj = Item.ItemType.None;

    private bool foundObj1 = false;

    private bool foundObj2 = false;

    private bool foundRecipe = false;

    public GameManager gManager;

    private void Start()
    {
        button.onClick.AddListener(checkRecipe);
        buttonObj.SetActive(false);
        item1ImageObj.SetActive(false);
        item2ImageObj.SetActive(false);

        items3item1ImageObj.SetActive(false);
        items3item2ImageObj.SetActive(false);
        items3item3ImageObj.SetActive(false);
    }

    private void checkRecipe()
    {
        bubbling.Play();

        if (!gManager.isCurrentRecipe3Items)
        {
            if (item3Obj != Item.ItemType.None)
            {
                gManager.wrongRecipe();
                Debug.Log("RecipeNotFound");
            }

            Debug.Log("1");
            if (item1Obj == Recipe.currentRecipe[0]) //Change to current recipe, if we want it to be only the current one
            {
                if (item2Obj == Recipe.currentRecipe[1])
                {
                    foundRecipe = true;
                }
            }
            //else if (item2Obj == Recipe.currentRecipe[0])
            //{
            //    if (item1Obj == Recipe.currentRecipe[1])
            //    {
            //        foundRecipe = true;
            //    }
            //}
            if (!foundRecipe)
            {
                gManager.wrongRecipe();
                Debug.Log("RecipeNotFound");
            }
            else
            {
                gManager.correctRecipe();
                Debug.Log("Found Recipe");
            }
        }
        else
        {
            if (item1Obj == Recipe.currentRecipe[0] && item2Obj == Recipe.currentRecipe[1] && item3Obj == Recipe.currentRecipe[2])
            {
                gManager.correctRecipe();
            }
            else
            {
                gManager.wrongRecipe();
            }
        }

        Reset();
    }

    private void Reset()
    {
        buttonObj.SetActive(false);
        item1ImageObj.SetActive(false);
        item2ImageObj.SetActive(false);

        items3item1ImageObj.SetActive(false);
        items3item2ImageObj.SetActive(false);
        items3item3ImageObj.SetActive(false);

        foundObj1 = false;
        foundObj2 = false;

        item1Obj = Item.ItemType.None;
        item2Obj = Item.ItemType.None;
        item3Obj = Item.ItemType.None;

        foundRecipe = false;
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Item")
        {
            //Debug.Log("Yay");
            splash.Play();

            Item item = (new Item { itemType = collision.gameObject.GetComponent<ItemObject>().type });

            collision.gameObject.GetComponent<DragDrop>().newItem.GetComponent<CanvasGroup>().blocksRaycasts = true;

            GameObject.Destroy(collision.gameObject);

            if (!gManager.isCurrentRecipe3Items)
            {
                if (!foundObj1)
                {
                    item1Obj = item.itemType;
                    item1ImageObj.SetActive(true);
                    item1.sprite = item.GetSprite();
                    foundObj1 = true;
                }
                else
                {
                    item2Obj = item.itemType;
                    item2ImageObj.SetActive(true);
                    item2.sprite = item.GetSprite();
                    buttonObj.SetActive(true);
                }
            }
            else
            {
                Debug.Log("Good");
                if (!foundObj1)
                {
                    item1Obj = item.itemType;
                    items3item1ImageObj.SetActive(true);
                    items3item1.sprite = item.GetSprite();
                    foundObj1 = true;
                }
                else if (!foundObj2)
                {
                    item2Obj = item.itemType;
                    items3item2ImageObj.SetActive(true);
                    items3item2.sprite = item.GetSprite();
                    buttonObj.SetActive(true);
                    foundObj2 = true;
                }
                else
                {
                    item3Obj = item.itemType;
                    items3item3ImageObj.SetActive(true);
                    items3item3.sprite = item.GetSprite();
                }
            }
        }
    }
}
