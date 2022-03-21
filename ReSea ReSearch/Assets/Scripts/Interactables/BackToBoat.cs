using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BackToBoat : BaseInteractable
{
    private Vector3 _centerOffset = Vector3.zero;
    [SerializeField]
    private float _range = 3;
    private bool _interactable = true;

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
        SceneManager.LoadScene("Scenes/BoatScene", LoadSceneMode.Additive);
        var scene = SceneManager.GetSceneByName("Scenes/BoatScene");
        while (!scene.isLoaded) {
            yield return new WaitForSeconds(0.1f);
        }
        SceneManager.SetActiveScene(SceneManager.GetSceneByName("Scenes/BoatScene"));
        SceneManager.UnloadSceneAsync(gameObject.scene);

    }
}
