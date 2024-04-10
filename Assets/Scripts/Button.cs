using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public enum WaitStateType {
    ACTIVATE,
    DEACTIVATE
}

public class Button : MonoBehaviour
{
    public WaitStateType State { get; private set; }
    public GameObject button;
    private float startTime_buttonPress = 0f;
    private float holdDuration = 0f;

    private float startPause = 0f;
//    private float pauseDuration = 0f;
    public TMP_Text message;

    public TMP_Text errorMessage;
    private string morseCode = "";

//    private bool isProcessingMorse = false;

    private float errorActive = 0f;


    void Start()
    {
        errorMessage.gameObject.SetActive(false);
        State = WaitStateType.DEACTIVATE;
    }

    void Update()
    {
        if (State == WaitStateType.ACTIVATE)
        {
            if (Time.time - startPause >= 2f)
            {
                morseCodeConvert();
                ChangeState(WaitStateType.DEACTIVATE);
            }
        }

        if (morseCode.Length > 4)
        {
            errorActive = Time.time;
            morseCode = "";
            errorMessage.gameObject.SetActive(true);
        }

        if (Time.time - errorActive >= 3f)
        {
            errorMessage.gameObject.SetActive(false);
        }
    }

    private Dictionary<char, string> morseAlaphabet = new Dictionary<char, string>()
    {
        {'A', ".-"},
        {'B', "-..."},
        {'C', "-.-."},
        {'D', "-.."},
        {'E', "."},
        {'F', "..-."},
        {'G', "--."},
        {'H', "...."},
        {'I', ".."},
        {'J', ".---"},
        {'K', "-.-"},
        {'L', ".-.."},
        {'M', "--"},
        {'N', "-."},
        {'O', "---"},
        {'P', ".--."},
        {'Q', "--.-"},
        {'R', ".-."},
        {'S', "..."},
        {'T', "-"},
        {'U', "..-"},
        {'V', "...-"},
        {'W', ".--"},
        {'X', "-..-"},
        {'Y', "-.--"},
        {'Z', "--.."}

    };

    public void MoveDown()
    {
        button.transform.localPosition = new Vector3(0, -0.7f, 0);
        startTime_buttonPress = Time.time;
        holdDuration = 0f;
        ChangeState(WaitStateType.DEACTIVATE);
    }

    public void MoveUp() 
    {
        button.transform.localPosition = new Vector3(0, -1.3f, 0);
        holdDuration = Time.time - startTime_buttonPress; 
        Debug.Log("Button held for: " + holdDuration + " seconds");

        string signal = (holdDuration < 0.5f) ? "." : "-";

        morseCode += signal;
        Debug.Log(morseCode);

        startPause = Time.time;

//        isProcessingMorse = true;
        ChangeState(WaitStateType.ACTIVATE);
    }

    public void morseCodeConvert()
    {
        if (Time.time - startPause >= 2f)
        {
            Debug.Log("Pause Duration: " + (Time.time - startPause));
            ChangeState(WaitStateType.ACTIVATE); 
            foreach (var code in morseAlaphabet)
            {
                if (String.Equals(morseCode, code.Value))
                {
                    message.text += code.Key;
                    morseCode = "";
                    startPause = Time.time;
                    break;
                }
            }
        }
    }

    public void ChangeState(WaitStateType newState) 
    {
        State = newState;
    }
}