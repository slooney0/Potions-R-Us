using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ItemAssets : MonoBehaviour
{
    public static ItemAssets Instance { get; private set; }

    private void Awake()
    {
        Instance = this;
    }

    public Sprite berrySprite;
    public Sprite meatSprite;

    public Sprite wildCarrotSprite;
    public Sprite brambleBerriesSprite;
    public Sprite morelMushroomSprite;
    public Sprite lambQuarterSprite;
    public Sprite pricklePearSprite;
    public Sprite cornSprite;
    public Sprite basiliskMeatSprite;
    public Sprite chimeraCheeseSprite;
    public Sprite harpyWingSprite;
    public Sprite ratSprite;
    public Sprite mermaidTailSprite;
    public Sprite griffinTendersSprite;

    public GameObject pfItem;
}
