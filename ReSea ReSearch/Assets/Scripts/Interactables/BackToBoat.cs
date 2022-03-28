using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BackToBoat : BaseInteractable
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
        var player = ServiceDesk.instance.GetItem("Player");
        if(player != null){
            player.GetComponent<Interactee>().enabled = false;
            if(player.GetComponent<SidePlayerController>())
                player.GetComponent<SidePlayerController>().enabled = false;
            if(player.GetComponent<TopPlayerController>())
                player.GetComponent<TopPlayerController>().enabled = false;
        }
        StartCoroutine(LoadSceneThingy());
    }

    IEnumerator LoadSceneThingy(){
        SceneManager.LoadScene("Scenes/LoadingScreen", LoadSceneMode.Additive);
        var scene = SceneManager.GetSceneByName("Scenes/LoadingScreen");
        while (!scene.isLoaded) {
            yield return new WaitForSeconds(0.1f);
        }
        var LoadingScreen = ServiceDesk.instance.GetItem("LoadingScreen").GetComponent<LoadingScreen>();
        LoadingScreen.OnLoad += OnLoad;
        LoadingScreen.FinishedLoading();
    }

    void OnLoad(){
        SceneManager.LoadScene("Scenes/BoatScene", LoadSceneMode.Single);
    }
}
