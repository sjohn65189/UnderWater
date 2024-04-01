using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class LeverPressure : MonoBehaviour
{
    private Rigidbody leverBase;
    private bool hasReset;
    // Start is called before the first frame update
    void Start()
    {
        leverBase = GetComponent<Rigidbody>();
        hasReset = true;
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(Consts.Tags.pressureAdd) && hasReset)
        {
            Game.Instance.PressureChange(Consts.PressureValues.pressureAddLow);
            hasReset = false;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag(Consts.Tags.pressureAdd))
        {
            hasReset = true;
        }
    }
}
