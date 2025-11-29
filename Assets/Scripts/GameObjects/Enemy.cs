using Assets.Scripts.Player;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float base_y_speed = 3;
    private bool gameOver = false;

    private void Start()
    {
        var rb = GetComponent<Rigidbody2D>();
        rb.linearVelocity = new Vector2(0, -base_y_speed);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && !PlayerObject.Instance.IsInvisible)
        {
            Debug.Log("Enemy collided with Player. Game Over!");
            SignalBus.Instance.OnGameOver.Invoke();
            gameOver = true;
        }
        else if (collision.gameObject.CompareTag("Player") && PlayerObject.Instance.IsInvisible)
        {
            Debug.Log("Enemy collided with Invisible Player. Enemy destroyed!");
            SignalBus.Instance.OnPlayerAteEnemy.Invoke();

            Destroy(gameObject);
        }
    }
}
