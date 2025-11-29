using UnityEngine;

public class Enemy : MonoBehaviour
{
    private bool gameOver = false;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && !gameOver)
        {
            Debug.Log("Enemy collided with Player. Game Over!");
            SignalBus.Instance.OnGameOver.Invoke();
            gameOver = true;
        }
    }
}
