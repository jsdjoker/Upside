using System.Collections;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    public GameObject[] obstacles;
    public float spawnRate;

    Vector3 spawnPos;

    void Start()
    {
        spawnPos = transform.position;
        StartCoroutine(SpawnObstacles());
    }

    IEnumerator SpawnObstacles()
    {
        while (true)
        {
            Spawn();
            GameManager.instance.UpdateScore();
            yield return new WaitForSeconds(spawnRate);
        }
    }

    void Spawn()
    {
        // Choose a random obstacle
        int randObstacle = Random.Range(0, obstacles.Length);

        // Choose top (0) or bottom (1)
        int randomSpot = Random.Range(0, 2);

        // Start from the spawner position
        spawnPos = transform.position;

        // Default rotation
        Quaternion rotation = transform.rotation;

        if (randomSpot == 1)
        {
            // Spawn at the bottom
            spawnPos.y = -transform.position.y;

            // Adjust X position depending on obstacle type
            if (randObstacle == 1)
            {
                spawnPos.x += 1;
            }
            else if (randObstacle == 2)
            {
                spawnPos.x += 2;
            }

            // Flip obstacle upside down
            rotation = Quaternion.Euler(0, 0, 180);
        }

        // Spawn ONLY ONE obstacle
        Instantiate(
            obstacles[randObstacle],
            spawnPos,
            rotation
        );
    }
}