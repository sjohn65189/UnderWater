using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class FluidIndicator : MonoBehaviour {

    //maximum units of water this column holds (set in inspector)
    public int maxLevel;

    //how many units of water this column stars with (set in inspector)
    public int startLevel;

    //current units of water
    private int level;

    //how many units of water this column had before it changed
    private int oldLevel;

    //how high the scale of the column can be in the physical game
    private float maxHeight;

    public int GetLevel() { return level; }
    public int GetEmptySpace() { return maxLevel - level; }

    // Start is called before the first frame update
    void Start() {
        level = startLevel;
        oldLevel = level;
        maxHeight = transform.localScale.y;
        UpdateWaterLevel(level);
    }

    void Update() {}

    /**set the scale of the column depending on the current time in the animation**/
    public void UpdateAnimation(float ani_cur_time) {
        int diff = level - oldLevel;
        float curHeight = oldLevel + diff * ani_cur_time;
        UpdateWaterLevel(curHeight);
    }

    /**move the column up by "diff" units**/
    public void MoveUp(int diff) {
        oldLevel = level;
        level += diff;
    }

    /**move the column down by "diff" units**/
    public void MoveDown(int diff) {
        oldLevel = level;
        level -= diff;
    }

    /**reset the column back to its starting units**/
    private void ResetLevel() {
        oldLevel = level;
        level = startLevel;
    }

    /**does the math to calculate scale and position based on current water level**/
    void UpdateWaterLevel(float waterLevel) {
        var curVector = transform.localScale;
        curVector.y = maxHeight * waterLevel / (float)maxLevel;
        transform.localScale = curVector;

        curVector = transform.localPosition;
        curVector.y = (maxHeight / (float)maxLevel * (waterLevel - (float)maxLevel)) / 2;
        transform.localPosition = curVector;
    }

    /**after an animation is done, ensures the physical water level is set to an integer (not a float)
     * since the animation uses floats to calculate water level in between units**/
    public void LockWaterLevel() {
        UpdateWaterLevel(level);
    }
}
