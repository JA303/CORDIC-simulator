using UnityEngine;

public class CanvasZoom : MonoBehaviour
{
    [SerializeField] CameraController cameraController;
    [SerializeField] private float clickValue = 1;

    public void ZoomIn() => cameraController.TransformZoom(clickValue);
    public void ZoomOut() => cameraController.TransformZoom(-clickValue);

}
