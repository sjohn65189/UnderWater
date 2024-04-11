using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

// State Machine for the Wait time
// this is for when the button is being pressed and not being pressed
public enum WaitStateType {
    ACTIVATE, // pressing
    DEACTIVATE // not pressing
}

public class Button : MonoBehaviour
{
    public WaitStateType State { get; private set; }
    public GameObject button; // game object for the Morse Code button
    private float startTime_buttonPress = 0f; // start time for when the button is pressed
    private float holdDuration = 0f; // elapsed time of the button being pressed

    private float startPause = 0f; // start time for when the button is not pressed
    public TMP_Text message; // contains the Morse Code message; displays the Morse Code message

    public TMP_Text errorMessage; // contains the error message for when too many characters are being inputted
    private string morseCode = ""; // contains the string message for the Morse Code singular character input

    private float startTime_errorActive = 0f; // start time for when the error message is activated


    void Start()
    {
        errorMessage.gameObject.SetActive(false); // disables the error messages from displaying
        State = WaitStateType.DEACTIVATE; // sets the Wait State to DEACTIVATE
    }

    void Update()
    {
        if (State == WaitStateType.ACTIVATE) // when the WAIT State is ACTIVATE
        {
            if (Time.time - startPause >= 2f) // if the elapsed wait time exceeds over 2 seconds
            {
                morseCodeConvert(); // converts the player's input into the associated character based on the Morse Code chart
                ChangeState(WaitStateType.DEACTIVATE); // sets the Wait State to DEACTIVATE
            }
        }

        if (morseCode.Length > 4) // if the player inputs more than 4 button presses
        {
            startTime_errorActive = Time.time; // error start time activates
            morseCode = ""; // reset the Morse Code character string 
            errorMessage.gameObject.SetActive(true); // activates the error message
        }

        if (Time.time - startTime_errorActive >= 3f) // if the elapsed time for the error message exceeds over 3 seconds
        {
            errorMessage.gameObject.SetActive(false); // deactivates the error message
        }
/*
        if (message.text == "HELPMEPLEASE") {

        }
*/
    }

    // dictionary containing the Morse Code chart
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

    // function for the animation of pressing the button down
    public void MoveDown()
    {
        button.transform.localPosition = new Vector3(0, -0.7f, 0); // moves the button to this position
        startTime_buttonPress = Time.time; // button press start time activates
        holdDuration = 0f; // sets the elapsed time of the button being pressed is 0
        ChangeState(WaitStateType.DEACTIVATE); // sets the Wait State to DEACTIVATE
    }

    // function for the animation of releasing the button
    public void MoveUp() 
    {
        button.transform.localPosition = new Vector3(0, -1.3f, 0); // moves the button to this position
        holdDuration = Time.time - startTime_buttonPress; // elapsed time of the button being pressed 
        Debug.Log("Button held for: " + holdDuration + " seconds"); // prints the elapsed time to console

        // if the button is held less than 0.5 seconds then it's a dot
        // if the button is held more than 0.5 seconds then it's a dash
        string signal = (holdDuration < 0.5f) ? "." : "-"; 

        morseCode += signal; // adds the input to the string
        Debug.Log(morseCode); // prints the string to the console

        startPause = Time.time; // wait pause start time activates

        ChangeState(WaitStateType.ACTIVATE); // sets the Wait State to ACTIVATE
    }

    // function for converting the dot and dashes into their respective
    // characters according to the Morse Code chart
    public void morseCodeConvert()
    {
        if (Time.time - startPause >= 2f) // if the elapsed wait time exceeds over 2 seconds
        {
            Debug.Log("Pause Duration: " + (Time.time - startPause)); // prints the elapsed wait time
            ChangeState(WaitStateType.ACTIVATE); // sets the Wait State to ACTIVATE
            foreach (var code in morseAlaphabet) // iterates through the Morse Code chart (dictionary)
            {
                if (String.Equals(morseCode, code.Value)) // checks to see if the Morse Code string matches with the dots and dashes of a character
                {
                    message.text += code.Key; // adds the associated character to the Morse Code display
                    morseCode = ""; // reset the Morse Code character string 
                    startPause = Time.time; // wait pause start time activates
                    break; // stops iterating through the Morse Code chart when found
                }
            }
        }
    }

    // changes the Wait State
    // the new state become the current state
    public void ChangeState(WaitStateType newState) 
    {
        State = newState;
    }
}