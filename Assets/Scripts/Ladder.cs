using UnityEngine;

public class Ladder : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.gameObject.CompareTag("Player")) return;

        other.gameObject.GetComponent<Rigidbody2D>().gravityScale = 0;
        other.gameObject.GetComponent<Player>().onLadder = true;
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (!other.gameObject.CompareTag("Player")) return;

        other.gameObject.GetComponent<Rigidbody2D>().gravityScale = 0;
        other.gameObject.GetComponent<Player>().onLadder = true;
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (!other.gameObject.CompareTag("Player")) return;

        other.gameObject.GetComponent<Rigidbody2D>().gravityScale = 3;
        other.gameObject.GetComponent<Player>().onLadder = false;
    }
}