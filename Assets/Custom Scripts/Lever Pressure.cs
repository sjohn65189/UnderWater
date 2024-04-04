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
        if (other.CompareTag(Consts.Tags.pressureAdd) && hasReset && !Game.Instance.lockPressure)
        {
            Game.Instance.PressureChange(Consts.PressureValues.pressureAddLow);
            hasReset = false;
        }
        else if (other.CompareTag(Consts.Tags.pressureAddSecond) && hasReset && !Game.Instance.lockPressure)
        {
            Game.Instance.PressureChange(Consts.PressureValues.pressureAddHigh);
        }
        else if (other.CompareTag(Consts.Tags.pressureReducer) && hasReset && !Game.Instance.lockPressure)
        {
            Game.Instance.PressureChange(Consts.PressureValues.pressureReduce);
        }
        else if (other.CompareTag(Consts.Tags.pressureMult) && hasReset && !Game.Instance.lockPressure)
        {
            Game.Instance.PressureChange(Game.Instance.Pressure);
        }
        else if (other.CompareTag(Consts.Tags.pressureReset) && hasReset && !Game.Instance.lockPressure)
        {
            Game.Instance.PressureReset();
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
