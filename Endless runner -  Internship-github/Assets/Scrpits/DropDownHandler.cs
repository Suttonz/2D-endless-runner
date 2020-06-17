using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DropDownHandler : MonoBehaviour
{

    [SerializeField] Dropdown dropdown;
    

    private List<string> ops = new List<string>()
    {
        "1152*648",
        "1280*720",
        "1920*1080" 
    };

    void Start()
    {
        LoadOptions();
    }

    void LoadOptions()
    {
        dropdown.AddOptions(ops);
    }

}
