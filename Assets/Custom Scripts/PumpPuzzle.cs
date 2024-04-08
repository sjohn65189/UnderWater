using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PumpPuzzle : MonoBehaviour
{

    public FluidIndicator fluidA;
    public FluidIndicator fluidB;
    public FluidIndicator fluidC;

    private bool animationActive = false;
    private float ani_tot_time = 0;
    private float ani_cur_time = 0;
    private float ani_multiplier = 1/12;

    private FluidIndicator take;
    private FluidIndicator receive;

    // Start is called before the first frame update
    void Start()
    {
        
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
            take = fluidA;
            receive = fluidB;
        }
        else if (Game.Instance.input.Default.AtoC.WasPressedThisFrame()) {
            take = fluidA;
            receive = fluidC;
        }
        else if (Game.Instance.input.Default.BtoA.WasPressedThisFrame()) {
            take = fluidB;
            receive = fluidA;
        }
        else if (Game.Instance.input.Default.BtoC.WasPressedThisFrame()) {
            take = fluidB;
            receive = fluidC;
        }
        else if (Game.Instance.input.Default.CtoA.WasPressedThisFrame()) {
            take = fluidC;
            receive = fluidA;
        }
        else if (Game.Instance.input.Default.CtoB.WasPressedThisFrame()) {
            take = fluidC;
            receive = fluidB;
        }
        else {
            return;
        }

        int totalTransport = take.GetLevel();
        int totalAvailable = receive.GetEmptySpace();

        int amount;
        if (totalTransport > totalAvailable) { amount = totalAvailable; }
        else { amount = totalTransport; }

        if(amount == 0) { return; }

        take.MoveDown(amount);
        receive.MoveUp(amount);

        animationActive = true;

        ani_tot_time = (float)amount * ani_multiplier;
    }
}
