using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireSpawner : MonoBehaviour
{
    [SerializeField] GameObject fire;
    private float timeNow;
    [SerializeField] float spawnTimeInterval;
    private Vector3 fireSpawnPos;
    void Start()
    {
        timeNow = Time.fixedTime + spawnTimeInterval;
    }


    void FixedUpdate()
    {
        if (Time.fixedTime >= timeNow)
        {
            SpawnFire();
            timeNow = Time.fixedTime + spawnTimeInterval;
        }

    }

    void SpawnFire()
    {
        fireSpawnPos = new Vector3(Random.Range(-14f, 2f), transform.position.y, transform.position.x);
        Instantiate(fire, fireSpawnPos, transform.rotation);
    }
}
