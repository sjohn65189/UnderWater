using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Button : MonoBehaviour
{
    public GameObject button;
    private float startTime_buttonPress = 0f;
    private float holdDuration = 0f;

    private float startPause = 0f;
//    private float pauseDuration = 0f;
    public TMP_Text message;

    public TMP_Text errorMessage;
    private string morseCode = "";

    private bool isProcessingMorse = false;

    private float errorActive = 0f;

    public GameObject door;

    void Start()
    {
        errorMessage.gameObject.SetActive(false);
        
    }

    void Update()
    {
        if (isProcessingMorse)
        {
            if (Time.time - startPause >= 2f)
            {
                morseCodeConvert();
                isProcessingMorse = false;
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

        if ("HELPMEPLEASEHOMIES".Equals(morseCode))
        {
            door = GameObject.FindWithTag("Door");
            door.GetComponent<Door>().Open();

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

        isProcessingMorse = true;
    }

    public void morseCodeConvert()
    {
        if (Time.time - startPause >= 2f)
        {
            Debug.Log("Pause Duration: " + (Time.time - startPause));
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
}
