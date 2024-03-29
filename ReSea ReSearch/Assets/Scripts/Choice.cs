using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn;

public class Choice : MonoBehaviour
{
    public string choice;

    public static Choice Instance;

    void Awake(){
        if(Instance == null){
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else{
            Destroy(gameObject);
        }
    }
}

