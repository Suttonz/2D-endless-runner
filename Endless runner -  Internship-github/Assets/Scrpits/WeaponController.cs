using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour
{
    private GameObject weaponDestroyPoint;
    [SerializeField] float movingSpeed;

    void Start()
    {
        weaponDestroyPoint = GameObject.FindGameObjectWithTag("WeaponDestroyPoint");
    }

    void Update()
    {
        DestoryWeapon();
        Moving();
    }


    void Moving()
    {
        float movingUnit = movingSpeed * Time.deltaTime;  
        transform.position = Vector3.MoveTowards(transform.position, weaponDestroyPoint.transform.position, movingUnit);
    }


    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "NinjaGirl")
        {
            Destroy(collision.gameObject);
            Destroy(this.gameObject);
        }
    }


    void DestoryWeapon()
    {
        if (this.transform.position.x > weaponDestroyPoint.transform.position.x)
        {
            Destroy(this.gameObject);
        }
    }
}
