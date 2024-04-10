using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GameStateType
{
    Title,
    P1,
    P2, 
    P3, 
    P4, 
    P5,
    Complete,
}

public class GameState : MonoBehaviour
{
    public GameStateType State { get; private set; }
    // Start is called before the first frame update
    void Start()
    {
        State = GameStateType.Title;  
    }

    public void P1Complete()
    {
        State = GameStateType.P1;
    }

    public void P2Complete()
    {
        State = GameStateType.P2;
    }
    public void P3Complete()
    {
        State = GameStateType.P3;
    }

    public void P4Complete()
    {
        State = GameStateType.P4;
    }

    public void P5Complete()
    {
        State = GameStateType.P5;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
