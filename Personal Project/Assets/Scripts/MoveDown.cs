using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveDown : MonoBehaviour
{
    public float speed = 20;
    // Start is called before the first frame update
    void Start()
    {
        transform.Translate(Vector3.back * Time.deltaTime * speed);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
