using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class FluidIndicator : MonoBehaviour {

    public int maxLevel;
    public int startLevel;
    private int level;
    private int oldLevel;
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

    public void UpdateAnimation(float ani_cur_time) {
        int diff = level - oldLevel;
        float curHeight = oldLevel + diff * ani_cur_time;
        UpdateWaterLevel(curHeight);
    }

    public void MoveUp(int diff) {
        oldLevel = level;
        level += diff;
    }
    public void MoveDown(int diff) {
        oldLevel = level;
        level -= diff;
    }
    private void ResetLevel() {
        oldLevel = level;
        level = startLevel;
    }

    void UpdateWaterLevel(float waterLevel) {
        var curVector = transform.localScale;
        curVector.y = maxHeight * waterLevel / (float)maxLevel;
        transform.localScale = curVector;

        curVector = transform.localPosition;
        curVector.y = (maxHeight / (float)maxLevel * (waterLevel - (float)maxLevel)) / 2;
        transform.localPosition = curVector;
    }

    public void LockWaterLevel() {
        UpdateWaterLevel(level);
    }
}
