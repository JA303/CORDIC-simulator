using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class Division : FreeInputLinear
{
    public override double3 GetInput(double3 userInput)
    {
        cordicInput = new double3(userInput.y ,userInput.x, 0);
        this.userInput = userInput;
        return cordicInput;
    }

    public override string OutputMessage(double3 cordicOutput)
    {
        string msg = 
        "<color=blue>Real Outputs:</color>\n" +
        $"x / y = {userInput.x / userInput.y}\n" +
        "<color=blue>Simulation Outputs:</color>\n" +
        $"x / y = {cordicOutput.z}\n" +
        "<color=blue>Cordic Input:</color>\n" +
        $"x = {cordicInput.x}\n" +
        $"y = {cordicInput.y}\n" +
        $"z = {cordicInput.z}\n" +
        base.OutputMessage(cordicOutput);

        return msg;
    }
}
