using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    [SerializeField] private GameObject spikePrefab;
    [SerializeField] private GameObject swingObstaclePrefab;
    [SerializeField] private GameObject zombiePrefab;

    [SerializeField] private GameObject[] rotatingObstaclePrefabs;

    [SerializeField] private float spikeYPos=0;
    [SerializeField] private float zombieYPos = 0;

    [SerializeField] private float rotatingObstacleMinY=0;
    [SerializeField] private float rotatingObstacleMaxY=0;

    [SerializeField] private float swingObstacleMinY=0;
    [SerializeField] private float swingObstacleMaxY=0;

    [SerializeField] private float minSpawnTime=2;
    [SerializeField] private float maxSpawnTime=3.5f;

    [SerializeField] private GameObject healthPrefab;
    [SerializeField] private float healthMinY=0;
    [SerializeField] private float healthMaxY=0;
    [SerializeField] private float healthSpawnChance=0;


    private float spawnWaitTime = 0;

    private int obstacleTypeCount = 4;
    private int obstacleToSpawn = 0;

    private Camera mainCamera;

    private Vector3 obstacleSpawnPosition = Vector3.zero;
    private Vector3 healthSpawnPosition=Vector3.zero;
    private GameObject newObstacle=null;

    private void Start()
    {
        mainCamera=Camera.main;
    }

    private void Update()
    {
        HandleObstacleSpawning();
    }

    private void HandleObstacleSpawning()
    {
        if (Time.time > spawnWaitTime)
        {
            spawnWaitTime = Time.time + Random.Range(minSpawnTime, maxSpawnTime);
            SpawnObstacle();
            SpawnHealth();
        }
    }

    private void SpawnObstacle()
    {
        obstacleToSpawn = Random.Range(0, obstacleTypeCount);

        switch (obstacleToSpawn)
        {
            case 0:
                GameObject spike = PoolManager.Instance.ReuseGameObject(spikePrefab,
                    new Vector3(mainCamera.transform.position.x+19, spikeYPos, 0), Quaternion.identity);
                spike.SetActive(true);
                break;
            case 1:
                GameObject swing =
                    PoolManager.Instance.ReuseGameObject(swingObstaclePrefab,
                    new Vector3(mainCamera.transform.position.x+19, Random.Range(swingObstacleMinY,swingObstacleMaxY),
                        0), swingObstaclePrefab.transform.rotation);
                swing.SetActive(true);
                break;
            case 2:
                GameObject zombie = PoolManager.Instance.ReuseGameObject(zombiePrefab,
                    new Vector3(mainCamera.transform.position.x+19, zombieYPos, 0), Quaternion.identity);
                zombie.SetActive(true);

                break;
            case 3:
                GameObject rotationObstacle = PoolManager.Instance.ReuseGameObject(
                    rotatingObstaclePrefabs[Random.Range(0,rotatingObstaclePrefabs.Length)],
                    new Vector3(mainCamera.transform.position.x+19, Random.Range(rotatingObstacleMinY,rotatingObstacleMaxY), 0),
                    Quaternion.identity);
                rotationObstacle.SetActive(true);
                break;
        }
    }


    private void SpawnHealth()
    {
        if (Random.Range(0, 10) > healthSpawnChance)
        {
            GameObject health = PoolManager.Instance.ReuseGameObject(healthPrefab,
                new Vector3(mainCamera.transform.position.x + 15, Random.Range(healthMinY, healthMaxY), 0f),
                Quaternion.identity);
            health.SetActive(true);
        }
    }
}
