using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PumpUI : MonoBehaviour {

    //current chosen take & receive columns (A-E)
    private int takeCol = 0;
    private int receCol = 1;

    //number of available columns to choose from
    private const int COLUMNS = 5;

    //main object
    public PumpPuzzle pp;

    //all ui elements in the pump puzzle
    public PumpUIText ct;
    public PumpUIText cr;
    public PumpUIText title;
    public PumpUIText arrow;
    public PumpUIText takeUp;
    public PumpUIText takeDown;
    public PumpUIText receUp;
    public PumpUIText receDown;
    public PumpUIText go;

    //power is activated after power button is pressed
    private bool powerActivated = false;

    //complete state
    private bool complete = false;

    //click noise for pressing arrow buttons
    public AudioSource click;

    /**calling activate power allows the buttons to be pressed and lights up the ui with color**/
    public void ActivatePower() {
        powerActivated = true;
        title.ActivatePower();
        ct.ActivatePower();
        cr.ActivatePower();
        arrow.ActivatePower();
        takeUp.ActivatePower();
        takeDown.ActivatePower();
        receUp.ActivatePower();
        receDown.ActivatePower();
        go.ActivatePower();
    }

    /**calling complete will set the state to complete as well as change
     * all UI elements to the color green**/
    public void Complete() {
        complete = true;
        title.Complete();
        ct.Complete();
        cr.Complete();
        arrow.Complete();
        takeUp.Complete();
        takeDown.Complete();
        receUp.Complete();
        receDown.Complete();
        go.Complete();
    }

    /**calling go will send water from the "take" column to the "receive" column**/
    public void Go() {
        if (complete || !powerActivated || takeCol == receCol) { return; }
        pp.MoveWater(takeCol, receCol);
    }

    /**cycles the chosen "take" column up one (E>D>C>B>A)**/
    public void CycleTakeUp() {
        if (complete || !powerActivated) { return; }
        if (takeCol != 0) { takeCol--; }
        ct.UpdateLetter(takeCol);
        click.Play();
    }

    /**cycles the chosen "take" column down one (A>B>C>D>E)**/
    public void CycleTakeDown() {
        if (complete || !powerActivated) { return; }
        if (takeCol != COLUMNS-1) { takeCol++; }
        ct.UpdateLetter(takeCol);
        click.Play();
    }

    /**cycles the chosen "receive" column up one (E>D>C>B>A)**/
    public void CycleReceiveUp() {
        if (complete || !powerActivated) { return; }
        if (receCol != 0) { receCol--; }
        cr.UpdateLetter(receCol);
        click.Play();
    }

    /**cycles the chosen "receive" column down one (A>B>C>D>E)**/
    public void CycleReceiveDown() {
        if (complete || !powerActivated) { return; }
        if (receCol != COLUMNS-1) { receCol++; }
        cr.UpdateLetter(receCol);
        click.Play();
    }
}
