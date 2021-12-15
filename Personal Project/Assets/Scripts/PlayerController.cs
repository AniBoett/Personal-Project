using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour

{
    public float horizontalInput;
    public float forwardInput;
    public float speed = 10.0f;

    public float xRange = 25;
    public float zRange = 10;
    public bool gameOver = false;
    public bool hasPowerup;
    private Rigidbody playerRb;
    public GameObject powerupPrefab;
    public GameObject powerupIndicator;
    
    // Start is called before the first frame update
    void Start()
    {
        Instantiate(powerupPrefab, GenerateSpawnPosition(), powerupPrefab.transform.rotation);
    }

    // Update is called once per frame
    void Update()
    {
        powerupIndicator.transform.position = transform.position + new Vector3(0, -0.5f, 0);
        
        //player can move freely
        if (gameOver == false)
        {
            horizontalInput = Input.GetAxis("Horizontal");
            forwardInput = Input.GetAxis("Vertical");
            transform.Translate(Vector3.right * horizontalInput * Time.deltaTime * speed);
            transform.Translate(Vector3.forward * forwardInput * Time.deltaTime * speed);
        }


        //player stays inbounds
        if (transform.position.x > xRange)
        {
            transform.position = new Vector3(xRange, transform.position.y, transform.position.z);
        }
        if (transform.position.x < -xRange)
        {
            transform.position = new Vector3(-xRange, transform.position.y, transform.position.z);
        }

        if (transform.position.z > zRange)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, zRange);
        }

        if (transform.position.z < -zRange)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, -zRange);
        }
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        //if player collides with wall, game over!
        if (collision.gameObject.CompareTag("Wall") && hasPowerup == false)
        {
            gameOver = true;
            Debug.Log("Game Over!");
        }

        if (collision.gameObject.CompareTag("Wall") && hasPowerup)
        {
            Destroy(collision.gameObject);
            Debug.Log("Collided with" + collision.gameObject.name + "with powerup set to" + hasPowerup);
            hasPowerup = false;
            powerupIndicator.gameObject.SetActive(false);
        }
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Powerup"))
        {
            hasPowerup = true;
            Destroy(other.gameObject);
            powerupIndicator.gameObject.SetActive(true);
            StartCoroutine(PowerupCountdownRoutine());
        }
    }

    IEnumerator PowerupCountdownRoutine()
    {
        yield return new WaitForSeconds(7);
        powerupIndicator.gameObject.SetActive(false);
        hasPowerup = false;
        Instantiate(powerupPrefab, GenerateSpawnPosition(), powerupPrefab.transform.rotation);
    }

    private Vector3 GenerateSpawnPosition()
    {
        float spawnPosX = Random.Range(-xRange, xRange);
        float spawnPosZ = Random.Range(-zRange,zRange);
        Vector3 randomPos = new Vector3(spawnPosX, 0, spawnPosZ);
        return randomPos;
    }
}
