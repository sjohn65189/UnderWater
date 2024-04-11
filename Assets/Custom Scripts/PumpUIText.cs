using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PumpUIText : MonoBehaviour {

    //get the text component of this ui object
    private TextMeshPro txt;
    void Start() { txt = GetComponent<TextMeshPro>(); }

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

    /**set the color to green upon complete state**/
    public void Complete() { txt.color = new Color(0, 1, 0, 1); }
}
