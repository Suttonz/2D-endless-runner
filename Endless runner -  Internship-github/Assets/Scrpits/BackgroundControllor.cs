using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundControllor : MonoBehaviour
{
    private float startPosition;
    private float lengthOfBackground;
    [SerializeField] GameObject camera;
    [SerializeField] float parallox;
    private float distanceMoved;
    private float boundry;
    void Start()
    {
        startPosition = this.transform.position.x;
        lengthOfBackground = GetComponent<SpriteRenderer>().bounds.size.x; 
    }

   
    void LateUpdate()
    {
        MoveBackground();
    }

    void MoveBackground()
    {
        distanceMoved = camera.transform.position.x * parallox;
        boundry = camera.transform.position.x * (1 - parallox);
        this.transform.position = new Vector3(startPosition + distanceMoved, transform.position.y, transform.position.z);

        if(boundry > startPosition + lengthOfBackground)
        {
            startPosition += lengthOfBackground;
        }
        else if(boundry<startPosition - lengthOfBackground)
        {
            startPosition -= lengthOfBackground;
        }
    }
}
