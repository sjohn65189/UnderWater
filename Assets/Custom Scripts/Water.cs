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
    
    public GameObject RisingWater;
    public WaterStateType State { get; private set; }
    // Start is called before the first frame update
    void Start()
    {
        State = WaterStateType.Stop;
    }

    public void Flood()
    {
        State = WaterStateType.Rise;
    }
    // Update is called once per frame
    void Update()
    {
        switch (State)
        {
            case WaterStateType.Stop:
                break;

            case WaterStateType.Rise:
                var myPos = RisingWater.transform.position;
                myPos.y += 0.00000463f;
                transform.position = myPos;
                break;
        }
    }
}
