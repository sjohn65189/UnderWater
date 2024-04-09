using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PumpUI : MonoBehaviour
{

    //current chosen take & receive columns (A-E)
    private int takeCol = 0;
    private int receCol = 1;

    //number of available columns to choose from
    private const int COLUMNS = 5;

    //column take letter in the dev UI
    public ColumnLetter ct;

    //column receive letter in the dev UI
    public ColumnLetter cr;

    //pump puzzle
    public PumpPuzzle pp;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update() {

        //do nothing if puzzle is complete
        if (pp.IsComplete()) { return; }

        //WSED and Enter input
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

    /**cycles the chosen "take" column up one (E>D>C>B>A)**/
    public void CycleTakeUp() {
        if (takeCol != 0) { takeCol--; }
        ct.UpdateLetter(takeCol);
    }

    /**cycles the chosen "take" column down one (A>B>C>D>E)**/
    public void CycleTakeDown() {
        if (takeCol != COLUMNS-1) { takeCol++; }
        ct.UpdateLetter(takeCol);
    }

    /**cycles the chosen "receive" column up one (E>D>C>B>A)**/
    public void CycleReceiveUp() {
        if (receCol != 0) { receCol--; }
        cr.UpdateLetter(receCol);
    }

    /**cycles the chosen "receive" column down one (A>B>C>D>E)**/
    public void CycleReceiveDown() {
        if (receCol != COLUMNS-1) { receCol++; }
        cr.UpdateLetter(receCol);
    }
}
