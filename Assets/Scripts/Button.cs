using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{
    public GameObject button;
//    GameObject presser;
//    bool isPressed;
//    private Light postLight;
    // Start is called before the first frame update
    void Start()
    {
//        postLight = GetComponent<Light>();
//        isPressed = false;
    }

    public void MoveDown()
    {
        button.transform.localPosition = new Vector3(0, -0.7f, 0);
    }

    public void MoveUp() 
    {
        button.transform.localPosition = new Vector3(0, -1.3f, 0);

    }
/*
    private void OnTriggerEnter(Collider other)
    {
        if (!isPressed)
        {
            button.transform.localPosition = new Vector3(0, -0.7f, 0);
            presser = other.gameObject;
            postLight.enabled = true;
            isPressed = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other == presser)
        {
            button.transform.localPosition = new Vector3(0, -1.3f, 0);
            presser = other.gameObject;
            postLight.enabled = false;
            isPressed = false;
        }
    }
*/
}
