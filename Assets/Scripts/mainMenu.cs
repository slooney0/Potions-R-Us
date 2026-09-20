using UnityEngine;
using UnityEngine.UI;

public class mainMenu : MonoBehaviour
{
    [SerializeField] Button mainMenuButton;

    void Start()
    {
        mainMenuButton.onClick.AddListener(NewGameButton);
    }


    private void NewGameButton()
    {
        ScenesManager.instance.LoadNewGame();
    }
}
