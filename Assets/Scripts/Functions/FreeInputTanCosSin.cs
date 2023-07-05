using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class FreeInputTanCosSin : FreeInputCircular
{
    public override double3 GetInput(double3 userInput)
    {
        cordicInput = new double3(1 / K, 0, userInput.x);
        this.userInput = userInput;
        return cordicInput;
    }

    public override string OutputMessage(double3 cordicOutput)
    {
        string msg = 
        "<color=blue>Real Outputs:</color>\n" +
        $"cos(w) = {math.cos(userInput.x)}\n" +
        $"sin(w) = {math.sin(userInput.x)}\n" +
        $"tan(w) = {math.tan(userInput.x)}\n" +
        "<color=blue>Simulation Outputs:</color>\n" +
        $"cos(w) = {cordicOutput.x}\n" +
        $"sin(w) = {cordicOutput.y}\n" +
        $"tan(w) = sin(w)/cos(w) = {cordicOutput.y / cordicOutput.x}\n" +
        "<color=blue>Cordic Input:</color>\n" +
        $"x = {cordicInput.x}\n" +
        $"y = {cordicInput.y}\n" +
        $"z = {cordicInput.z}\n" +
        base.OutputMessage(cordicOutput);

        return msg;
    }
}
