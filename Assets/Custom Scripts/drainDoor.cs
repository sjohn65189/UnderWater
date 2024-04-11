using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class drainDoor : MonoBehaviour
{

    public GameObject DrainDoor;
    // Update is called once per frame
    public void openDoor()
    {
        DrainDoor.SetActive(false);
    }
}
