using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SignGenerator : MonoBehaviour
{
    [SerializeField] private Line lineX;
    [SerializeField] private Line lineY;
    [SerializeField] private Line lineZ;
    [SerializeField] private Line lineDi;

    private CordicBlock.Mode mode;
    private int signX;
    private int signY;
    private int signZ;

    [Header("UI")]
    [SerializeField] private TextMeshPro text;

    public void SetMode(CordicBlock.Mode mode)
    {
        this.mode = mode;
        UpdateUI();
    }

    private void ReadInputs()
    {
        signX = lineX.Value >= 0? 1 : -1;
        signY = lineY.Value >= 0? 1 : -1;
        signZ = lineZ.Value >= 0? 1 : -1;
    }

    public void Propagate()
    {
        ReadInputs();
        if (mode == CordicBlock.Mode.ZToZero)
        {
            lineDi.SetValue(signZ);
        }
        else if (mode == CordicBlock.Mode.YToZero)
        {
            lineDi.SetValue(-1 * signX * signY);
        }
    }

    private void UpdateUI()
    {
        if (mode == CordicBlock.Mode.ZToZero)
        {
            text.text = "Mode: Z -> 0\n" +
                "di = Sign(Z)";
        } 
        else if (mode == CordicBlock.Mode.YToZero)
        {
            text.text = "Mode: Y -> 0\n" +
                "di = -Sign(XY)";
        }
    }
}
