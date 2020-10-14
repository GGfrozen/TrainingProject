using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 1f;
    [SerializeField] private Camera playerCamera;
    [SerializeField] private Camera weaponCamera;
    [SerializeField] private int normalView = 60;
    [SerializeField] private int aimView = 30;
    [SerializeField] private bool arrayController;
    
    private bool _isAim;

    private void Start()
    {
   
        _isAim = false;
    }

    private void Update()
    {
        UseAim();
    }

    private void FixedUpdate()
    {
        Move();

    }

    private void Move()
    {
        if (!arrayController)
        {
            MoveLogic("HorizontalWASD", "VerticalWASD");
        }
        else
        {
            MoveLogic("HorizontalArray", "VerticalArray");
        }
        
    }

    private void MoveLogic(string s1Horizontal, string s2Vertical)
    {
        var inputHorizontal = Input.GetAxis(s1Horizontal);
        var inputVertical = Input.GetAxis(s2Vertical);
        var movement = new Vector3(inputHorizontal, 0.0f, inputVertical);
        transform.Translate(movement * (moveSpeed * Time.deltaTime));
    }

    private void UseAim()
    {
        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            if (!_isAim)
            {
                playerCamera.fieldOfView = aimView;
                weaponCamera.fieldOfView = aimView;
                _isAim = true;
            }
            else
            {
                playerCamera.fieldOfView = normalView;
                weaponCamera.fieldOfView = normalView;
                _isAim = false;
            }
        }

    }
}

    
