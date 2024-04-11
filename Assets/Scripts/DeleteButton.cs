using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DeleteButton : MonoBehaviour
{
    public GameObject button; // game object for the Delete button

    public TMP_Text message; // contains the Morse Code message; displays the Morse Code message

    // function for the animation of pressing the button down
    public void MoveDown()
    {
        button.transform.localPosition = new Vector3(0, -0.7f, 0);
    }

    // function for the animation of releasing the button up
    public void MoveUp() 
    {
        button.transform.localPosition = new Vector3(0, -1.3f, 0);
    }

    // function for deleting the last character
    // updates the message display
    public void DeleteLastCharacter()
    {
        if (message.text.Length > 0)
        {
            message.text = message.text.Substring(0, message.text.Length - 1);
        }
    }
}
