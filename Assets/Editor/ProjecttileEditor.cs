using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using  UnityEditor;

[CustomEditor(typeof(Projecttile))]
public class ProjecttileEditor : Editor
{
   public override void OnInspectorGUI()
   {
      //DrawDefaultInspector();
      //if (GUILayout.Button("Hello"))
     // {
        // Debug.Log("Hello");
      //}
      Projecttile projecttile = target as Projecttile;
      
   }
}