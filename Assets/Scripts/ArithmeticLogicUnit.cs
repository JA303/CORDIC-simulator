using TMPro;
using UnityEngine;

public class ArithmeticLogicUnit : MonoBehaviour
{
    [SerializeField] private Line lineLeft;
    [SerializeField] private Line lineRight;

    [SerializeField] private bool invertDi = false;
    [SerializeField] private Line lineDi;

    [SerializeField] private Line outputLine;

    [Header("UI")]
    [SerializeField] protected TextMeshPro text;
    [SerializeField] private GameObject invertDiDot;


    protected int di;
    protected double in1;
    protected double in2;

    protected double output;

    private void Start()
    {
        invertDiDot.SetActive(invertDi);
    }

    protected virtual void ReadInputs()
    {
        di = (int)lineDi.Value;
        in1 = lineLeft.Value;
        in2 = lineRight.Value;
        if (invertDi)
            di *= -1;
    }

    public void Propagate()
    {
        ReadInputs();
        UpdateUI();

        output = GenerateOutput();
        WriteOutputs();
    }

    protected double GenerateOutput()
    {
        return in1 + (di * in2);
    }

    protected void WriteOutputs()
    {
        outputLine.SetValue(output);
    }

    protected virtual void UpdateUI()
    {
        if (di == -1)
            text.text = "ADD/<color=#f50233>SUB</color>";
        else if (di == 1)
            text.text = "<color=#02f517>ADD</color>/SUB";
        else
            text.text = "INVALID";
    }
}
