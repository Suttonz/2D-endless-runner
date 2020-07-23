using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnDirection : MonoBehaviour
{
    private MushroomController mushroomRef;

    private void Start()
    {
        mushroomRef = FindObjectOfType<MushroomController>();
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        
    }
}
