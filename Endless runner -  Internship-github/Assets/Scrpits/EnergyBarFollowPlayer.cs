using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnergyBarFollowPlayer : MonoBehaviour
{

    [SerializeField] Player playerRef;
    private Vector3 energyBarOffset;
    
    void Start()
    {
        energyBarOffset = new Vector3(0.2f, 2f, 0);
        this.transform.position = Camera.main.WorldToScreenPoint(playerRef.transform.position + energyBarOffset);
    }

    
    void LateUpdate()
    {
        FollowPlayer();
    }

    void FollowPlayer()
    {
        this.transform.position = Camera.main.WorldToScreenPoint(playerRef.transform.position + energyBarOffset);
    }
}
