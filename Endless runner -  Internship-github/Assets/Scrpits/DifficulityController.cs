using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DifficulityController : MonoBehaviour
{
    [SerializeField] Player playerRef;
    private Vector3 playerStartPosition;
    private float runningDistance;
    [SerializeField] float speedIncreaseUnit;
    [SerializeField] float speedUpCheckDistanceUnit;
    private float previousRunningdistance;
    [SerializeField] float energyReduceUnit;
    [SerializeField] EnergyController energyControllerRef;
    //private float reduceSpeed = 0.2f;
    [SerializeField] float energyTimeInterval;
    private float timeNow;
    [SerializeField] Text distanceText;
    

    void Start()
    {

        playerStartPosition = playerRef.GetPositon();
        previousRunningdistance = 0f;
        timeNow = Time.fixedTime + energyTimeInterval;

    }


    void Update()
    {
        IncreastSpeed();
        CalculateDistance();
    }

    void FixedUpdate()
    {
        //reduce Energy per timeInterval time
        if (Time.fixedTime >= timeNow)
        {
            ReduceEnergy();
            timeNow = Time.fixedTime + energyTimeInterval;
        }
    }

    void IncreastSpeed()
    {
        runningDistance = playerRef.GetPositon().x - playerStartPosition.x;
        // increase player's runningspeed after every certain distance 
        if (runningDistance - previousRunningdistance >= speedUpCheckDistanceUnit)
        {
            previousRunningdistance = runningDistance;
            playerRef.runSpeed += speedIncreaseUnit;
            
        }
    
    }


    void ReduceEnergy()
    {
        energyControllerRef.ReduceEnergy(energyReduceUnit);
    }


    void CalculateDistance()
    {
        runningDistance = playerRef.GetPositon().x - playerStartPosition.x;
        distanceText.text = runningDistance.ToString("f0");
        playerRef.SetlongestDistance(runningDistance);

    }

    
}

