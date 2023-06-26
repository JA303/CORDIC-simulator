using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;

public class CordicBlock : MonoBehaviour
{

    [Header("Components")]
    [SerializeField] private LookUpTable lookUpTable;
    [SerializeField] private SignGenerator signGenerator;
    [SerializeField] private Line lineMu;

    [SerializeField] private IOLines inputLines;
    [SerializeField] private IOLines outputLines;
    [SerializeField] private Shifter[] shifters = new Shifter[2];
    [SerializeField] private ArithmeticLogicUnit[] arithmeticLogicUnits = new ArithmeticLogicUnit[3];

    [Header("UI")]
    [SerializeField] private AxisDiagram axisDiagram;
    [SerializeField] private TextMeshPro itrationText;

    public IOLines InputLines => inputLines;
    public IOLines OutputLines => outputLines;
    public enum Mode
    {
        ZToZero,
        YToZero
    }

    private uint itration;

    public void Initialize(Mode mode, int mu)
    {
        lineMu.SetValue(mu);
        signGenerator.SetMode(mode);
        foreach (var shifter in shifters)
            shifter.SetShifterCount(itration);

        UpdateItrationText();
    }

    public void Initialize(uint itration, bool isLastBlock)
    {
        this.itration = itration;
        outputLines.lineX.LineValueVisualizer.gameObject.SetActive(isLastBlock);
        outputLines.lineY.LineValueVisualizer.gameObject.SetActive(isLastBlock);
        outputLines.lineZ.LineValueVisualizer.gameObject.SetActive(isLastBlock);
    }


    public void Propagate()
    {
        //Level 1 Gates

        lookUpTable.Propagate(itration);
        signGenerator.Propagate();

        foreach (var shifter in shifters)
            shifter.Propagate();

        //Level 2 Gates
        foreach (var alu in arithmeticLogicUnits)
            alu.Propagate();

        UpdateAxisUI();
    }

    private void UpdateItrationText()
    {
        var i = lineMu.Value == -1 ? itration + 1 : itration;
        itrationText.text = $"Step={itration}\ni={i}";
    }

    private void UpdateAxisUI()
    {
        axisDiagram.UpdateVector(outputLines.lineX.Value, outputLines.lineY.Value);
    }

}

[System.Serializable]
public struct IOLines
{
    public Line lineX;
    public Line lineY;
    public Line lineZ;
}
