using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReduceLife : MonoBehaviour
{

    [SerializeField] Player_Platformer player_PlatformerRef;
    [SerializeField] float lifeReduceUnit;
    [SerializeField] float lifeReduceInterval;
    private float timeNow;

    void Start()
    {
        timeNow = Time.fixedTime + lifeReduceInterval;
    }


    void FixedUpdate()
    {
        //reduce Energy per timeInterval time
        if (Time.fixedTime >= timeNow)
        {
            player_PlatformerRef.ReduceLife(lifeReduceUnit);
            timeNow = Time.fixedTime + lifeReduceInterval;
        }
    }
}
