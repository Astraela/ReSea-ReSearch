using UnityEngine;

public abstract class Activator : MonoBehaviour{
    public string identifier = "UniqueIdentifier";
    public virtual void Start(){
        DialogueHelper dialogueHelper = FindObjectOfType<DialogueHelper>();
        dialogueHelper.Activators.Add(identifier,this);
    }

    public abstract void Activate(Yarn.Value value);
}