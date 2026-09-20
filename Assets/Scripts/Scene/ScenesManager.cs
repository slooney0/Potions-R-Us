using UnityEngine;
using UnityEngine.SceneManagement;

public class ScenesManager : MonoBehaviour
{
    public static ScenesManager instance;

    public static int scenesChanged = 0;

    public static int score = 0;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(this.gameObject);
    }

    public enum Scene
    {
        MainMenu,
        Main, 
        EndScreenLose,
        EndScreenWin,

    }

    public void LoadScene(Scene scene)
    {
        SceneManager.LoadScene(scene.ToString());
        scenesChanged++;
    }

    public void LoadNewGame()
    {
        SceneManager.LoadScene(Scene.MainMenu.ToString());
        scenesChanged++;
    }

    public void LoadNextScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        scenesChanged++;
    }

    public int getCurrentScene()
    {
        return SceneManager.GetActiveScene().buildIndex;
    }
}
