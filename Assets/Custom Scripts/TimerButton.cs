using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerButton : MonoBehaviour {

    //audio source for inspector
    public AudioSource buzz;
    public AudioSource generator;

    public GameObject Currenttime;

    private bool activated = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    public void pressed() {

        //button can only be pressed once for an effect
        if (activated) { return; }

        //play electric buzz and generator sound effects
        buzz.Play();
        generator.Play();

        var timer = Currenttime.GetComponent<Timer>();
        timer.TurnOn();

        activated = true;
    }
}
