using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LoadingScreen : MonoBehaviour
{
    public LoadingTips loadingTips;
    public TextMeshProUGUI LoadingTipText; 
    private  string loadingTip = "Did you know according to the super mario bros. instruction book, when the koopas first invaded the mushroom kingdom they turned its people into blocks.:";

    private float startTime;
    private float minLength = 2f;

    private bool finishedLoading = false;

    public delegate void evento();
    public evento OnLoad;

    private void Start(){
        startTime = Time.time;
        UpdateTip(loadingTips.loadingTips[Random.Range(0,loadingTips.loadingTips.Count)]);
    }

    private void UpdateTip(string text){
        LoadingTipText.text = text;
        minLength = minLength + text.Length/50;
    }

    public void FinishedLoading() => finishedLoading = true;

    private void Update(){
        if(finishedLoading && Time.time - startTime >= minLength){
            OnLoad.Invoke();
            UnityEngine.SceneManagement.SceneManager.UnloadSceneAsync(gameObject.scene);
        }
    }

}
