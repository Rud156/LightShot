﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExtensionFunctions
{
    public static float Map(float from, float fromMin, float fromMax, float toMin, float toMax)
    {
        var fromAbs = from - fromMin;
        var fromMaxAbs = fromMax - fromMin;

        var normal = fromAbs / fromMaxAbs;

        var toMaxAbs = toMax - toMin;
        var toAbs = toMaxAbs * normal;

        var to = toAbs + toMin;

        return to;
    }

    public static string Format2DecimalPlace(float value) => value.ToString("0.##");
}
