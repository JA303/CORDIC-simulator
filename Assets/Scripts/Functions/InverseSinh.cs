using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class InverseSinh : FreeInputHyperbolic
{
     public override double3 GetInput(double3 userInput)
    {
        cordicInput = new double3(math.sqrt(1 + math.pow(userInput.x, 2)), userInput.x, 0);
        this.userInput = userInput;
        return cordicInput;
    }

    public override string OutputMessage(double3 cordicOutput)
    {
        string msg = 
        "<color=blue>Real Outputs:</color>\n" +
        $"sinh^-1(w) = {MathF.Asinh((float)userInput.x)}\n" +
        "<color=blue>Simulation Outputs:</color>\n" +
        $"sinh^-1(w) = Ln(w + x) = {cordicOutput.z}\n" +
        "<color=blue>Cordic Input:</color>\n" +
        $"x = sqrt(w^2 + 1) = {cordicInput.x}\n" +
        $"y = w ={cordicInput.y}\n" +
        $"z = {cordicInput.z}\n" +
        base.OutputMessage(cordicOutput);

        return msg;
    }
}
