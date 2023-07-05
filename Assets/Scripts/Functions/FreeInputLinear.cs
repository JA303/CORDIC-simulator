using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class FreeInputLinear : Function
{
    public override double3 GetInput(double3 userInput)
    {
        this.userInput = userInput;
        cordicInput = userInput;
        return userInput;
    }

    public override (string, int) Message()
    {
        const string msg = "the amount of output error decreases with increasing number of itration";
        return (msg, 52);
    }
}
