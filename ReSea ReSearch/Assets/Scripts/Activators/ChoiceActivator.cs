using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Yarn;

public class ChoiceActivator : Activator
{
    public override void Activate(Value value)
    {
        print("Activated");
        GetComponent<Choice>().choice = value.AsString;
        StartCoroutine(SceneTransition());
    }

    IEnumerator SceneTransition(){
        yield return new WaitForSeconds(.5f);
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
        SceneManager.LoadScene("Scenes/ResultsScene", LoadSceneMode.Additive);
        var scene = SceneManager.GetSceneByName("Scenes/ResultsScene");
        while (!scene.isLoaded) {
            yield return new WaitForSeconds(0.1f);
        }
        SceneManager.SetActiveScene(SceneManager.GetSceneByName("Scenes/ResultsScene"));
        SceneManager.UnloadSceneAsync(gameObject.scene);
    }
}
