using System;
using System.Collections;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices.WindowsRuntime;
using TMPro;
using UnityEngine;
using UnityEngine.Rendering.Universal.Internal;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    public bool levelComplete = false;

    public bool gameOver = false;

    private int strikes = 0;

    private float timer;

    private const float MINUTE = 60f;

    private Level currentLevel = Level.Level1;

    public UI_Inventory inventory;

    public TextMeshProUGUI timerText;


    public Image RecipeItem1;

    public Image RecipeItem2;

    public GameObject RecipeItem1Obj;
    public GameObject RecipeItem2Obj;


    public bool isCurrentRecipe3Items = false;

    public Image Item3RecipeItem1;

    public Image Item3RecipeItem2;

    public Image Item3RecipeItem3;

    public GameObject Item3RecipeItem1Obj;
    public GameObject Item3RecipeItem2Obj;
    public GameObject Item3RecipeItem3Obj;



    public GameObject strike1;
    public GameObject strike2;
    public GameObject strike3;

    public GameObject check;
    public GameObject x;
    public TextMeshProUGUI scoreText;

    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

    public AudioSource correctRecipeSound;

    public AudioSource incorrectRecipeSound;

    public AudioSource gameOverSound;


    ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

    public int score = 0;

    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

    public GameObject wildCarrot;
    public GameObject brambleBerries;

    public GameObject morelMushroom;
    public GameObject lambQuarter;
    public GameObject pricklePear;
    public GameObject corn;
    public GameObject basiliskMeat;
    public GameObject chimeraCheese;
    public GameObject harpyWing;
    public GameObject rat;
    public GameObject mermaidTail;
    public GameObject griffinTenders;

    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////



    public enum Level
    {
        Start,
        Level1,
        Level2,
        Level3,
        Level4,
        Level5,
        Level6,
        Level7,
        Level8,
        Level9,
        Level10,
        Level11,
        Level12,
        Level13,
        Level14,
        Level15,
        Level16,
        Level17,
        Level18,
        Level19,
        Level20,
        Level21,
        Level22,
        Level23,
        Level24,
        Level25,
        LevelEnd,

    }

    private void Start()
    {
        Item3RecipeItem1Obj.SetActive(false);
        Item3RecipeItem2Obj.SetActive(false);
        Item3RecipeItem3Obj.SetActive(false);
        RecipeItem1Obj.SetActive(false);
        RecipeItem2Obj.SetActive(false);

        currentLevel = Level.Start;
        nextLevel();
        score = 0;

        strike1.SetActive(false);
        strike2.SetActive(false);
        strike3.SetActive(false);
        check.SetActive(false);
        x.SetActive(false);
}

    private void Update()
    {
        if (!levelComplete && timer >= 0)
        {
            timer -= Time.deltaTime;
            updateTimerText();
        }
        else if (!gameOver && timer <= 0)
        {
            wrongRecipe();
        }
    }

    private void updateTimerText()
    {
        int timeLeft = (int)timer;

        int secondsLeft = timeLeft % 60;
        int minutesLeft = timeLeft / 60;

        if (secondsLeft < 10)
        {
            timerText.text = minutesLeft + ":0" + secondsLeft;
        }
        else
        {
            timerText.text = minutesLeft + ":" + secondsLeft;
        }
    }

    public void wrongRecipe()
    {
        strikes++;
        timer = timeForLevel(); //Maybe remove if too easy
        incorrectRecipeSound.Play();
        
        if (strikes == 1)
        {
            strike1.SetActive(true);

            score -= 50;
            scoreText.text = "-50";
            x.SetActive(true);
            StartCoroutine(waitForSecondsBad());
        }
        else if (strikes == 2)
        {
            strike2.SetActive(true);
            score -= 100;
            scoreText.text = "-100";
            x.SetActive(true);
            StartCoroutine(waitForSecondsBad());
        }
        else if (strikes > 2)
        {

            //Play bomb animation

            gameOverSound.Play();

            score -= 150;
            strike3.SetActive(true);

            RecipeItem1Obj.SetActive(false);
            RecipeItem2Obj.SetActive(false);
            Item3RecipeItem1Obj.SetActive(false);
            Item3RecipeItem2Obj.SetActive(false);
            Item3RecipeItem3Obj.SetActive(false);

            levelComplete = true;
            gameOver = true;

            ScenesManager.instance.LoadScene(ScenesManager.Scene.EndScreenLose);
            //EndScreenBad
        }
    }

    private IEnumerator waitForSecondsBad()
    {
        levelComplete = true;
        RecipeItem1Obj.SetActive(false);
        RecipeItem2Obj.SetActive(false);
        Item3RecipeItem1Obj.SetActive(false);
        Item3RecipeItem2Obj.SetActive(false);
        Item3RecipeItem3Obj.SetActive(false);
        timerText.text = "";
        yield return new WaitForSeconds(2);
        levelComplete = false;
        scoreText.text = "";
        updateCurrentRecipeIm();
        x.SetActive(false);
    }


    public void correctRecipe()
    {
        levelComplete = true;
        correctRecipeSound.Play();
        if (currentLevel == Level.LevelEnd)
        {
            //EndGameGood
            //Scene.EndScreenGood
            ScenesManager.instance.LoadScene(ScenesManager.Scene.EndScreenWin);
        }
        else
        {
            check.SetActive(true);
            scoreText.text = "+" + calculateScore();
            score += calculateScore();
            StopAllCoroutines();
            StartCoroutine(waitForSeconds());
            
        }
    }

    private int calculateScore()
    {
        return (int)timer;
    }

    private IEnumerator waitForSeconds()
    {
        RecipeItem1Obj.SetActive(false);
        RecipeItem2Obj.SetActive(false);
        Item3RecipeItem1Obj.SetActive(false);
        Item3RecipeItem2Obj.SetActive(false);
        Item3RecipeItem3Obj.SetActive(false);
        timerText.text = "";
        yield return new WaitForSeconds(2);
        nextLevel();
    }


    private void nextLevel()
    {
        currentLevel++;
        check.SetActive(false);
        scoreText.text = "";
        levelComplete = false;
        chooseNewLevel();
        unlockNewItems();
        updateCurrentRecipeIm();
        timer = timeForLevel();
        Debug.Log("timer: " + timer);
    }

    private void updateCurrentRecipeIm()
    {
        if (!isCurrentRecipe3Items)
        {
            RecipeItem1Obj.SetActive(true);
            RecipeItem2Obj.SetActive(true);

            RecipeItem1.sprite = (new Item { itemType = Recipe.currentRecipe[0] }).GetSprite();
            RecipeItem2.sprite = (new Item { itemType = Recipe.currentRecipe[1] }).GetSprite();
        }
        else
        {
            Item3RecipeItem1Obj.SetActive(true);
            Item3RecipeItem2Obj.SetActive(true);
            Item3RecipeItem3Obj.SetActive(true);

            Item3RecipeItem1.sprite = (new Item { itemType = Recipe.currentRecipe[0] }).GetSprite();
            Item3RecipeItem2.sprite = (new Item { itemType = Recipe.currentRecipe[1] }).GetSprite();
            Item3RecipeItem3.sprite = (new Item { itemType = Recipe.currentRecipe[2] }).GetSprite();
        }
    }

    private float timeForLevel()
    {
        switch (currentLevel)
        {
            default:
                return (25);
            case Level.Level1 :
                return (5 * MINUTE);
        }
    }

    private void unlockNewItems()
    {
        switch (currentLevel)
        {
            default:
                break;
            case Level.Level1:
                inventory.ActivateItem(wildCarrot);
                inventory.ActivateItem(brambleBerries);
                break;
            case Level.Level3:
                inventory.ActivateItem(morelMushroom);
                break;
            case Level.Level6:
                inventory.ActivateItem(lambQuarter);
                inventory.ActivateItem(pricklePear);
                break;
            case Level.Level11:
                inventory.ActivateItem(corn);
                inventory.ActivateItem(basiliskMeat);
                inventory.ActivateItem(chimeraCheese);
                break;
            case Level.Level19:
                inventory.ActivateItem(harpyWing);
                inventory.ActivateItem(rat);
                inventory.ActivateItem(mermaidTail);
                inventory.ActivateItem(griffinTenders);
                break;
        }
    }

    private void chooseNewLevel()
    {
        float[] percentages = newRecipeRandomizer();

        float rand = UnityEngine.Random.Range(0f, 1f);

        if (rand <= percentages[0])
        {
            int randEasy = UnityEngine.Random.Range(0, Recipe.numberOfTutorialRecipes);
            Debug.Log("randEasy: " + randEasy);
            Recipe.currentRecipe = new Item.ItemType[4] { Recipe.TutorialLevelsRecipes[randEasy, 0], Recipe.TutorialLevelsRecipes[randEasy, 1], Recipe.TutorialLevelsRecipes[randEasy, 2], Recipe.TutorialLevelsRecipes[randEasy, 3] };
        }
        else if (rand <= percentages[0] + percentages[1])
        {
            int randMedium = UnityEngine.Random.Range(0, Recipe.numberOfLevel3to5Recipes);
            Recipe.currentRecipe = new Item.ItemType[4] { Recipe.Level3to5Recipes[randMedium, 0], Recipe.Level3to5Recipes[randMedium, 1], Recipe.Level3to5Recipes[randMedium, 2], Recipe.Level3to5Recipes[randMedium, 3] };
        }
        else if (rand <= percentages[0] + percentages[1] + percentages[2])
        {
            int randHard = UnityEngine.Random.Range(0, Recipe.numberOfLevel6to10Recipes);
            Recipe.currentRecipe = new Item.ItemType[4] { Recipe.Level6to10Recipes[randHard, 0], Recipe.Level6to10Recipes[randHard, 1], Recipe.Level6to10Recipes[randHard, 2], Recipe.Level6to10Recipes[randHard, 3] };
        }
        else if (rand <= percentages[0] + percentages[1] + percentages[2] + percentages[3])
        {
            int randHard = UnityEngine.Random.Range(0, Recipe.numberOfLevel11to15Recipes);
            Recipe.currentRecipe = new Item.ItemType[4] { Recipe.Level11to15Recipes[randHard, 0], Recipe.Level11to15Recipes[randHard, 1], Recipe.Level11to15Recipes[randHard, 2], Recipe.Level11to15Recipes[randHard, 3] };
        }
        else
        {
            int randHard = UnityEngine.Random.Range(0, Recipe.numberOfLevel16to25Recipes);
            Recipe.currentRecipe = new Item.ItemType[4] { Recipe.Level16to25Recipes[randHard, 0], Recipe.Level16to25Recipes[randHard, 1], Recipe.Level16to25Recipes[randHard, 2], Recipe.Level16to25Recipes[randHard, 3] };
        }
        if (Recipe.currentRecipe[3] == Item.ItemType.None)
        {
            isCurrentRecipe3Items = false;
        }
        else
        {
            isCurrentRecipe3Items = true;
        }
    }

    private float[] newRecipeRandomizer()
    {
        switch (currentLevel)
        {
            default: return null;
            case (Level.Level1): return new float[5] { 1, 0, 0, 0, 0 };
            case (Level.Level2): return new float[5] { 1, 0, 0, 0, 0 };
            case (Level.Level3): return new float[5] { 0, 1, 0, 0, 0 };
            case (Level.Level4): return new float[5] { 0, 1, 0, 0, 0 };
            case (Level.Level5): return new float[5] { 0, 1, 0, 0, 0 };
            case (Level.Level6): return new float[5] { 0, 0, 1, 0, 0 };
            case (Level.Level7): return new float[5] { 0, 0, 1, 0, 0 };
            case (Level.Level8): return new float[5] { 0, 0, 1, 0, 0 };
            case (Level.Level9): return new float[5] { 0, 0, 1, 0, 0 };
            case (Level.Level10): return new float[5] { 0, 0, 1, 0, 0 };
            case (Level.Level11): return new float[5] { 0, 0, 0, 1, 0 };
            case (Level.Level12): return new float[5] { 0, 0, 0, 1, 0 };
            case (Level.Level13): return new float[5] { 0, 0, 0, 1, 0 };
            case (Level.Level14): return new float[5] { 0, 0, 0, 1, 0 };
            case (Level.Level15): return new float[5] { 0, 0, 0, 1, 0 };
            case (Level.Level16): return new float[5] { 0, 0, 0, 1, 0 };
            case (Level.Level17): return new float[5] { 0, 0, 0, 1, 0 };
            case (Level.Level18): return new float[5] { 0, 0, 0, 1, 0 };
            case (Level.Level19): return new float[5] { 0, 0, 0, 0, 1 };
            case (Level.Level20): return new float[5] { 0, 0, 0, 0, 1 };
            case (Level.Level21): return new float[5] { 0, 0, 0, 0, 1 };
            case (Level.Level22): return new float[5] { 0, 0, 0, 0, 1 };
            case (Level.Level23): return new float[5] { 0, 0, 0, 0, 1 };
            case (Level.Level24): return new float[5] { 0, 0, 0, 0, 1 };
            case (Level.Level25): return new float[5] { 0, 0, 0, 0, 1 };
            case (Level.LevelEnd): return new float[5] { 0, 0, 0, 0, 1 };
        }
    }
}
