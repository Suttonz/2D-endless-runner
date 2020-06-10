using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShurikenController : MonoBehaviour
{

    private Player playerRef;
    private float rotateSpeed = 8f;
    [SerializeField] float movingSpeedMin;
    [SerializeField] float movingSpeedMax;
    private float angle = 10f;
    private GameObject tileDestroyPosition;


    private void Start()
    {
        playerRef = FindObjectOfType<Player>();
        tileDestroyPosition = GameObject.FindGameObjectWithTag("Destroy");
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "IsPlayer")
        {
            playerRef.DecreaseEnergy();
        }
    }


    void Update()
    {
        Rotation();
        Moving();
        DestoryShuriken();
    }

    void Rotation()
    {
        //Rotate the shuriken
        Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, rotateSpeed * Time.deltaTime);
        angle += 10f; 
    }

    void Moving()
    {
        //Moving Shuriken from its position to tile destory position witha certain speed
        float movingSpeed = Random.Range(movingSpeedMin, movingSpeedMax);
        float movingUnit = movingSpeed * Time.deltaTime; // calculate distance to move
        transform.position = Vector3.MoveTowards(transform.position, tileDestroyPosition.transform.position, movingUnit);
    }

    void DestoryShuriken()
    {
        if (this.transform.position.x < tileDestroyPosition.transform.position.x)
        {
            Destroy(gameObject);
        }
    }
}
