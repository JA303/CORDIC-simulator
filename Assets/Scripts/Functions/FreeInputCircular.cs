using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class FreeInputCircular : Function
{
    public override double3 GetInput(double3 userInput)
    {
        this.userInput = userInput;
        cordicInput = userInput;
        return userInput;
    }

    public override (string, int) Message()
    {
        const string msg = "The domain of convergence is −99.7◦ ≤ z ≤ 99.7◦,";
        return (msg, 25);
    }

}