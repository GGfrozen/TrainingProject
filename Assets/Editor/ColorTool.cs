using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class ColorTool : EditorWindow
{
   [MenuItem("Tool/ColorTool")]

   public static void ChangeColor()
   {
       EditorWindow.GetWindow<ColorTool>();
   }
   [MenuItem("Tool/ColorTool",true)]

   public static bool ChangeColorValidation()
   {
       return FindObjectsOfType<MeshRenderer>() != null;
   }
       

   private void OnGUI()
   {
       if (!GUILayout.Button("ChangeColor")) return;
       var allMesh = FindObjectsOfType<MeshRenderer>();
       foreach (var mesh in allMesh)
       {
           mesh.sharedMaterial.color = Color.yellow;
       }
   }
}
