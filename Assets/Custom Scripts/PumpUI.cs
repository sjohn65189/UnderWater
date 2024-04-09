using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PumpUI : MonoBehaviour
{

    private int takeCol = 0;
    private int receCol = 1;
    private const int COLUMNS = 5;

    public ColumnLetter ct;
    public ColumnLetter cr;
    public PumpPuzzle pp;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update() {
        if (Game.Instance.input.Default.CycleTakeUp.WasPressedThisFrame()) {
            CycleTakeUp();
        }
        else if (Game.Instance.input.Default.CycleTakeDown.WasPressedThisFrame()) {
            CycleTakeDown();
        }
        else if (Game.Instance.input.Default.CycleReceiveUp.WasPressedThisFrame()) {
            CycleReceiveUp();
        }
        else if (Game.Instance.input.Default.CycleReceiveDown.WasPressedThisFrame()) {
            CycleReceiveDown();
        }
        else if (Game.Instance.input.Default.SendWater.WasPressedThisFrame() && takeCol != receCol) {
            pp.MoveWater(takeCol, receCol);
        }

    }

    public void CycleTakeUp() {
        if (takeCol != 0) { takeCol--; }
        ct.UpdateLetter(takeCol);
    }
    public void CycleTakeDown() {
        if (takeCol != COLUMNS-1) { takeCol++; }
        ct.UpdateLetter(takeCol);
    }
    public void CycleReceiveUp() {
        if (receCol != 0) { receCol--; }
        cr.UpdateLetter(receCol);
    }
    public void CycleReceiveDown() {
        if (receCol != COLUMNS-1) { receCol++; }
        cr.UpdateLetter(receCol);
    }
}
