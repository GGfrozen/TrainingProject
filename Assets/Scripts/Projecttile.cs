using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Rigidbody))]
public class Projecttile : MonoBehaviour
{
    
    
    
        [HideInInspector] public Rigidbody rb;
        public float damageraidus = 1f;

        private void Reset()
        {
            rb = GetComponent<Rigidbody>();
        }
    
}
