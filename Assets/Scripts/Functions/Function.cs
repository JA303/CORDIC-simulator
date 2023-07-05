using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UI;

public abstract class Function : MonoBehaviour
{
    public const double K = 1.646760258121;
    public const double K_pime = 0.8281593609602;

    private Button button;
    protected double3 cordicInput;
    protected double3 userInput;

    public void Awake()
    {
        button = GetComponent<Button>();
    }

    public abstract double3 GetInput(double3 userInput);

    public virtual (string, int) Message()
    {
        return (string.Empty, 0);
    }

    public void SetButtonInteractable(bool value)
    {
        if(!button)
            button = GetComponent<Button>();
        button.interactable = value;
    }

    public virtual string OutputMessage(double3 cordicOutput)
    {
        return "<color=blue>Cordic Output:</color>\n" +
        $"x = {cordicOutput.x}\n" +
        $"y = {cordicOutput.y}\n" +
        $"z = {cordicOutput.z}\n";
    }
}
