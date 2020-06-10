using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiamondController : MonoBehaviour
{

    private Player playerRef;
    private Renderer diamondRender;
    [SerializeField] float waitTime;
    

    void Start()
    {
        playerRef = FindObjectOfType<Player>();
        diamondRender = GetComponent<Renderer>();
        diamondRender.enabled = true;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "IsPlayer")
        {
            playerRef.PlayDiamondSoud();
            playerRef.ToogleCanhurt(false);
            playerRef.TooglePlayerTransparency(0.5f);
            diamondRender.enabled = false;
            StartCoroutine(DeffectivePlayerProtection(waitTime));
        }
    }

    IEnumerator DeffectivePlayerProtection(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        playerRef.ToogleCanhurt(true);
        playerRef.TooglePlayerTransparency(1f);
        Destroy(gameObject); 
    }
}
