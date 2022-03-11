using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface iInteractable
{
    public Vector3 centerOffset{get;}
    public bool interactable{get;}
    public float range{get;}
    public void Interact();
}
