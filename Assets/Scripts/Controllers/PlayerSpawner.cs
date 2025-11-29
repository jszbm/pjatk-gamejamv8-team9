using UnityEngine;

public class PlayerSpawner : MonoBehaviour
{
    [SerializeField] private GameObject spawningArea;

    [SerializeField] private GameObject player;
    private Transform[] spawnPoints;

    void Start()
    {
        spawnPoints = spawningArea.GetComponentsInChildren<Transform>();
        if (spawnPoints.Length != 3)
        {
            Debug.LogError("Spawning area must have at least two child points to define spawn range.");
        }

        SignalBus.Instance.OnPlayerNeedToRespawn.AddListener(PlayerRespawn);
    }

    private void PlayerRespawn()
    {
        var spawnPosition = new Vector3(Random.Range(spawnPoints[1].transform.position.x, spawnPoints[2].transform.position.x), spawningArea.transform.position.y, 0);

        player.transform.position = spawnPosition;
        player.SetActive(true);

        SignalBus.Instance.OnPlayerRespawned.Invoke();
    }

    private void OnDestroy()
    {
        if (SignalBus.Instance != null)
        {
            SignalBus.Instance.OnPlayerNeedToRespawn.RemoveListener(PlayerRespawn);
        }
    }
}
