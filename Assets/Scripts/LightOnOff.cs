using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightOnOff : MonoBehaviour
{
    public Light myLight;

    void Start()
    {
        myLight.gameObject.SetActive(false);
    }

    public void ToggleLight()
    {
        myLight.enabled = !myLight.enabled;
    }
}
