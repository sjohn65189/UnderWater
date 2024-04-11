using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PumpPuzzleComplete : MonoBehaviour {

    /**set the color of the material to green**/
    public void Complete() {
        var material = GetComponent<Renderer>().material;
        material.color = Color.green;
    }
}
