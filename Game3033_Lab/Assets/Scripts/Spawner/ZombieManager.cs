using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieManager : MonoBehaviour
{
    public int numZombiesToSpawn;
    public GameObject[] zombiePrefabs;
    public SpawnerVolume[] spawnerVolumes;

    GameObject followGameObject;
    // Start is called before the first frame update
    void Start()
    {
        followGameObject = GameObject.FindGameObjectWithTag("Player");

        for (int i = 0; i < numZombiesToSpawn; i++)
        {
            SpawnZombie();
        }
    }

    void SpawnZombie()
    {
        GameObject zombieToSpawn = zombiePrefabs[Random.Range(0, zombiePrefabs.Length)];
        SpawnerVolume spawnVolume = spawnerVolumes[Random.Range(0, spawnerVolumes.Length)];

        if (!followGameObject) return;

        GameObject zombie = Instantiate(zombieToSpawn, spawnVolume.GetPositionInBounds(), spawnVolume.transform.rotation);

        zombie.GetComponent<ZombieComponent>().Initialize(followGameObject);
    }
}
