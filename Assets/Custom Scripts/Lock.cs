using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lock : MonoBehaviour
{
    public GameObject keyLock;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void Open()
    {
        keyLock.SetActive(false);
    }
}
