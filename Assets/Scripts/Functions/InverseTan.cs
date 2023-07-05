using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class InverseTan : FreeInputCircular
{
    public override double3 GetInput(double3 userInput)
    {
        cordicInput = new double3(1, userInput.x, 0);
        this.userInput = userInput;
        return cordicInput;
    }

    public override string OutputMessage(double3 cordicOutput)
    {
        string msg = 
        "<color=blue>Real Outputs:</color>\n" +
        $"tan^-1(w) = {math.atan(userInput.x)}\n" +
        "<color=blue>Simulation Outputs:</color>\n" +
        $"tan^-1(w) = z = {cordicOutput.z}\n" +
        "<color=blue>Cordic Input:</color>\n" +
        $"x = {cordicInput.x}\n" +
        $"y = {cordicInput.y}\n" +
        $"z = {cordicInput.z}\n" +
        base.OutputMessage(cordicOutput);

        return msg;
    }
}
