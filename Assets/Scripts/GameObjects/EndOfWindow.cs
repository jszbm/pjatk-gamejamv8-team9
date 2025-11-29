using UnityEngine;

public class EndOfWindow : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            collision.gameObject.SetActive(false);
            SignalBus.Instance.OnPlayerNeedToRespawn.Invoke();
        }

        if (collision.transform.CompareTag("Enemy"))
        {
            Destroy(collision.gameObject);
        }
    }
}
