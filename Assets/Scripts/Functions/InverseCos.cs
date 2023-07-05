using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class InverseCos : FreeInputCircular
{
    public override double3 GetInput(double3 userInput)
    {
        cordicInput = new double3(userInput.x, math.sqrt(1 - math.pow(userInput.x, 2)) , 0);
        this.userInput = userInput;
        return cordicInput;
    }

    public override string OutputMessage(double3 cordicOutput)
    {
        string msg = 
        "<color=blue>Real Outputs:</color>\n" +
        $"cos^-1(w) = {math.acos(userInput.x)}\n" +
        "<color=blue>Simulation Outputs:</color>\n" +
        $"cos^-1(w) = {cordicOutput.z}\n" +
        "<color=blue>Cordic Input:</color>\n" +
        $"x = w = {cordicInput.x}\n" +
        $"y = sqrt(1 - w^2) = {cordicInput.y}\n" +
        $"z = {cordicInput.z}\n" +
        base.OutputMessage(cordicOutput);

        return msg;
    }
}
