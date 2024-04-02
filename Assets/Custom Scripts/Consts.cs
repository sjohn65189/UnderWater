using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Consts
{
    public static class Tags
    {
        public const string pressureAdd = "PressureBox";
        public const string pressureAddSecond = "PressureBoxHigh";
        public const string pressureReducer = "PressureBoxReduce";
        public const string pressureReset = "PressureBoxReset";
        public const string pressureMult = "PressureBoxMult";
    }

    public static class PressureValues
    {
        public const int pressureAddLow = 3;
        public const int pressureAddHigh = 7;
        public const int pressureReduce = -8;
    }
}
