using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class FreeInputHyperbolic : Function
{
    public override double3 GetInput(double3 userInput)
    {
        this.userInput = userInput;
        cordicInput = userInput;
        return userInput;
    }

    public override (string, int) Message()
    {
        const string msg = "convergence in computing hyperbolic sine and cosine functions is guaranteed for |z| < 1.13";
        return (msg, 52);
    }
}
