using UnityEngine;

public class ActivatorExample : Activator{
    public override void Activate(Yarn.Value value){
        transform.localScale *= value.AsNumber;
    }
}