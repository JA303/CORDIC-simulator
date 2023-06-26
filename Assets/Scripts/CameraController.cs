using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Camera _camera;

    [Header("Border")]
    [SerializeField] private Vector3 minPosition;
    [SerializeField] private Vector3 maxPosition;
    [SerializeField] private float xPostionWorkSpace;
    
    [Header("Move")]
    [SerializeField] private float dragSpeed = 0.89f;
    [SerializeField] private float dragStopLerp = 0.5f;

    [Header("Zoom")]
    [SerializeField] private float initialZoom = 5f;
    [SerializeField] private float zoomStep = 4;
    [SerializeField] private float zoomSpeed = 16;

    private Vector3 dragOrigin;
    private Vector3 lastMousePosition;
    private Vector3 velocity;

    private bool isStartDrag;
    private bool isMouseInRange;

    private float tagetZoom;

    private void Start()
    {
        _camera.orthographicSize = initialZoom;
        tagetZoom = initialZoom;
    }

    void Update()
    {
        isMouseInRange = _camera.ScreenToViewportPoint(Input.mousePosition).x < xPostionWorkSpace;

        if (Input.GetMouseButtonDown(0))
        {
            if(isMouseInRange)
            {
                dragOrigin = Input.mousePosition;
                lastMousePosition = dragOrigin;
                isStartDrag = true;
            }
            else
            {
                isStartDrag = false;
            }
        }
        else if (isStartDrag && Input.GetMouseButton(0))
        {
            var moveNormal = (tagetZoom / initialZoom);
            Vector3 pos = _camera.ScreenToViewportPoint(lastMousePosition - Input.mousePosition);
            var speed = dragSpeed * moveNormal;
            Vector3 move = new Vector3(pos.x * speed * 16, pos.y * speed * 9, 0) ;

            var newPosiotion = transform.position + move;
            if (newPosiotion.x < minPosition.x)
                newPosiotion.x = minPosition.x;
            else if (newPosiotion.x > maxPosition.x)
                newPosiotion.x = maxPosition.x;
            if (newPosiotion.y < minPosition.y)
                newPosiotion.y = minPosition.y;
            else if (newPosiotion.y > maxPosition.y)
                newPosiotion.y = maxPosition.y;

            transform.position = newPosiotion;

            velocity = Vector3.Lerp(velocity, move / Time.deltaTime, 0.75f);

            lastMousePosition = Input.mousePosition;
        }
        else
        {
            var newPosiotion = transform.position + velocity * Time.deltaTime;
            if (newPosiotion.x < minPosition.x)
                newPosiotion.x = minPosition.x;
            else if (newPosiotion.x > maxPosition.x)
                newPosiotion.x = maxPosition.x;
            if (newPosiotion.y < minPosition.y)
                newPosiotion.y = minPosition.y;
            else if (newPosiotion.y > maxPosition.y)
                newPosiotion.y = maxPosition.y;

            transform.position = newPosiotion;

            velocity = Vector3.Lerp(velocity, Vector3.zero, dragStopLerp * Time.deltaTime);
        }

        if (isMouseInRange)
        {
            tagetZoom -= Input.GetAxis("Mouse ScrollWheel") * zoomStep;
            if (tagetZoom < minPosition.z)
                tagetZoom = minPosition.z;
            if (tagetZoom > maxPosition.z)
                tagetZoom = maxPosition.z;
        }
        
        _camera.orthographicSize = Mathf.Lerp(_camera.orthographicSize, tagetZoom, zoomSpeed * Time.deltaTime);
    }

    public void SetMinY(float newY)
    {
        minPosition.y= newY;
    }

    public void TransformZoom(float zoomCount)
    {
        tagetZoom -= zoomCount * zoomStep;
    }
}
