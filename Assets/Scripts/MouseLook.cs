using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    [SerializeField] private float mouseSensivity = 1f;
    [SerializeField] private Transform mainCamera;
    [SerializeField] private float minX;
    [SerializeField] private float maxX;

    private float _xRotation;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update()
    {
        var mouseHorizontal = Input.GetAxis("Mouse X") * mouseSensivity * Time.deltaTime;
        var mouseVertical = Input.GetAxis("Mouse Y") * mouseSensivity * Time.deltaTime;
        _xRotation -= mouseVertical;
        _xRotation = Mathf.Clamp(_xRotation, minX, maxX);
        mainCamera.localRotation = Quaternion.Euler(_xRotation,0,0);
        transform.Rotate(Vector3.up,mouseHorizontal);
    }
}
