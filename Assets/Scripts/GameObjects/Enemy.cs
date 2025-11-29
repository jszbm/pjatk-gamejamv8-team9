using UnityEngine;

public class Enemy : MonoBehaviour
{
    private bool gameOver = false;

    [SerializeField] private float base_y_speed = 3;

    private void Start()
    {
        var rb = GetComponent<Rigidbody2D>();
        rb.linearVelocity = new Vector2(0, -base_y_speed);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && !gameOver)
        {
            Debug.Log("Enemy collided with Player. Game Over!");
            SignalBus.Instance.OnGameOver.Invoke();
            gameOver = true;
        }
    }
}
