using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ColumnLetter : MonoBehaviour {

    private TextMeshProUGUI txt;

    // Start is called before the first frame update
    void Start()
    {
        txt = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {

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
}
