using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Game : MonoBehaviour
{

    public KeyboardInput input;

    public static Game Instance { get; private set; }

    public int Pressure { get; private set; }

    public GameObject DrainDoor;

    public bool lockPressure { get; private set; }

    // needed global game variables or else i got errors in the grabbable code.
    public bool ped1 = false;
    public bool ped2 = false;
    public bool ped3 = false;


    private void Awake()
    {
        Instance = this;
        input = new();
        input.Enable();
        lockPressure = true;

        // if(Game.Instance.input.Default.GuageUp.WasPressedThisFrame()) /*do function*/ ;
    }
    // Start is called before the first frame update
    public void PressureChange(int amount)
    {
        if ((Pressure + amount) < 0)
        {
            Pressure = 0;
        }  else
        {
            Pressure += amount;
        }

        if (Pressure == 55)
        {
            var drainDoor = DrainDoor.GetComponent<Door>();
            drainDoor.Open();
        }
    }

    public void PressureReset()
    {
        Pressure = 0;
    }

    // enables the pressure puzzle when the broken/repair puzzle is completed
    public void UnlockPressure()
    {
        lockPressure = false;
        print("Pressure is unlocked!");
    }
}
