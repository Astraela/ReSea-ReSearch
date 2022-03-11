using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SharkRotator : MonoBehaviour
{
    public float speed = 1;
    
    void Update()
    {
        transform.Rotate(Vector3.back);
    }
}
