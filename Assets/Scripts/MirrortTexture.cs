using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MirrortTexture : MonoBehaviour
{
    [SerializeField] private Camera mirrorCamera;

    private MeshRenderer mesh;
    private RenderTexture rt;

    private void Start()
    {
        mesh = GetComponent<MeshRenderer>();
        rt = new RenderTexture(256, 256, 24, RenderTextureFormat.ARGB32);
        var mirrorMateril = mesh.material;
        mirrorMateril.mainTexture = rt;
        mirrorCamera.targetTexture = rt;
    }
}
