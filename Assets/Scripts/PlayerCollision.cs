using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    public PlayerMovement playerMovement;
    public Rigidbody2D rb2d;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Pipe Obstacles")
        {
            playerMovement.enabled = false;
            rb2d.isKinematic = true;
            FindObjectOfType<AudioManager>().Play("PlayerDead");
            FindObjectOfType<GameManager>().EndGame();
        }
    }
}
