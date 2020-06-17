using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundStoryFade : MonoBehaviour
{

    [SerializeField] CanvasGroup backgroundStory;
    [SerializeField] Player playerRef;
    
    void Start()
    {

        StartCoroutine(FadeOutBackgroundStory());
        

    }

  

    private  IEnumerator FadeOutBackgroundStory()
    {

        for(float fadeOutAlpha = 1f; fadeOutAlpha >= -0.05f;  fadeOutAlpha -= 0.05f)
        {
            backgroundStory.alpha = fadeOutAlpha;
            yield return new WaitForSecondsRealtime(0.05f);

            if(fadeOutAlpha <= 0f)
            {
                StartCoroutine(StartGame());
            }
        }

        
    }

    private IEnumerator StartGame()
    {
        yield return new WaitForSecondsRealtime(2.5f);
        Time.timeScale = 1f;
        playerRef.PlayBackgroundMusic();
        playerRef.ToggleSoundEffectOK(true);
        Cursor.lockState = CursorLockMode.None;
    }



}
