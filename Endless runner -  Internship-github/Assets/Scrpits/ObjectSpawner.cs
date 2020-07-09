using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    [SerializeField] GameObject energy = default;
    
    
    
    public void SpawnEnergy(Vector3 spawnPos)
    {
        int spawnNum = Random.Range(2, 5);
        for (int i = 0; i < spawnNum; i++)
        {
            Instantiate(energy, new Vector3(spawnPos.x + 0.6f*i,spawnPos.y, spawnPos.z), transform.rotation);
        }
        
    }

    
    
}
