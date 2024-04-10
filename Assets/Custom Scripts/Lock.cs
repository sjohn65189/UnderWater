using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Lock : MonoBehaviour
{
    public GameObject Door2;
    public GameObject Door;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void Open()
    {
        Door.SetActive(false);
        Door2.SetActive(false);
    }
}
