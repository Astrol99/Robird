using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public Text scoreText;
    [HideInInspector]
    public int score = 0;

    private void Start()
    {
        scoreText.CrossFadeAlpha(0.0f, 0.0f, false);
    }

    private void Update()
    {
        scoreText.text = (score / 2).ToString(); // Divide by 2 to account for two pipes at same X pos
    }
}
