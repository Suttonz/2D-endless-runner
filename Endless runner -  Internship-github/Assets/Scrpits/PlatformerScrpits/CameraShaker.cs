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
    private Vector3 ogPivotOffset;
    [SerializeField] GameObject bloodSplatter;

    public Coroutine StopRoutine { get; private set; }

    void Start()
    {
        cameraNoiseProfile = camera.GetCinemachineComponent<Cinemachine.CinemachineBasicMultiChannelPerlin>();
        playerRef = FindObjectOfType<Player_Platformer>();
        //ogPivotOffset = cameraNoiseProfile.m_PivotOffset;


    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "PlayerPlatformer")
        {
            ShakeCamera();
            StopRoutine = null;
        }
    
    }


    void ShakeCamera()
    {
        
            playerRef.SwitchOffRigidbody();
            cameraNoiseProfile.m_AmplitudeGain = amplitude;
            cameraNoiseProfile.m_FrequencyGain = frequency;
            bloodSplatter.SetActive(true);
            if (StopRoutine == null)
            {
                StopRoutine = StartCoroutine(StopShaking(2f)); 
            }

    }

    private IEnumerator StopShaking(float time)
    {
        yield return new WaitForSeconds(time);
        isShaking = false;
        playerRef.SwitchOnRigidbody();
        cameraNoiseProfile.m_AmplitudeGain = 0f;
        cameraNoiseProfile.m_FrequencyGain = 0f;
        //cameraNoiseProfile.m_PivotOffset = ogPivotOffset;
        bloodSplatter.SetActive(false);
        //Enable deathMenu after shake the camera
        playerRef.Death();
    }
}
