using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Interactee : MonoBehaviour
{
    public KeyCode interactButton = KeyCode.E;

    BaseInteractable currentInteractable;

    bool last = false;
    void InteractPopup(bool boolean){
        if(last == boolean) return;
        var interactPopup = ServiceDesk.instance.GetItem("InteractPopup");
        interactPopup.SetActive(boolean);
        
        last = boolean;
    }

    void Update()
    {
        var interactables = FindObjectsOfType<BaseInteractable>();
        currentInteractable = null;
        foreach (var interactable in interactables)
        {
            if(interactable.enabled && Vector3.Distance(transform.position,interactable.transform.position+interactable.centerOffset) <= interactable.range){
                currentInteractable = interactable;
                break;
            }
        }
        InteractPopup(currentInteractable != null);
        if(currentInteractable != null && Input.GetKeyUp(interactButton)){
            currentInteractable.Interact();
        }
    }

    private void OnDisable(){
        InteractPopup(false);
    }
}
