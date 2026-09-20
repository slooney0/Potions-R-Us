using TMPro;
using UnityEngine;

public class EndScreen : MonoBehaviour
{

    public TextMeshProUGUI scoreText;

    void Start()
    {
        scoreText.text = "You got: " + ScenesManager.score;
    }

}
