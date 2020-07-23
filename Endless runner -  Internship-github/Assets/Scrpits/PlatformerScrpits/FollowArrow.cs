using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowArrow : MonoBehaviour
{
    [SerializeField] GameObject arrowRef;
    [SerializeField] float yOffset;
    private Vector3 textOffset;

    void Start()
    {
        textOffset = new Vector3(0, yOffset, 0);
        this.transform.position = Camera.main.WorldToScreenPoint(arrowRef.transform.position + textOffset);
    }


    void LateUpdate()
    {
        this.transform.position = Camera.main.WorldToScreenPoint(arrowRef.transform.position + textOffset);
    }
}

    
    

