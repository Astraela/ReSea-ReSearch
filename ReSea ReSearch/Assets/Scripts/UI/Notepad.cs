using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Notepad : MonoBehaviour
{
    [SerializeField]
    public List<NotepadString> notepads = new List<NotepadString>();

    void Start()
    {
        DialogueHelper helper = FindObjectOfType<DialogueHelper>();
        foreach(string name in helper._visitedNodes){
            if(notepads.Find(x => x.name == name) != null){
                notepads.Find(x => x.name == name).notepad.SetActive(true);
            }
        }
    }

    public void TryEnable(string name){
        if(notepads.Find(x => x.name == name) != null){
            notepads.Find(x => x.name == name).notepad.SetActive(true);
        }
    }
}

[System.Serializable]
public class NotepadString{
    public string name;
    public GameObject notepad;
}
