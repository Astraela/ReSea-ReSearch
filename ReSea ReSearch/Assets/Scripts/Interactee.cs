using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Interactee : MonoBehaviour
{
    public KeyCode interactButton = KeyCode.E;

    BaseInteractable currentInteractable;
    GameObject _interactPopup;
    GameObject interactPopup {get{
        if(_interactPopup == null)
            _interactPopup = ServiceDesk.instance.GetItem("InteractPopup");
        return _interactPopup;
    }}

    bool last = false;
    void InteractPopup(bool boolean){
        if(last == boolean) return;
        if(interactPopup != null)
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
        if(currentInteractable == null) return;

        NPC isNpc = currentInteractable as NPC;
        if(isNpc){
            if(isNpc.autoInteract){
                isNpc.autoInteract = false;
                StartCoroutine(AutoInteract(isNpc));
                return;
            }
        }
        if(interactPopup != null){
            interactPopup.transform.position = Camera.main.WorldToScreenPoint(currentInteractable.transform.position) + currentInteractable.interactOffset;
            interactPopup.transform.localScale = currentInteractable.scale;
        }
        if(Input.GetKeyUp(interactButton)){
            currentInteractable.Interact();
        }
    }

    IEnumerator AutoInteract(NPC npc){
        yield return new WaitForSeconds(.5f);
        npc.Interact();
    }

    private void OnDisable(){
        InteractPopup(false);
    }
}
