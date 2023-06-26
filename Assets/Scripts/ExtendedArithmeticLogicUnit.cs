using UnityEngine;

public class ExtendedArithmeticLogicUnit : ArithmeticLogicUnit
{
    [Header("Extended")]
    [SerializeField] private Line lineMu;

    private int mu;

    protected override void ReadInputs()
    {
        base.ReadInputs();
        mu = (int)lineMu.Value;

        di *= mu;
    }

    protected override void UpdateUI()
    {
        if (di == -1)
            text.text = "ADD/<color=#f50233>SUB</color>/NONE";
        else if (di == 1)
            text.text = "<color=#02f517>ADD</color>/SUB/NONE";
        else if (di == 0)
            text.text = "ADD/SUB/<color=#02f5e9>NONE</color>";
        else
            text.text = "INVALID";
    }

}
