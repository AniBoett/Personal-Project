using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveDown : MonoBehaviour
{
    private float speed = -10.0f;

    private PlayerController playerControllerScript;
    
    // Start is called before the first frame update
    void Start()
    {
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        //walls and bullets move down until colliding with player
        if (playerControllerScript.gameOver == false)
        {
            transform.Translate(Vector3.forward * Time.deltaTime * speed);
        }
    }
}
