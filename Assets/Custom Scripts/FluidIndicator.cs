using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FluidIndicator : MonoBehaviour {

    public int maxLevel;
    private int level;
    private float maxHeight;

    // Start is called before the first frame update
    void Start() {
        level = maxLevel;
        maxHeight = transform.localScale.y;
    }

    // Update is called once per frame
    void Update() {

        //if gauge down was pressed, reduce level of water
        if (Game.Instance.input.Default.GuageDown.WasPressedThisFrame() && level != 0) {
            MoveDown(1);
        }

        //if guage up was pressed, increase level of water
        else if (Game.Instance.input.Default.GuageUp.WasPressedThisFrame() && level != maxLevel) {
            MoveUp(1);
        }

        //if guage reset was pressed, return to max level
        else if (Game.Instance.input.Default.GuageReset.WasPressedThisFrame()) {
            ResetLevel();
        }
    }

    private void MoveUp(int diff) {
        level += diff;
        UpdateWaterLevel();
    }
    private void MoveDown(int diff) {
        level -= diff;
        UpdateWaterLevel();
    }
    private void ResetLevel() {
        level = maxLevel;
        UpdateWaterLevel();
    }

    void UpdateWaterLevel() {
        var curVector = transform.localScale;
        curVector.y = maxHeight * (float)level / (float)maxLevel;
        transform.localScale = curVector;

        curVector = transform.localPosition;
        curVector.y = (maxHeight / (float)maxLevel * ((float)level - (float)maxLevel)) / 2;
        transform.localPosition = curVector;
    }
}
