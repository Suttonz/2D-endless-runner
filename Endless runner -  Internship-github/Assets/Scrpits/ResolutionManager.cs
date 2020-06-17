using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResolutionManager : MonoBehaviour
{
    [SerializeField] Dropdown resolutionDropdown;

    void Start()
    {
        //Remember player last resolution option
        resolutionDropdown.value = PlayerPrefs.GetInt("ResolutionOp");
        
    }

    void Update()
    {
        SetResolution();
        //Debug.Log("Selected Resolution" + resolutionDropdown.value.ToString());
    }

    public void SetResolution()
    {
       
        switch (resolutionDropdown.value)
        {
            case 0:
                Screen.SetResolution(1152, 648, true);
                break;
            case 1:
                Screen.SetResolution(1280, 720, true);
                break;
            case 2:
                Screen.SetResolution(1920, 1080, true);
                break;
        }

        PlayerPrefs.SetInt("ResolutionOp", resolutionDropdown.value);

    }
}
