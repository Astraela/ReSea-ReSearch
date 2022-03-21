using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Map : MonoBehaviour
{
    public void MapSelect(string id){
        ServiceDesk.instance.GetItem("Boat").GetComponent<Boat>().Exit();
        gameObject.SetActive(false);
    }

    public void SceneLoad(string scene){
        var player = ServiceDesk.instance.GetItem("Player");
        if(player != null){
            if(player.GetComponent<SidePlayerController>())
                player.GetComponent<SidePlayerController>().enabled = false;
            if(player.GetComponent<TopPlayerController>())
                player.GetComponent<TopPlayerController>().enabled = false;
        }
        StartCoroutine(LoadSceneThingy(scene));
    }

    IEnumerator LoadSceneThingy(string scene){
        SceneManager.LoadScene("Scenes/LoadingScreen", LoadSceneMode.Additive);
        SceneManager.LoadScene(scene, LoadSceneMode.Additive);
        var newScene = SceneManager.GetSceneByName(scene);
        while (!newScene.isLoaded) {
            yield return new WaitForSeconds(0.1f);
        }
        SceneManager.SetActiveScene(SceneManager.GetSceneByName(scene));
        SceneManager.UnloadSceneAsync(gameObject.scene);

    }
}
