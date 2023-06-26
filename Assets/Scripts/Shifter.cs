using TMPro;
using UnityEngine;
using System;

public class Shifter : MonoBehaviour
{
    [Header("Lines")]
    [SerializeField] private Line inputLine;
    [SerializeField] private Line outputLine;

    [Header("UI")]
    [SerializeField] private TextMeshPro text;

    private uint shiftFactor;

    public void SetShifterCount(uint count)
    {
        shiftFactor = count;
        text.text = $"N>>{shiftFactor}";
    }

    public void Propagate()
    {
        double inputvalue = inputLine.Value;
        //shift
        outputLine.SetValue(inputvalue / Math.Pow(2, shiftFactor));
    }

}
