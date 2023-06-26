using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CanvasInput : MonoBehaviour
{
    [SerializeField] private Cordic cordic;
    [SerializeField] private CordicInputs cordicInputs;
    [Header("UI")]
    [SerializeField] private Button[] buttons= new Button[0];
    [SerializeField] private GameObject[] functionsList = new GameObject[0];

    [Header("Itration")]
    [SerializeField] private TextMeshProUGUI itrationTextCount;

    int selectedMode = 1;
    private void Start()
    {
        SelectMode(0);
    }

    public void SelectMode(int modeIndex)
    {
        UapdateButtons(modeIndex, selectedMode);
        UapdateFunctionsList(modeIndex, selectedMode);
        cordicInputs.mode = (modeIndex % 2 == 0)? CordicBlock.Mode.ZToZero : CordicBlock.Mode.YToZero;
        cordicInputs.mu = (modeIndex == 0 || modeIndex == 1)? 1 :(modeIndex == 2 || modeIndex == 3) ? 0 : (modeIndex == 4 || modeIndex == 5)? -1 : 0;

        selectedMode = modeIndex;
    }

    private void UapdateButtons(int newIndex, int oldIndex)
    {
        buttons[newIndex].interactable= false;
        buttons[oldIndex].interactable = true;
    }

    private void UapdateFunctionsList(int newIndex, int oldIndex)
    {
        functionsList[newIndex].gameObject.SetActive(true);
        functionsList[oldIndex].SetActive(false);
    }

    public void OnItrationValueChange(Single newVal)
    {
        itrationTextCount.text = newVal.ToString();
        cordicInputs.itrationCount = (int)newVal - 1;
    }
}
