using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
    public static Game Instance { get; private set; }

    public int Pressure { get; private set; }


    private void Awake()
    {
        Instance = this;
    }
    // Start is called before the first frame update
    public void PressureChange(int amount)
    {
        Pressure += amount;
    }
}
