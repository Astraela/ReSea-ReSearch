using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnSceneLoad : MonoBehaviour
{
    
    void Start()
    {
        var player = ServiceDesk.instance.GetItem("Player");
        player.GetComponent<Interactee>().enabled = false;
        if(player.GetComponent<SidePlayerController>())
            player.GetComponent<SidePlayerController>().enabled = false;

        var LoadingScreen = ServiceDesk.instance.GetItem("LoadingScreen").GetComponent<LoadingScreen>();
        LoadingScreen.OnLoad += OnLoad;
        LoadingScreen.FinishedLoading();

    }

    void OnLoad(){
        var player = ServiceDesk.instance.GetItem("Player");
        player.GetComponent<Interactee>().enabled = true;
        if(player.GetComponent<SidePlayerController>())
            player.GetComponent<SidePlayerController>().enabled = true;
    }
}
