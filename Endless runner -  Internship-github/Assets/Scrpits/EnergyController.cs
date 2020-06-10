using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class EnergyController : MonoBehaviour
{

    public float energy;
    [SerializeField] Player playerRef;
    [SerializeField] Slider energyBar;

    void Start()
    {
        energy = 100f;
        
    }

    
    void Update()
    {
        TriggerDeath();
    }

    void TriggerDeath()
    {

        if (energy <= 0f)
        {
            playerRef.Death();
        }

    }

    public void IncreaseEnergy(float energyNum)
    {
        
        energy += energyNum;
        //add value back on the energyBar(UI element)
        energyBar.value += energyNum;

        if(energy >= 100f)
        {
            energy = 100f;
        }
    }

    public void ReduceEnergy(float energyNum)
    {
        energy -= energyNum;
        //decrease player's engergy along with energybar (UI elements)
        energyBar.value -= energyNum;
        if (energy <= 0f)
        {
            energy = 0f;
        }
    }

   
}
