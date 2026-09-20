using UnityEngine;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{

    public GameObject pauseMenu;

    public Button newGame;

    public static bool isGamePaused = false;

    public static bool reset = false;

    private void Start()
    {
        isGamePaused = false;
        newGame.onClick.AddListener(resetGame);
        pauseMenu.SetActive(false);
    }

    private void Update()
    {
        if ( Input.GetKeyDown(KeyCode.Escape))
        {
            if (!isGamePaused)
            {
                isGamePaused = true;
                pauseMenu.SetActive(true);
                Time.timeScale = 0;
            }
            else if (isGamePaused)
            {
                isGamePaused = false;
                pauseMenu.SetActive(false);
                Time.timeScale = 1;
            }
        }
    }

    private void resetGame()
    {
        reset = true;
        isGamePaused = false;
        Time.timeScale = 1;

        ScenesManager.instance.LoadNewGame();
    }


}
