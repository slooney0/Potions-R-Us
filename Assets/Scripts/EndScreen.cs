using TMPro;
using UnityEngine;

public class EndScreen : MonoBehaviour
{

    public TextMeshProUGUI scoreText;

    private void Start()
    {
        scoreText.text = "You got: " + ScenesManager.score;
    }

}
