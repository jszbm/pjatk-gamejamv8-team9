using UnityEngine;

public class PlayerSpawner : MonoBehaviour
{
    [SerializeField] private GameObject spawningArea;

    [SerializeField] private GameObject player;

    void Start()
    {
        SignalBus.Instance.OnPlayerNeedToRespawn.AddListener(() =>
        {
            var points = spawningArea.GetComponentsInChildren<Transform>();
            if (points.Length < 2)
            {
                Debug.LogError("Spawning area must have at least two child points to define spawn range.");
                return; 
            }

            var spawnPosition = new Vector3(Random.Range(points[0].transform.position.x, points[1].transform.position.x), spawningArea.transform.position.y, 0);

            player.transform.position = spawnPosition;
            player.SetActive(true);

            SignalBus.Instance.OnPlayerRespawned.Invoke();
        });

    }
}
