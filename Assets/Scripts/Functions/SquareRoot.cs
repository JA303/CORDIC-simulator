using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class SquareRoot : FreeInputHyperbolic
{
     public override double3 GetInput(double3 userInput)
    {
        cordicInput = new double3(userInput.x + (1.0d/4.0d), userInput.x - (1.0d/4.0d), 0);
        this.userInput = userInput;
        return cordicInput;
    }

    public override string OutputMessage(double3 cordicOutput)
    {
        string msg = 
        "<color=blue>Real Outputs:</color>\n" +
        $"sqrt(w) = {math.sqrt(userInput.x)}\n" +
        "<color=blue>Simulation Outputs:</color>\n" +
        $"sqrt(w) = sqrt(x^2 - y^2) = {cordicOutput.x}\n" +
        "<color=blue>Cordic Input:</color>\n" +
        $"x = (w + 1/4) = {cordicInput.x}\n" +
        $"y = (w - 1/4) = {cordicInput.y}\n" +
        $"z = {cordicInput.z}\n" +
        base.OutputMessage(cordicOutput);

        return msg;
    }
}
