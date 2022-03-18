using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Yarn.Unity;

public class NPC : BaseInteractable
{
    public bool show = true;
    public string characterName = "";

    public string talkToNode = "";

    public YarnProgram scriptToLoad;
    
    public bool autoInteract = false;
    public float interactRange = 2f;

    private Vector3 _centerOffset = Vector3.zero;
    [SerializeField]
    private float _range = 3;
    [SerializeField]
    private bool _interactable = true;

    public override Vector3 centerOffset => _centerOffset;
    public override float range => _range;
    public override bool interactable {get => _interactable; set => _interactable = value;}

    public override void Interact()
    {
        var dialogueRunner = FindObjectOfType<DialogueRunner>();
            
        if(FindObjectOfType<DialogueRunner>().NodeExists(talkToNode)){
            dialogueRunner.StartDialogue (talkToNode);
        }else{
            Debug.LogWarning("node does not exist | "+ talkToNode);
        }
    }

    public virtual void UpdateVisiblity(bool newShow){
        if(show == newShow) return;
        
        foreach(Image image in GetComponentsInChildren<Image>()){
            image.enabled = newShow;
        }

        show = newShow;
    }

    IEnumerator Start () { 
        DialogueHelper dialogueHelper = FindObjectOfType<DialogueHelper>();
        if(dialogueHelper.Npcs.ContainsKey(characterName)){
            show = dialogueHelper.Npcs[characterName].show;
            dialogueHelper.Npcs[characterName] = this;
        }else{
                dialogueHelper.Npcs.Add(characterName,this);
        }
        UpdateVisiblity(show);
        if (scriptToLoad != null) {
            DialogueRunner dialogueRunner = FindObjectOfType<Yarn.Unity.DialogueRunner>();
                    dialogueRunner.Add(scriptToLoad);  
        }
        yield return new WaitForEndOfFrame();
    }
}
