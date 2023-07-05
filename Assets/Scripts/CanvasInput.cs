using System;
using System.Collections;
using TMPro;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UI;

public class CanvasInput : MonoBehaviour
{
    [SerializeField] private Cordic cordic;
    [SerializeField] private CordicInputs cordicInputs;
    [Header("UI")]
    [SerializeField] private RectTransform verticalLayoutGroupRectTransform;
    [SerializeField] private Button[] buttons= new Button[0];
    [SerializeField] private FunctionList[] functionsList = new FunctionList[0];
    
    [Header("Open Close Panel")]
    [SerializeField] private RectTransform panelTransform;
    [SerializeField] private CameraController cameraController;
    [SerializeField] private GameObject panelCloseButton;
    [SerializeField] private GameObject panelOpenButton;
    private bool panelTransformAnimationRunning = false;

    [Header("Inputs")]
    [SerializeField] private TMP_InputField input_x;
    [SerializeField] private TMP_InputField input_y;
    [SerializeField] private TMP_InputField input_z;
    [SerializeField] private TMP_InputField input_w;

    [Header("inputs")]
    [SerializeField] private GameObject free_input_box;
    [SerializeField] private GameObject one_input_box;
    [SerializeField] private GameObject z_input_gameobject;

    [Header("Message")]
    [SerializeField] private RectTransform messageTransform;
    [SerializeField] private TextMeshProUGUI messageText;

    [Header("Output Message")]
    [SerializeField] private RectTransform outputMessageTransform;
    [SerializeField] private TextMeshProUGUI outputMessageText;

    [Header("Itration")]
    [SerializeField] private TextMeshProUGUI itrationTextCount;

    int selectedMode = 1;
    private void Start()
    {
        SelectMode(0);
    }

    public void ClosePanel()
    {
        if(panelTransformAnimationRunning) return;

        panelCloseButton.SetActive(false);
        panelOpenButton.SetActive(true);
        StartCoroutine(MovePanel(296));

        cameraController.XPostionWorkSpace = 1;
    }

    public void OpenPanel()
    {
        if(panelTransformAnimationRunning) return;

        panelCloseButton.SetActive(true);
        panelOpenButton.SetActive(false);
        StartCoroutine(MovePanel(0));

        cameraController.XPostionWorkSpace = 0.625f;
    }

    private IEnumerator MovePanel(float target)
    {
        panelTransformAnimationRunning = true;

        var t = 0f;
        var targetPos = new Vector3(target ,0 , 0);
        while( math.abs(panelTransform.anchoredPosition.x - target) > 1)
        {
            t += Time.deltaTime;
            panelTransform.anchoredPosition = Vector3.Lerp(panelTransform.anchoredPosition, targetPos, t);
            yield return null;
        }

        panelTransformAnimationRunning = false;
    }

    public void SelectMode(int modeIndex)
    {
        UapdateButtons(modeIndex, selectedMode);
        UapdateFunctionsList(modeIndex, selectedMode);

        cordicInputs.mode = (modeIndex % 2 == 0)? CordicBlock.Mode.ZToZero : CordicBlock.Mode.YToZero;
        cordicInputs.mu = (modeIndex == 0 || modeIndex == 1)? 1 :(modeIndex == 2 || modeIndex == 3) ? 0 : (modeIndex == 4 || modeIndex == 5)? -1 : 0;

        selectedMode = modeIndex;
        UpdateMessage();
        UpdateInputFeild();

        LayoutRebuilder.ForceRebuildLayoutImmediate(verticalLayoutGroupRectTransform);
    }

    public void UpdateInputFeild()
    {
        if(selectedMode == 2 || selectedMode == 3)
        {
            z_input_gameobject.SetActive(false);
            free_input_box.SetActive(true);
            one_input_box.SetActive(false);
            return;
        }
        z_input_gameobject.SetActive(true);

        if(functionsList[selectedMode].GetSelectedFunctionIndex() == 0)
        {
            free_input_box.SetActive(true);
            one_input_box.SetActive(false);
        }
        else
        {
            free_input_box.SetActive(false);
            one_input_box.SetActive(true);
        }
    }

    private void UapdateButtons(int newIndex, int oldIndex)
    {
        buttons[newIndex].interactable= false;
        buttons[oldIndex].interactable = true;
    }

    private void UapdateFunctionsList(int newIndex, int oldIndex)
    {
        functionsList[newIndex].transform.gameObject.SetActive(true);
        functionsList[oldIndex].transform.gameObject.SetActive(false);
    }

    public void OnItrationValueChange(Single newVal)
    {
        itrationTextCount.text = newVal.ToString();
        cordicInputs.itrationCount = (int)newVal - 1;
    }

    public void UpdateMessage()
    {
        (string, int) message = functionsList[selectedMode].GetSelectedFunction().Message();

        if(message.Item2 == 0)
        {
            messageTransform.gameObject.SetActive(false);
            messageText.text = string.Empty;
            return;
        }
        messageTransform.sizeDelta = new Vector2(256, message.Item2);
        messageTransform.gameObject.SetActive(true);
        messageText.text = message.Item1;

        
    }

    public void UpdateSimulation()
    {
        double3 functionInput = selectedMode == 2 || selectedMode == 3 || functionsList[selectedMode].GetSelectedFunctionIndex() == 0 ? 
        new double3(TryGetInput(input_x), TryGetInput(input_y), TryGetInput(input_z)) :
        new double3(TryGetInput(input_w), 0, 0);

        var selectedFunc = functionsList[selectedMode].GetSelectedFunction();

        var intput = selectedFunc.GetInput(functionInput);
        cordicInputs.x = intput.x;
        cordicInputs.y = intput.y;
        cordicInputs.z = intput.z;

        cordic.UpdateBlock();
        var cordicOutput = cordic.GetOutput();
        outputMessageText.text = selectedFunc.OutputMessage(cordicOutput);
    }

    private double TryGetInput(TMP_InputField inputFeild)
    {
        double result = 0;
        if(double.TryParse(inputFeild.text, out double value))
        {
            result = value;
        }
        return value;
    }
}
