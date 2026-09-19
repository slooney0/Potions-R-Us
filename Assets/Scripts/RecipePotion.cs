using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public static class RecipePotion
{
    public struct Recipes{
        string name;
        List<Item.ItemType> items;
        Item.PotionType potionType;
    } ;
}
