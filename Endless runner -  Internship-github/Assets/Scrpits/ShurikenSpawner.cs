using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShurikenSpawner : MonoBehaviour
{
    [SerializeField] GameObject shuriken;
    private Vector3 spawnPos;
    private float timeNow;
    [SerializeField] float spawnTimeInterval;

     void Start()
    { 
        timeNow = Time.fixedTime + spawnTimeInterval;
    }


    void FixedUpdate()
    {
        if (Time.fixedTime >= timeNow)
        {
            SpawnShuriken();
            SpawnShuriken();
            timeNow = Time.fixedTime + spawnTimeInterval;
        }

    }

    void SpawnShuriken()
    {
        //Spawn Shuriken randomly on Y axis within the range of camera Y axis boundry
        spawnPos = new Vector3(transform.position.x, Random.Range(3f, 1.5f), transform.position.x);
        Instantiate(shuriken, spawnPos, transform.rotation);

    }

}
