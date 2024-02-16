using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] enemies;

    public float timeBetweenSpawns;

    private float spawnTimer;
    
    // Start is called before the first frame update
    void Start()
    {
        spawnTimer = timeBetweenSpawns;
    }

    // Update is called once per frame
    void Update()
    {
        //if the player is dead, just return from this function
        
        
        if (spawnTimer <= 0)
        {
            //pick the GO to spawn
            int index = Random.Range(0, enemies.Length);
            GameObject e = enemies[index];
            //set the position (hardcoded)
            float y = 6.0f;
            float x = Random.Range(-9.0f, 9.0f);
            Vector3 pos = new Vector3(x, y, 0.0f);
            //spawn it
            Instantiate(e, pos, Quaternion.identity);
            //reset the timer
            spawnTimer = timeBetweenSpawns;
        }
        else
        {
            spawnTimer -= Time.deltaTime;
        }
    }
}
