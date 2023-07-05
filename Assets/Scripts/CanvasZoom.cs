using UnityEngine;

public class CanvasZoom : MonoBehaviour
{
    [SerializeField] CameraController cameraController;
    [SerializeField] private float clickValue = 1;

    public void Awake()
    {
        Application.targetFrameRate = 30;
    }

    public void ZoomIn() => cameraController.TransformZoom(clickValue);
    public void ZoomOut() => cameraController.TransformZoom(-clickValue);

    public void CloseApp()
    {
        Application.Quit();
    }

}
