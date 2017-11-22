using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileManagment : MonoBehaviour
{

    public GameObject[] chunkPrefabs;
    //public GameObject[] ObstaclePrefabs;
    private Transform PlayerLocation;

    private float spawnZ = 20.0f;
    //private float obstacleSpawnY = 5.0f / 20.0f;
    //private float obstacleSpawnX = 5.0f / 50.0f;

    private float chunkLenght = 30.0f;
    private float saveZone = 10.0f;
    private int amnChunksOnScreen = 6;
    private int lastPrefabIndex = 0;

    private List<GameObject> activeChunks;

    
    // Use this for initialization
    private void Start()
    {
        activeChunks = new List<GameObject>();
        PlayerLocation = GameObject.FindGameObjectWithTag("Player").transform;

        for (int i = 0; i < amnChunksOnScreen; i++)
        {
            if (i < 2)
            {
                SpawnChunk(0);
            }
            SpawnChunk();
        }
    }


    //Activate class when "Player" comes at the z that is necessary
    private void Update()
    {
        if (PlayerLocation.position.z - saveZone > (spawnZ - amnChunksOnScreen * chunkLenght))
        {
            SpawnChunk();
            DeleteChunk();
            SpawnObstacle();
        }
    }

    private void SpawnChunk(int prefabIndex = -1)
    {
        GameObject go;
        if (prefabIndex == -1)
        {
            go = Instantiate(chunkPrefabs[RandomPrefabIndex()]) as GameObject;
        }
        else
        {
            go = Instantiate(chunkPrefabs[prefabIndex]) as GameObject;
        }
        go.transform.SetParent(transform);
        go.transform.position = Vector3.forward * spawnZ;
        spawnZ += chunkLenght;
        activeChunks.Add(go);
    }

    private void DeleteChunk()
    {
        Destroy(activeChunks[0]);
        activeChunks.RemoveAt(0);
    }

    //Decide which Tile can not spawn after the previous Tile
    private int RandomPrefabIndex()
    {
        if (chunkPrefabs.Length <= 1)
        {
            return 0;
        }

        int randomIndex = lastPrefabIndex;
        while (randomIndex == lastPrefabIndex)
        {
            randomIndex = Random.Range(0, chunkPrefabs.Length);
        }

        lastPrefabIndex = randomIndex;
        return randomIndex;
    }

    private void SpawnObstacle()
    {
        /*
        Debug.Log("Spawn Obstacle");
        GameObject Obstacle;
        Vector3 ObstacleLocation = new Vector3(obstacleSpawnX, 4f, spawnZ);

        Obstacle = Instantiate(ObstaclePrefabs[+1]) as GameObject;
        Obstacle.transform.SetParent(transform);
        Obstacle.transform.position = ObstacleLocation * obstacleSpawnY;

        //spawnZ += chunkLenght;
        */
    }

}
