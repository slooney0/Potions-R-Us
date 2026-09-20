using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Cauldren : MonoBehaviour
{
    public Image item1;
    public GameObject item1ImageObj;
    public Image item2;
    public GameObject item2ImageObj;

    public Image cauldronWater;

    public Image items3item1;
    public GameObject items3item1ImageObj;

    public Image items3item2;
    public GameObject items3item2ImageObj;

    public Image items3item3;
    public GameObject items3item3ImageObj;

    public Button button;

    public Button dumpButton;

    public GameObject buttonObj;

    public GameObject dumpButtonObj;


    public AudioSource bubbling;
    public AudioSource splash;


    private Item.ItemType item1Obj;
    private Item.ItemType item2Obj;
    private Item.ItemType item3Obj = Item.ItemType.None;

    private bool foundObj1 = false;

    private bool foundObj2 = false;

    private bool foundObj3 = false;

    private bool foundRecipe = false;

    private Color[] colorPalette = new Color[20];


    public GameManager gManager;

    private void Start()
    {
        button.onClick.AddListener(checkRecipe);
        dumpButton.onClick.AddListener(buttonDump);

        buttonObj.SetActive(false);
        dumpButtonObj.SetActive(false);
        item1ImageObj.SetActive(false);
        item2ImageObj.SetActive(false);

        items3item1ImageObj.SetActive(false);
        items3item2ImageObj.SetActive(false);
        items3item3ImageObj.SetActive(false);

        colors();
    }

    private void colors()
    {
        colorPalette[0] = new Color(122, 35, 41);
        colorPalette[1] = new Color(54, 92, 118);
        colorPalette[2] = new Color(41, 64, 86);
        colorPalette[3] = new Color(59, 92, 124);
        colorPalette[4] = new Color(64, 122, 82);
        colorPalette[5] = new Color(196, 98, 51);
        colorPalette[6] = new Color(183, 90, 46);
        colorPalette[7] = new Color(82, 140, 100);
        colorPalette[8] = new Color(122, 90, 138);
        colorPalette[9] = new Color(189, 139, 214);
        colorPalette[10] = new Color(225, 166, 174);
        colorPalette[11] = new Color(255, 230, 90);
        colorPalette[12] = new Color(96, 191, 123);
        colorPalette[13] = new Color(112, 171, 236);
        colorPalette[14] = new Color(121, 148, 255);
        colorPalette[15] = new Color(146, 121, 255);
        colorPalette[16] = new Color(255, 121, 121);
        colorPalette[17] = new Color(121, 255, 201);
        colorPalette[18] = new Color(121, 204, 255);
        colorPalette[19] = new Color(255, 176, 30);
    }


    private void checkRecipe()
    {
        bubbling.Play();

        if (!gManager.isCurrentRecipe3Items)
        {
            if (item3Obj != Item.ItemType.None)
            {
                gManager.wrongRecipe();
            }

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
            }
            else
            {
                gManager.correctRecipe();
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

    private void buttonDump()
    {
        if (!foundObj2)
        {
            gManager.loseScore(10);
        }
        else if (!foundObj3)
        {
            gManager.loseScore(20);
        }
        else
        {
            gManager.loseScore(30);
        }
        
        Reset();
    }

    public void Reset()
    {
        buttonObj.SetActive(false);
        dumpButtonObj.SetActive(false);
        item1ImageObj.SetActive(false);
        item2ImageObj.SetActive(false);

        items3item1ImageObj.SetActive(false);
        items3item2ImageObj.SetActive(false);
        items3item3ImageObj.SetActive(false);

        foundObj1 = false;
        foundObj2 = false;
        foundObj3 = false;

        item1Obj = Item.ItemType.None;
        item2Obj = Item.ItemType.None;
        item3Obj = Item.ItemType.None;

        foundRecipe = false;
    }

    private void changeCauldronColor()
    {
        int randColor = Random.Range(0, colorPalette.Length);
        cauldronWater.color = new Color(colorPalette[randColor].r / 255f, colorPalette[randColor].g / 255f, colorPalette[randColor].b / 255f);
        Debug.Log("color: " +  cauldronWater.color);
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Item")
        {
            //Debug.Log("Yay");
            splash.Play();
            changeCauldronColor();

            Item item = (new Item { itemType = collision.gameObject.GetComponent<ItemObject>().type });

            collision.gameObject.GetComponent<DragDrop>().newItem.GetComponent<CanvasGroup>().blocksRaycasts = true;

            GameObject.Destroy(collision.gameObject);

            if (!gManager.isCurrentRecipe3Items)
            {
                if (!foundObj1)
                {
                    dumpButtonObj.SetActive(true);
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
                if (!foundObj1)
                {
                    dumpButtonObj.SetActive(true);
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
                    foundObj3 = true;
                }
            }
        }
    }
}
