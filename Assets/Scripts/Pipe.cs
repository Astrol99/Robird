using UnityEngine;

public class Pipe : MonoBehaviour
{
    public float speed = 5f;
    public float selfDestroyDelay = 10f;
    private bool updatedScore = false;

    private void Start()
    {
        Destroy(gameObject, selfDestroyDelay);
    }

    private void FixedUpdate()
    {
        transform.Translate(Vector2.left * Time.deltaTime * speed);

        if (transform.position.x < 0 && !updatedScore)
        {
            FindObjectOfType<Score>().score += 1;
            FindObjectOfType<AudioManager>().Play("PlayerScore");
            updatedScore = true;
        }
    }
}
