using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DeleteButton : MonoBehaviour
{
    public GameObject button;

    public TMP_Text message;
    public void MoveDown()
    {
        button.transform.localPosition = new Vector3(0, -0.7f, 0);
    }

    public void MoveUp() 
    {
        button.transform.localPosition = new Vector3(0, -1.3f, 0);
    }

    public void DeleteLastCharacter()
    {
        if (message.text.Length > 0)
        {
            message.text = message.text.Substring(0, message.text.Length - 1);
        }
    }
}
