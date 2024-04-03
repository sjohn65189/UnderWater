using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using TMPro;
using UnityEngine.XR;
using System;

public enum TimerStateType
{
    On,
    Off,
}

public class Timer : MonoBehaviour
{
    public TimerStateType State { get; private set; }
    private TextMeshPro txt;
    TimeSpan CurrentTime;
    TimeSpan startingTime;

    // Start is called before the first frame update
    void Start()
    {
        CurrentTime = new(0, 30, 0);
        State = TimerStateType.On;
        txt = GetComponent<TextMeshPro>();
        
    }

    public void TurnOn()
    {
        State = TimerStateType.On;
    }

    public void TurnOff() {
        State = TimerStateType.Off;
    }

    // Update is called once per frame
    void Update()
    {
        switch (State)
        {
            case TimerStateType.Off:
                break;

            case TimerStateType.On:
                txt.text = CurrentTime.ToString(@"mm\:ss");
                CurrentTime = CurrentTime.Subtract(TimeSpan.FromSeconds(Time.deltaTime));
                break;
        }
    }
}
