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
        if ((Pressure + amount) < 0)
        {
            Pressure = 0;
        }
        Pressure += amount;

        if (Pressure == 55)
        {
            print("Puzzle complete");
        }
    }

    public void PressureReset()
    {
        Pressure = 0;
    }
}
