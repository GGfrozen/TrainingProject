using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour
{
    private Color defaultColor;

    public void SetColor()
    {
        var meshNow = GetComponent<MeshRenderer>();
        meshNow.material.color = defaultColor;

    }
    
    private void Start()
    {
        defaultColor = GetComponent<MeshRenderer>().material.color;
         
    }

    
}
