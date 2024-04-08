using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PumpPuzzle : MonoBehaviour
{

    public FluidIndicator fluidA;
    public FluidIndicator fluidB;
    public FluidIndicator fluidC;
    public FluidIndicator fluidD;
    public FluidIndicator fluidE;
    public FluidIndicator[] column = new FluidIndicator[5];

    private bool animationActive = false;
    private float ani_tot_time = 0;
    private float ani_cur_time = 0;
    private float ani_multiplier = 1/12;

    private FluidIndicator take;
    private FluidIndicator receive;

    // Start is called before the first frame update
    void Start() {
        column[0] = fluidA;
        column[1] = fluidB;
        column[2] = fluidC;
        column[3] = fluidD;
        column[4] = fluidE;
    }

    // Update is called once per frame
    void Update() {

        if (animationActive) {
            ani_cur_time += Time.deltaTime;

            take.UpdateAnimation(ani_cur_time);
            receive.UpdateAnimation(ani_cur_time);

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

        if (Game.Instance.input.Default.AtoB.WasPressedThisFrame()) {
            MoveWater(column[0], column[1]);
        }
        else if (Game.Instance.input.Default.AtoC.WasPressedThisFrame()) {
            MoveWater(column[0], column[2]);
        }
        else if (Game.Instance.input.Default.BtoA.WasPressedThisFrame()) {
            MoveWater(column[1], column[0]);
        }
        else if (Game.Instance.input.Default.BtoC.WasPressedThisFrame()) {
            MoveWater(column[1], column[2]);
        }
        else if (Game.Instance.input.Default.CtoA.WasPressedThisFrame()) {
            MoveWater(column[2], column[0]);
        }
        else if (Game.Instance.input.Default.CtoB.WasPressedThisFrame()) {
            MoveWater(column[2], column[1]);
        }
    }

    public void MoveWater(FluidIndicator take, FluidIndicator receive) {

        this.take = take;
        this.receive = receive;

        int totalTransport = take.GetLevel();
        int totalAvailable = receive.GetEmptySpace();

        int amount;
        if (totalTransport > totalAvailable) { amount = totalAvailable; }
        else { amount = totalTransport; }

        if (amount == 0) { return; }

        take.MoveDown(amount);
        receive.MoveUp(amount);

        animationActive = true;

        ani_tot_time = (float)amount * ani_multiplier;
    }
}
