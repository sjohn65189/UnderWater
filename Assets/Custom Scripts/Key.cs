using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Key : MonoBehaviour
{

    private Rigidbody rb;
    public GameObject key;
    // Start is called before the first frame update
    void Start()
    {

    }
    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag(Consts.Tags.LOCK))
        {
            var keylock = other.GetComponent<Lock>();
            keylock.Open();
            key.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
