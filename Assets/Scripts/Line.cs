using UnityEngine;

public class Line : MonoBehaviour
{
    [SerializeField] private LineValueVisualizer lineValueVisualizer;
    public LineValueVisualizer LineValueVisualizer => lineValueVisualizer;
    public double Value { private set; get; }

    public void SetValue(double value)
    {
        Value = value;
        lineValueVisualizer.UpdateValue(value);
    }
}
