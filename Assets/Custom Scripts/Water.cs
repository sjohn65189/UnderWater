using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum WaterStateType
{
    Rise,
    Stop,
}

public class Water : MonoBehaviour
{
    public WaterStateType State { get; private set; }
    // Start is called before the first frame update
    void Start()
    {
        State = WaterStateType.Stop;
    }

    // Update is called once per frame
    void Update()
    {
        switch (State)
        {
            case WaterStateType.Stop:
                break;
        }
    }
}
