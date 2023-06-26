using UnityEngine;
using UnityEngine.UI;

public class FunctionList : MonoBehaviour
{
    [SerializeField] private Button[] FunctionButtons = new Button[0];

    private int selectedFunctionIndex;

    public void SelectFunction(int index)
    {
        UpdateButtons(index, selectedFunctionIndex);
    }

    private void UpdateButtons(int newIndex, int oldIndex)
    {
        FunctionButtons[newIndex].interactable = false;
        FunctionButtons[oldIndex].interactable = true;
    }
}
