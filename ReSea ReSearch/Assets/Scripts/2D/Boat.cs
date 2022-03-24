using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Boat : MonoBehaviour
{
    public float boatMoveSpeed = 10f;

    public Transform BoatEntryPoint;
    public Transform BoatPosition;
    public Transform PlayerPosition;

    public void Start(){
        transform.position = BoatEntryPoint.position;
        Camera.main.GetComponent<CamScript>().enabled = false;
        var player = ServiceDesk.instance.GetItem("Player");
        player.transform.position = PlayerPosition.position;
        player.transform.SetParent(transform);
        if(player != null){
            player.GetComponent<Interactee>().enabled = false;
            if(player.GetComponent<SidePlayerController>())
                player.GetComponent<SidePlayerController>().enabled = false;
            if(player.GetComponent<TopPlayerController>())
                player.GetComponent<TopPlayerController>().enabled = false;
        }
        var blackout = ServiceDesk.instance.GetItem("Blackout").GetComponentInChildren<Image>();
            blackout.color = new Color(0,0,0,1);
        StartCoroutine(EnterAnim());
        StartCoroutine(FadeOut());
    }

    public void Exit(string scene){
        StartCoroutine(ExitAnim(scene));
    }


    public IEnumerator ExitAnim(string scene){
        Vector3 startPos = transform.position;
        float value = 0;
        bool FadeStarted = false;
        while(transform.position != BoatEntryPoint.position){
            transform.position = Vector3.Lerp(startPos,BoatEntryPoint.position,Mathf.Pow(value,2.3f));
            yield return new WaitForEndOfFrame();
            value += Time.deltaTime * boatMoveSpeed * .3f;
            if(!FadeStarted && value > .6f){
                FadeStarted = true;
                    StartCoroutine(FadeIn(scene));
            }
        }
        
    }

    IEnumerator FadeIn(string scene){
        var blackout = ServiceDesk.instance.GetItem("Blackout").GetComponentInChildren<Image>();
        float value = 0;
        while(blackout.color.a < 1){
            blackout.color = new Color(0,0,0,value);
            yield return new WaitForEndOfFrame();
            value += Time.deltaTime * boatMoveSpeed * .4f;
        }
        StartCoroutine(LoadSceneThingy(scene));
    }

    IEnumerator FadeOut(){
        var blackout = ServiceDesk.instance.GetItem("Blackout").GetComponentInChildren<Image>();
        float value = 1;
        while(blackout.color.a > 0){
            blackout.color = new Color(0,0,0,value);
            yield return new WaitForEndOfFrame();
            value -= Time.deltaTime * boatMoveSpeed * .8f;
        }
    }

    IEnumerator EnterAnim(){
        float value = 0f;
        var player = ServiceDesk.instance.GetItem("Player");
        bool enabled = false;
        while(transform.position != BoatPosition.position){
            transform.position = Vector3.Lerp(transform.position,BoatPosition.position,value);
            yield return new WaitForEndOfFrame();
            value += Time.deltaTime * boatMoveSpeed * .009f;
            if(!enabled && Vector2.Distance(transform.position, BoatPosition.position) < .5f){
                enabled = true;
                if(player != null){
                    player.GetComponent<Interactee>().enabled = true;
                    if(player.GetComponent<SidePlayerController>())
                        player.GetComponent<SidePlayerController>().enabled = true;
                    if(player.GetComponent<TopPlayerController>())
                        player.GetComponent<TopPlayerController>().enabled = false;
                }
                Camera.main.GetComponent<CamScript>().enabled = true;
            }
        }
    }
    
    IEnumerator LoadSceneThingy(string scene){
            yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(scene, LoadSceneMode.Single);

    }
}
