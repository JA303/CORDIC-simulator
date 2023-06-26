using TMPro;
using UnityEngine;

public class LineValueVisualizer : MonoBehaviour
{
    [SerializeField] private TextMeshPro text;

    public void UpdateValue(double newValue)
    {
        text.text = newValue.ToString();
    }
}
