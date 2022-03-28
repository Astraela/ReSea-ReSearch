using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DiversHelmet : BaseInteractable
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
        player.GetComponent<Interactee>().enabled = false;
        player.GetComponent<SidePlayerController>().enabled = false;
        StartCoroutine(LoadSceneThingy());
    }

    IEnumerator LoadSceneThingy(){
        SceneManager.LoadScene("Scenes/LoadingScreen", LoadSceneMode.Additive);
        SceneManager.LoadScene("Scenes/3DSections/1-1", LoadSceneMode.Additive);
        var scene = SceneManager.GetSceneByName("Scenes/3DSections/1-1");
        while (!scene.isLoaded) {
            yield return new WaitForSeconds(0.1f);
        }
        SceneManager.SetActiveScene(SceneManager.GetSceneByName("Scenes/3DSections/1-1"));
        SceneManager.UnloadSceneAsync(gameObject.scene);

    }
}
