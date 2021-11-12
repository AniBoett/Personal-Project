using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject wallPrefab;
    private Vector3 spawnPos = new Vector3(5, 1, 15);

    // Start is called before the first frame update
    void Start()
    {
        Instantiate(wallPrefab, spawnPos, wallPrefab.transform.rotation);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
