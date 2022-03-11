using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Computer : BaseInteractable
{
    private Vector3 _centerOffset = Vector3.zero;
    [SerializeField]
    private float _range = 3;
    private bool _interactable = true;

    public override Vector3 centerOffset => _centerOffset;
    public override float range => _range;
    public override bool interactable => _interactable;

    public override void Interact()
    {
        ServiceDesk.instance.GetItem("Map").SetActive(true);
    }
}