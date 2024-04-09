using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PumpPuzzle : MonoBehaviour
{

    //put all of these in an array so they're easier to access
    public FluidIndicator[] column = new FluidIndicator[5];

    //animation values
    private bool animationActive = false;
    private float ani_tot_time = 0;
    private float ani_cur_time = 0;
    private float ani_multiplier = (float)1/(float)12;

    //fluid column currently being taken from
    private FluidIndicator take;

    //fluid column currently receiving water
    private FluidIndicator receive;

    //becomes true once puzzle is completed
    private bool completed = false;
    public bool IsComplete() { return completed; }

    public GameObject pumpCompletion;

    //start
    void Start() {
    
    }

    //update handles the rising/falling animation of water
    void Update() {

        //only calculate if animation is active
        if (animationActive) {

            //keep track of time
            ani_cur_time += Time.deltaTime;

            //set the water level to be the percentage of time in the animation
            take.UpdateAnimation(ani_cur_time/ani_tot_time);
            receive.UpdateAnimation(ani_cur_time/ani_tot_time);

            //the animation has completed, reset all necessary values
            if(ani_cur_time >= ani_tot_time) {
                ani_cur_time = ani_tot_time = 0;
                take.LockWaterLevel();
                receive.LockWaterLevel();
                take = null;
                receive = null;
                animationActive = false;
            }
            return;
        }

        if (column[0].GetLevel() == 3 && column[3].GetLevel() == 3 && column[4].GetLevel() == 6) {
            completed = true;
            pumpCompletion.SetActive(true);
        }
    }

    /**move water using integers for the columns**/
    public void MoveWater(int take, int receive) { MoveWater(column[take], column[receive]); }

    /**take water from the "take" column and give it to the "receive" column**/
    public void MoveWater(FluidIndicator take, FluidIndicator receive) {

        this.take = take;
        this.receive = receive;

        //determine how much water is going to be transferred
        int totalTransport = take.GetLevel();
        int totalAvailable = receive.GetEmptySpace();

        int amount;
        if (totalTransport > totalAvailable) { amount = totalAvailable; }
        else { amount = totalTransport; }

        if (amount == 0) { return; }

        //transfer it
        take.MoveDown(amount);
        receive.MoveUp(amount);

        //begin animation
        animationActive = true;
        ani_tot_time = (float)amount * (float)ani_multiplier;
    }
}
