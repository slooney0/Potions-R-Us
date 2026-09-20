using System;
using UnityEngine;

public static class Recipe
{

    public static int numberOfRecipes = 2;
    public static int numberOfTutorialRecipes = 4;
    public static int numberOfLevel3to5Recipes = 8;
    public static int numberOfLevel6to10Recipes = 10;
    public static int numberOfLevel11to15Recipes = 13;
    public static int numberOfLevel16to25Recipes = 25;

    public static Item.ItemType[,] Recipes = new Item.ItemType[2,4] { 
        { Item.ItemType.Meat, Item.ItemType.Meat, Item.ItemType.Berry, Item.ItemType.None },
        { Item.ItemType.Berry, Item.ItemType.Meat, Item.ItemType.Berry, Item.ItemType.None }
    };

    public static Item.ItemType[,] TutorialLevelsRecipes = new Item.ItemType[4, 4]
    {
        { Item.ItemType.WildCarrot, Item.ItemType.WildCarrot, Item.ItemType.Berry, Item.ItemType.None },
        { Item.ItemType.WildCarrot, Item.ItemType.BrambleBerries, Item.ItemType.Berry, Item.ItemType.None },
        { Item.ItemType.BrambleBerries, Item.ItemType.WildCarrot, Item.ItemType.Berry, Item.ItemType.None },
        { Item.ItemType.BrambleBerries, Item.ItemType.BrambleBerries, Item.ItemType.Berry, Item.ItemType.None }
    };

    public static Item.ItemType[,] Level3to5Recipes = new Item.ItemType[8, 4]
    {
        { Item.ItemType.MorelMushroom, Item.ItemType.MorelMushroom, Item.ItemType.Berry, Item.ItemType.None },
        { Item.ItemType.MorelMushroom, Item.ItemType.WildCarrot, Item.ItemType.Berry, Item.ItemType.None },
        { Item.ItemType.MorelMushroom, Item.ItemType.MorelMushroom, Item.ItemType.WildCarrot, Item.ItemType.Berry },
        { Item.ItemType.BrambleBerries, Item.ItemType.MorelMushroom, Item.ItemType.WildCarrot, Item.ItemType.Berry },
        { Item.ItemType.WildCarrot, Item.ItemType.WildCarrot, Item.ItemType.BrambleBerries, Item.ItemType.Berry },
        { Item.ItemType.WildCarrot, Item.ItemType.WildCarrot, Item.ItemType.WildCarrot, Item.ItemType.Berry },
        { Item.ItemType.BrambleBerries, Item.ItemType.BrambleBerries, Item.ItemType.BrambleBerries, Item.ItemType.Berry },
        { Item.ItemType.MorelMushroom, Item.ItemType.WildCarrot, Item.ItemType.BrambleBerries, Item.ItemType.Berry }
    };

    public static Item.ItemType[,] Level6to10Recipes = new Item.ItemType[10, 4]
    {
        { Item.ItemType.LambQuarter, Item.ItemType.LambQuarter, Item.ItemType.LambQuarter, Item.ItemType.Berry },
        { Item.ItemType.LambQuarter, Item.ItemType.PricklePear, Item.ItemType.BrambleBerries, Item.ItemType.Berry },
        { Item.ItemType.PricklePear, Item.ItemType.BrambleBerries, Item.ItemType.PricklePear, Item.ItemType.Berry },
        { Item.ItemType.LambQuarter, Item.ItemType.WildCarrot, Item.ItemType.LambQuarter, Item.ItemType.Berry },
        { Item.ItemType.PricklePear, Item.ItemType.LambQuarter, Item.ItemType.PricklePear, Item.ItemType.Berry },
        { Item.ItemType.MorelMushroom, Item.ItemType.PricklePear, Item.ItemType.WildCarrot, Item.ItemType.Berry },
        { Item.ItemType.MorelMushroom, Item.ItemType.PricklePear, Item.ItemType.LambQuarter, Item.ItemType.Berry },
        { Item.ItemType.PricklePear, Item.ItemType.PricklePear, Item.ItemType.BrambleBerries, Item.ItemType.Berry },
        { Item.ItemType.LambQuarter, Item.ItemType.PricklePear, Item.ItemType.MorelMushroom, Item.ItemType.Berry },
        { Item.ItemType.BrambleBerries, Item.ItemType.MorelMushroom, Item.ItemType.WildCarrot, Item.ItemType.Berry }
    };

