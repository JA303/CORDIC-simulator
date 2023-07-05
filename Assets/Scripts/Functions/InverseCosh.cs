using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class InverseCosh : FreeInputHyperbolic
{
     public override double3 GetInput(double3 userInput)
    {
        cordicInput = new double3(math.sqrt(math.pow(userInput.x, 2) - 1), userInput.x, 0);
        this.userInput = userInput;
        return cordicInput;
    }

    public override string OutputMessage(double3 cordicOutput)
    {
        string msg = 
        "<color=blue>Real Outputs:</color>\n" +
        $"cosh^-1(w) = {MathF.Acosh((float)userInput.x)}\n" +
        "<color=blue>Simulation Outputs:</color>\n" +
        $"cosh^-1(w) = Ln(w + x) = {cordicOutput.z}\n" +
        "<color=blue>Cordic Input:</color>\n" +
        $"x = sqrt(w^2 - 1) = {cordicInput.x}\n" +
        $"y = w = {cordicInput.y}\n" +
        $"z = {cordicInput.z}\n" +
        base.OutputMessage(cordicOutput);

        return msg;
    }
}
