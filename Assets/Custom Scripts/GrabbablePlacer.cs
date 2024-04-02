using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class GrabbablePlacer : MonoBehaviour
{

    private GameObject hitbox;

    // Start is called before the first frame update
    void Start()
    {
        hitbox = GameObject.FindWithTag("Receptacle");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Placeable"))
        {
            var placeable = GameObject.FindWithTag("Placeable");
            placeable.transform.position = hitbox.transform.position;
            placeable.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
            placeable.transform.eulerAngles = new Vector3(0,0,0);
            placeable.GetComponent<XRGrabInteractable>().enabled = false;
        }
    }
}
