using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightOnOff : MonoBehaviour
{
    public Light myLight; // reference to the light game object

    void Start()
    {
        myLight.gameObject.SetActive(false); // initially disables it
    }

    public void ToggleLightEnable()
    {
        myLight.gameObject.SetActive(true); // enables it
    }

    public void ToggleLightDisable()
    {
        myLight.gameObject.SetActive(false); // disables it
    }
}