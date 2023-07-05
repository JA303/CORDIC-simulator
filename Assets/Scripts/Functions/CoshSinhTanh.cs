using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class CoshSinhTanh : FreeInputHyperbolic
{
    public override double3 GetInput(double3 userInput)
    {
        cordicInput = new double3(1 / K_pime, 0, userInput.x);
        this.userInput = userInput;
        return cordicInput;
    }

    public override string OutputMessage(double3 cordicOutput)
    {
        string msg = 
        "<color=blue>Real Outputs:</color>\n" +
        $"cosh(w) = {math.cosh(userInput.x)}\n" +
        $"sinh(w) = {math.sinh(userInput.x)}\n" +
        $"tanh(w) = {math.tanh(userInput.x)}\n" +
        $"e^(w) = {math.exp(userInput.x)}\n" +
        "<color=blue>Simulation Outputs:</color>\n" +
        $"cosh(w) = {cordicOutput.x}\n" +
        $"sinh(w) = {cordicOutput.y}\n" +
        $"tanh(w) = sin(w)/cos(w) = {cordicOutput.y / cordicOutput.x}\n" +
        $"e^(w) = sin(w) + cos(w) = {cordicOutput.y + cordicOutput.x}\n" +
        "<color=blue>Cordic Input:</color>\n" +
        $"x = {cordicInput.x}\n" +
        $"y = {cordicInput.y}\n" +
        $"z = {cordicInput.z}\n" +
        base.OutputMessage(cordicOutput);

        return msg;
    }
}
