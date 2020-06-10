using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    [SerializeField] GameObject engery;
    [SerializeField] GameObject enemy;
    
    
    public void SpawnEngery(Vector3 spawnPos)
    {
        int spawnNum = Random.Range(2, 5);
        for (int i = 0; i < spawnNum; i++)
        {
            Instantiate(engery, new Vector3(spawnPos.x + 0.6f*i,spawnPos.y, spawnPos.z), transform.rotation);
        }
        
    }

    
    
}
