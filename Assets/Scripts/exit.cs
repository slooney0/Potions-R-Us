using UnityEngine;
using UnityEngine.UI;

public class exit : MonoBehaviour
{
    [SerializeField] Button exitButton;

    void Start()
    {
        exitButton.onClick.AddListener(NewGameButton);
    }


    private void NewGameButton()
    {
        Application.Quit();
    }
}
