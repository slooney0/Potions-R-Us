using UnityEngine;
using UnityEngine.UI;

public class NewGame : MonoBehaviour
{

    [SerializeField] Button newGame;

    void Start()
    {
        newGame.onClick.AddListener(NewGameButton);
    }


    private void NewGameButton()
    {
        ScenesManager.instance.LoadScene(ScenesManager.Scene.Main);
    }

}
