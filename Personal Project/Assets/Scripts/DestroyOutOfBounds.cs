using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOutOfBounds : MonoBehaviour
{
    private float lowerBound = -25;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //destroy wall and bullets if they go out of bounds
        if (transform.position.z < lowerBound)
        {
            Destroy(gameObject);
        }
    }
}
