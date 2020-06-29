using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraShaker : MonoBehaviour
{


    [SerializeField] CinemachineVirtualCamera camera;
    private CinemachineBasicMultiChannelPerlin cameraNoiseProfile;
    private bool isShaking;
    [SerializeField] float amplitude;
    [SerializeField] float frequency;
    [SerializeField] Player_Platformer playerRef;
    


    void Start()
    {
        cameraNoiseProfile = camera.GetCinemachineComponent<Cinemachine.CinemachineBasicMultiChannelPerlin>();
        playerRef = FindObjectOfType<Player_Platformer>();
        
       
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "PlayerPlatformer")
        {
            isShaking = true;
        }
    }


    void Update()
    {
        ShakeCamera();
    }


    void ShakeCamera()
    {
        if (isShaking)
        {
            playerRef.SwitchOffRigidbody();
            cameraNoiseProfile.m_AmplitudeGain = amplitude;
            cameraNoiseProfile.m_FrequencyGain = frequency;
            StartCoroutine(StopShaking(2f));
        }

    }

    private IEnumerator StopShaking(float time)
    {
        yield return new WaitForSeconds(time);
        isShaking = false;
        playerRef.SwitchOnRigidbody();
        cameraNoiseProfile.m_AmplitudeGain = 0f;
        cameraNoiseProfile.m_FrequencyGain = 0f;
    }
}
