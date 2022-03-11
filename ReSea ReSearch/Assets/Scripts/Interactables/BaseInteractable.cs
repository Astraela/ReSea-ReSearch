using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseInteractable : MonoBehaviour, iInteractable
{
    abstract public Vector3 centerOffset { get; }
    abstract public bool interactable{get;}
    abstract public float range { get;}

    abstract public void Interact();
}
