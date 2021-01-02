using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject pipePrefab;
    public UnityEngine.UI.Text scoreText;
    public CanvasGroup StartingUI;
    public float restartDelay = 1f;
    public float pipesSpawnDelay = 1f;
    public float pipesInitalX = 15f;
    public float pipesSpacing = 10f;    // Space between pipes in game units
    public float pipesRandRange = 3f;

    bool gameEnded = false;

    public void StartGame()
    {
        Debug.Log("PLAYER STARTED");

        // Fading animation between game states
        StartCoroutine(FadeOutStartingUI());
        scoreText.CrossFadeAlpha(1.0f, 1.0f, false);
        
        InvokeRepeating("SpawnPipes", 0f, pipesSpawnDelay);
    }

    private System.Collections.IEnumerator FadeOutStartingUI()
    {
        for (float i = 1.0f; i >= 0.0f; i -= Time.deltaTime)
        {
            StartingUI.alpha = i;
            yield return null;
        }
    }

    public void SpawnPipes()
    {
        float pipesY = (pipesSpacing / 2);
        float randOffset = Random.Range(-pipesRandRange, pipesRandRange);

        Instantiate(pipePrefab, new Vector2(pipesInitalX, pipesY + randOffset), Quaternion.identity);
        Instantiate(pipePrefab, new Vector2(pipesInitalX, -pipesY + randOffset), Quaternion.identity);
    }

    public void EndGame()
    { 
        if (!gameEnded)
        {
            gameEnded = true;
            Debug.Log("PLAYER DIED");
            Invoke("Restart", restartDelay);
        }
    }

    void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
