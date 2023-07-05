using UnityEngine;
using UnityEngine.UI;

public class FunctionList : MonoBehaviour
{
    [SerializeField] private CanvasInput canvasInput;
    [SerializeField] private Function[] FunctionButtons = new Function[0];

    private int selectedFunctionIndex;

    public int GetSelectedFunctionIndex() => selectedFunctionIndex;

    public void Start()
    {
        selectedFunctionIndex = 1;
        SelectFunction(0);
    }

    public void SelectFunction(int index)
    {
        UpdateButtons(index, selectedFunctionIndex);
        selectedFunctionIndex = index;

        canvasInput.UpdateInputFeild();
        canvasInput.UpdateMessage();
    }

    public Function GetSelectedFunction() => FunctionButtons[selectedFunctionIndex];

    private void UpdateButtons(int newIndex, int oldIndex)
    {
        FunctionButtons[newIndex].SetButtonInteractable(false);
        FunctionButtons[oldIndex].SetButtonInteractable(true);
    }
}
