using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestoryTiles : MonoBehaviour
{
    private GameObject tileDestroyPosition;

    void Start()
    {
        tileDestroyPosition = GameObject.FindGameObjectWithTag("Destroy");
    }

    
    void Update()
    {
        DestoryTile();
    }

    void DestoryTile()
    {
        if (this.transform.position.x < tileDestroyPosition.transform.position.x)
        {
            Destroy(gameObject);
           
        }
    }
}
