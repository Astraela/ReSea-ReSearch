using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Computer : BaseInteractable
{
    [SerializeField]
    private Vector3 _scale = Vector3.one;
    [SerializeField]
    private Vector3 _interactOffset = Vector3.zero;
    private Vector3 _centerOffset = Vector3.zero;
    [SerializeField]
    private float _range = 3;
    private bool _interactable = true;

    public override Vector3 scale => _scale;
    public override Vector3 interactOffset => _interactOffset;
    public override Vector3 centerOffset => _centerOffset;
    public override float range => _range;

    public override bool interactable {get => _interactable; set => _interactable = value;}

    public override void Interact()
    {
        ServiceDesk.instance.GetItem("Map").SetActive(true);
    }
}
