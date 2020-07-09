using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{

    [SerializeField] Player playerRef;
    private Vector3 playerPreviousPosition;
    float distance;
    private Camera camera;
    private float cameraYtimesIndex = 1f;
    float cameraYmax;
    float playerPositionY;
    float cameraStaringSize;
    float cameraFinishingSize = 6.7f;
    float cameraChangingTime;
    float startTime;
    float originalCamYaxis;

    void Start()
    {

        playerPreviousPosition = playerRef.transform.position;
        camera = GetComponent<Camera>();
        cameraStaringSize = camera.orthographicSize;
       
    }


    void Update()
    {
        CameraFollowPlayer();
        CameraViewBoundry();
        CameraSizeChangeWithPlayer();
          
    }


    public float CameraViewBoundry()
    {
       // camera Y axis boundry
       return cameraYmax = transform.position.y + cameraYtimesIndex * camera.orthographicSize;

    }

    void CameraFollowPlayer()
    {
        this.transform.position = new Vector3(transform.position.x + (playerRef.transform.position.x - playerPreviousPosition.x), this.transform.position.y, this.transform.position.z);
        playerPreviousPosition = playerRef.transform.position;
        /*
        if (playerRef.GetPositon().y > (cameraYmax - 3f))
        {
            RecordCameraYaix(transform.position.y);
            this.transform.position = new Vector3(transform.position.x, transform.position.y + 2f, transform.position.z);
        }
        if(playerRef.GetPositon().y < (cameraYmax - 3f))
        {
            this.transform.position = new Vector3(transform.position.x, originalCamYaxis, transform.position.z);
        }*/

    }


   /* void RecordCameraYaix(float yAxis)
    {
        originalCamYaxis = yAxis;
    }
    */

    void CameraSizeChangeWithPlayer()
    {
       //resize camera when player get close to camera edge on Y axis (top part)
        if (playerRef.GetPositon().y > (cameraYmax - 3f))
        {
           cameraChangingTime += Time.deltaTime;
           camera.orthographicSize = Mathf.SmoothStep(cameraStaringSize, cameraFinishingSize, cameraChangingTime);
        }

    }

     
     
}
