using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public void OnQuit(){
        Application.Quit();
    }

    public void OnStart(){
        StartCoroutine(LoadSceneThingy());
    }

    IEnumerator LoadSceneThingy(){
        SceneManager.LoadScene("Scenes/LoadingScreen", LoadSceneMode.Additive);
        SceneManager.LoadScene("Scenes/IntroScene", LoadSceneMode.Additive);
        var newScene = SceneManager.GetSceneByName("Scenes/IntroScene");
        while (!newScene.isLoaded) {
            yield return new WaitForSeconds(0.1f);
        }
        SceneManager.SetActiveScene(SceneManager.GetSceneByName("Scenes/IntroScene"));
        SceneManager.UnloadSceneAsync(gameObject.scene);

    }
}
