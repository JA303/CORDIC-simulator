using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class Ln : FreeInputHyperbolic
{
    private double yValue;
     public override double3 GetInput(double3 userInput)
    {
        yValue = math.abs((userInput.x - 1) / (userInput.x + 1));
        cordicInput = new double3(1, yValue, 0);
        this.userInput = userInput;
        return cordicInput;
    }

    public override string OutputMessage(double3 cordicOutput)
    {
        string msg = 
        "<color=blue>Real Outputs:</color>\n" +
        $"Ln(w) = {math.log(userInput.x)}\n" +
        "<color=blue>Simulation Outputs:</color>\n" +
        $"Ln(w) = 2tanh^-1 (|(w-1)/(w+1)|) = {cordicOutput.z * 2}\n" +
        "<color=blue>Cordic Input:</color>\n" +
        $"x = {cordicInput.x}\n" +
        $"y = {cordicInput.y}\n" +
        $"z = {cordicInput.z}\n" +
        base.OutputMessage(cordicOutput);

        return msg;
    }
}
