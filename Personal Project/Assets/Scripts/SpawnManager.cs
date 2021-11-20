using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject wallPrefab;
    public GameObject[] wallPrefabs;
    private Vector3 spawnPos = new Vector3(5, 3, 15);
    public GameObject powerupPrefab;

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        //spawn walls when the 'C' key is pressed; placeholder, eventually walls will spawn automatically
        if (Input.GetKeyDown(KeyCode.C))
        {
            int wallIndex = Random.Range(0, wallPrefabs.Length);
            Instantiate(wallPrefabs[wallIndex], spawnPos, wallPrefabs[wallIndex].transform.rotation);
        }
    }
}
