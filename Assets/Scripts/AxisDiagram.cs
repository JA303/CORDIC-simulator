using TMPro;
using UnityEngine;

public class AxisDiagram : MonoBehaviour
{
    private Vector2 vectorValue;
    private float angle;
    
    [Header("UI")]
    [SerializeField] private TextMeshPro angleText;
    [SerializeField] private Transform vectorPointTransform;
    public void UpdateVector(double x, double y)
    {
        vectorValue = new Vector2((float)x, (float)y);
        vectorPointTransform.localPosition = vectorValue;
        UpdateAngle();
    }

    private void UpdateAngle()
    {
        angle = Vector2.Angle(Vector2.right, vectorValue);
        angleText.text = angle.ToString();
    }
}
