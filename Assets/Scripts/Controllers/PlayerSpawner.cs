using UnityEngine;

public class PlayerSpawner : MonoBehaviour
{
    [SerializeField] private GameObject spawningArea;

    [SerializeField] private GameObject player;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        SignalBus.Instance.OnPlayerRespawned.AddListener(() =>
        {
            Vector3 spawnPosition = new Vector3(
                Random.Range(
                    spawningArea.transform.position.x - spawningArea.transform.localScale.x / 2,
                    spawningArea.transform.position.x + spawningArea.transform.localScale.x / 2),
                Random.Range(
                    spawningArea.transform.position.y - spawningArea.transform.localScale.y / 2,
                    spawningArea.transform.position.y + spawningArea.transform.localScale.y / 2),
                0);
            Instantiate(player, spawnPosition, Quaternion.identity);
        });

    }
}
