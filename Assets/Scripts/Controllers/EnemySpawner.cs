using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Controllers
{
    public class EnemySpawner : MonoBehaviour
    {
        [SerializeField] private GameObject spawningArea;
        [SerializeField] private GameObject enemy;
        [SerializeField] private float spawnInterval = 2f;

        private Transform[] spawnPoints;

        void Start()
        {
            spawnPoints = spawningArea.GetComponentsInChildren<Transform>();
            if (spawnPoints.Length != 3)
            {
                Debug.LogError("Spawning area must have at least two child points to define spawn range.");
            }

            StartCoroutine(SpawnEnemies());
        }

        private IEnumerator SpawnEnemies()
        {
            while (true)
            {
                var spawnPosition = new Vector3(Random.Range(spawnPoints[1].transform.position.x, spawnPoints[2].transform.position.x), spawningArea.transform.position.y, 0);
                Instantiate(enemy, spawnPosition, Quaternion.identity);

                yield return new WaitForSeconds(spawnInterval); // Adjust spawn interval as needed
            }
        }
    }
}
