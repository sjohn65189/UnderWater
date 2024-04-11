using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PumpUIText : MonoBehaviour {

    //colors used while inactive(gray) and completed(green)
    private Color inactiveColor = new Color(0.1f, 0.1f, 0.1f, 1);
    private Color completeColor = Color.green;

    //color used while the player is solving the puzzle
    public Color activeColor;

    //get the text component of this ui object
    private TextMeshPro txt;

    /**start by grabbing the text, its material, and setting its color to gray**/
    void Start() {
        txt = GetComponent<TextMeshPro>();
        txt.color = inactiveColor;
    }

    /**set ui letter to A-E using integer 0-4**/
    public void UpdateLetter(int i) {

        switch (i) {
            case 0:
                txt.text = "A";
                break;
            case 1:
                txt.text = "B";
                break;
            case 2:
                txt.text = "C";
                break;
            case 3:
                txt.text = "D";
                break;
            case 4:
                txt.text = "E";
                break;
            default:
                txt.text = "Error";
                break;
        }
    }

    /**set the color of the material to be what it should be while activated (set in inspector)**/
    public void ActivatePower() { txt.color = activeColor; }

    /**set the color to green upon complete state**/
    public void Complete() { txt.color = completeColor; }
}