    public static Item.ItemType[,] Level11to15Recipes = new Item.ItemType[13, 4]
    {
        { Item.ItemType.Corn, Item.ItemType.Corn, Item.ItemType.Corn, Item.ItemType.Berry },
        { Item.ItemType.BasilishMeat, Item.ItemType.BasilishMeat, Item.ItemType.BasilishMeat, Item.ItemType.Berry },
        { Item.ItemType.ChimeraCheese, Item.ItemType.ChimeraCheese, Item.ItemType.ChimeraCheese, Item.ItemType.Berry },
        { Item.ItemType.Corn, Item.ItemType.LambQuarter, Item.ItemType.BasilishMeat, Item.ItemType.Berry },
        { Item.ItemType.ChimeraCheese, Item.ItemType.Corn, Item.ItemType.BrambleBerries, Item.ItemType.Berry },
        { Item.ItemType.PricklePear, Item.ItemType.BasilishMeat, Item.ItemType.Corn, Item.ItemType.Berry },
        { Item.ItemType.LambQuarter, Item.ItemType.WildCarrot, Item.ItemType.LambQuarter, Item.ItemType.Berry },
        { Item.ItemType.PricklePear, Item.ItemType.Corn, Item.ItemType.ChimeraCheese, Item.ItemType.Berry },
        { Item.ItemType.Corn, Item.ItemType.ChimeraCheese, Item.ItemType.ChimeraCheese, Item.ItemType.Berry },
        { Item.ItemType.BasilishMeat, Item.ItemType.PricklePear, Item.ItemType.LambQuarter, Item.ItemType.Berry },
        { Item.ItemType.PricklePear, Item.ItemType.PricklePear, Item.ItemType.Corn, Item.ItemType.Berry },
        { Item.ItemType.ChimeraCheese, Item.ItemType.PricklePear, Item.ItemType.MorelMushroom, Item.ItemType.Berry },
        { Item.ItemType.BrambleBerries, Item.ItemType.BasilishMeat, Item.ItemType.ChimeraCheese, Item.ItemType.Berry }
    };

    public static Item.ItemType[,] Level16to25Recipes = new Item.ItemType[25, 4]
    {
        { Item.ItemType.MermaidTail, Item.ItemType.Corn, Item.ItemType.Corn, Item.ItemType.Berry },
        { Item.ItemType.BasilishMeat, Item.ItemType.HarpyWing, Item.ItemType.Corn, Item.ItemType.Berry },
        { Item.ItemType.Corn, Item.ItemType.ChimeraCheese, Item.ItemType.HarpyWing, Item.ItemType.Berry },
        { Item.ItemType.Corn, Item.ItemType.Rat, Item.ItemType.BasilishMeat, Item.ItemType.Berry },
        { Item.ItemType.HarpyWing, Item.ItemType.Corn, Item.ItemType.MermaidTail, Item.ItemType.Berry },
        { Item.ItemType.LambQuarter, Item.ItemType.HarpyWing, Item.ItemType.Corn, Item.ItemType.Berry },
        { Item.ItemType.LambQuarter, Item.ItemType.WildCarrot, Item.ItemType.HarpyWing, Item.ItemType.Berry },
        { Item.ItemType.PricklePear, Item.ItemType.Rat, Item.ItemType.ChimeraCheese, Item.ItemType.Berry },
        { Item.ItemType.Corn, Item.ItemType.ChimeraCheese, Item.ItemType.ChimeraCheese, Item.ItemType.Berry },
        { Item.ItemType.MermaidTail, Item.ItemType.PricklePear, Item.ItemType.LambQuarter, Item.ItemType.Berry },
        { Item.ItemType.Rat, Item.ItemType.LambQuarter, Item.ItemType.Corn, Item.ItemType.Berry },
        { Item.ItemType.ChimeraCheese, Item.ItemType.Rat, Item.ItemType.MermaidTail, Item.ItemType.Berry },
        { Item.ItemType.HarpyWing, Item.ItemType.Corn, Item.ItemType.Corn, Item.ItemType.Berry },
        { Item.ItemType.BasilishMeat, Item.ItemType.HarpyWing, Item.ItemType.BasilishMeat, Item.ItemType.Berry },
        { Item.ItemType.ChimeraCheese, Item.ItemType.ChimeraCheese, Item.ItemType.HarpyWing, Item.ItemType.Berry },
        { Item.ItemType.Corn, Item.ItemType.Rat, Item.ItemType.BasilishMeat, Item.ItemType.Berry },
        { Item.ItemType.HarpyWing, Item.ItemType.Corn, Item.ItemType.MermaidTail, Item.ItemType.Berry },
        { Item.ItemType.PricklePear, Item.ItemType.HarpyWing, Item.ItemType.Rat, Item.ItemType.Berry },
        { Item.ItemType.LambQuarter, Item.ItemType.WildCarrot, Item.ItemType.LambQuarter, Item.ItemType.Berry },
        { Item.ItemType.Corn, Item.ItemType.ChimeraCheese, Item.ItemType.Corn, Item.ItemType.Berry },
        { Item.ItemType.MermaidTail, Item.ItemType.Rat, Item.ItemType.LambQuarter, Item.ItemType.Berry },
        { Item.ItemType.PricklePear, Item.ItemType.PricklePear, Item.ItemType.Corn, Item.ItemType.Berry },
        { Item.ItemType.MermaidTail, Item.ItemType.PricklePear, Item.ItemType.MorelMushroom, Item.ItemType.Berry },
        { Item.ItemType.Rat, Item.ItemType.Rat, Item.ItemType.ChimeraCheese, Item.ItemType.Berry },
        { Item.ItemType.HarpyWing, Item.ItemType.BasilishMeat, Item.ItemType.MermaidTail, Item.ItemType.Berry }
    };

    public static Item.ItemType[] currentRecipe = null; 
}
