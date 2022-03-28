using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseInteractable : MonoBehaviour, iInteractable
{
    abstract public Vector3 scale {get; }
    abstract public Vector3 interactOffset { get; }
    abstract public Vector3 centerOffset { get; }
    abstract public bool interactable{get; set; }
    abstract public float range { get; }

    abstract public void Interact();
}
