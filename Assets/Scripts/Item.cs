using UnityEngine;

public class Item
{
    public enum ItemType
    {
        None,
        Berry,
        Meat,
        WildCarrot,
        BrambleBerries,
        MorelMushroom,
        LambQuarter,
        PricklePear,
        Corn,
        BasilishMeat,
        ChimeraCheese,
        HarpyWing,
        Rat,
        MermaidTail,
        GriffinTenders,

    }

    public enum PotionType
    {
        None,
    }


    public ItemType itemType;
    public int amount;

    public Sprite GetSprite()
    {
        switch (itemType)
        {
            default:                        return ItemAssets.Instance.berrySprite;
            case ItemType.Berry:            return ItemAssets.Instance.berrySprite;
            case ItemType.Meat:             return ItemAssets.Instance.meatSprite;
            case ItemType.WildCarrot:       return ItemAssets.Instance.wildCarrotSprite;
            case ItemType.BrambleBerries:   return ItemAssets.Instance.brambleBerriesSprite;
            case ItemType.MorelMushroom:    return ItemAssets.Instance.morelMushroomSprite;
            case ItemType.LambQuarter:      return ItemAssets.Instance.lambQuarterSprite;
            case ItemType.PricklePear:      return ItemAssets.Instance.pricklePearSprite;
            case ItemType.Corn:             return ItemAssets.Instance.cornSprite;
            case ItemType.BasilishMeat:     return ItemAssets.Instance.basiliskMeatSprite;
            case ItemType.ChimeraCheese:    return ItemAssets.Instance.chimeraCheeseSprite;
            case ItemType.HarpyWing:        return ItemAssets.Instance.harpyWingSprite;
            case ItemType.Rat:              return ItemAssets.Instance.ratSprite;
            case ItemType.MermaidTail:      return ItemAssets.Instance.mermaidTailSprite;
            case ItemType.GriffinTenders:   return ItemAssets.Instance.griffinTendersSprite;
        }
    }
}
