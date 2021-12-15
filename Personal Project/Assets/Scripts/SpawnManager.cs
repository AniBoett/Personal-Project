using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject wallPrefab;
    public GameObject[] wallPrefabs;
    private Vector3 spawnPos = new Vector3(5, 3, 15);
    public GameObject powerupPrefab;
    private float startDelay = 2;
    private float spawnInterval = 2.5f;
    private PlayerController playerControllerScript;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnRandomWall", startDelay, spawnInterval);
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    void SpawnRandomWall()
    //randomly spawn walls
    {
        if (playerControllerScript.gameOver == false)
        {
            int wallIndex = Random.Range(0, wallPrefabs.Length);
            Instantiate(wallPrefabs[wallIndex], spawnPos, wallPrefabs[wallIndex].transform.rotation);
        }
    }
}
