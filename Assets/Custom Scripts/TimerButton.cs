using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerButton : MonoBehaviour
{
    public GameObject Currenttime;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    public void pressed()
    {
        var timer = Currenttime.GetComponent<Timer>();
        timer.TurnOn();
    }
}
