using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WarningFade : MonoBehaviour
{
    //private Color warningColor;
    [SerializeField] TextMeshProUGUI warningText;


    void Start()
    {
        //warningColor = GetComponent<Renderer>().material.color;
        StartCoroutine(FadeOutText());
    }

    private IEnumerator FadeOutText()
    {
            yield return new WaitForSecondsRealtime(3f);
            warningText.enabled = false;
            this.gameObject.SetActive(false);
            
    }


}


