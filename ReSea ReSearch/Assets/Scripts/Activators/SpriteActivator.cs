using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpriteActivator : Activator{
    
    public List<SpriteKey> sprites =  new List<SpriteKey>();

    public override void Activate(Yarn.Value value){
        GetComponent<Image>().sprite = sprites.Find(x => x.key == value.AsString).img;
    }
}

[Serializable]
public class SpriteKey{
    public string key;
    public Sprite img;
}