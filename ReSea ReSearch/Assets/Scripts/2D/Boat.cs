using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Boat : MonoBehaviour
{
    public float boatMoveSpeed = 10f;

    public Transform BoatEntryPoint;
    public Transform BoatPosition;
    public Transform PlayerPosition;

    public void Exit(){
        var player = ServiceDesk.instance.GetItem("Player");
        player.transform.position = PlayerPosition.position;
        player.transform.SetParent(transform);
        player.GetComponent<Interactee>().enabled = false;
        player.GetComponent<SidePlayerController>().enabled = false;
        Camera.main.GetComponent<CamScript>().enabled = false;
        StartCoroutine(ExitAnim());
    }

    public void Enter(){
        var player = ServiceDesk.instance.GetItem("Player");
        player.transform.position = PlayerPosition.position;
        player.transform.SetParent(transform);
    }

    IEnumerator ExitAnim(){
        Vector3 startPos = transform.position;
        float value = 0;
        bool FadeStarted = false;
        while(transform.position != BoatEntryPoint.position){
            transform.position = Vector3.Lerp(startPos,BoatEntryPoint.position,Mathf.Pow(value,2.3f));
            yield return new WaitForEndOfFrame();
            value += Time.deltaTime * boatMoveSpeed * .3f;
            if(!FadeStarted && value > .6f){
                FadeStarted = true;
                    StartCoroutine(Fade());
            }
        }
        
    }

    IEnumerator Fade(){
        var blackout = ServiceDesk.instance.GetItem("Blackout").GetComponentInChildren<Image>();
        float value = 0;
        while(blackout.color.a < 1){
            blackout.color = new Color(0,0,0,value);
            yield return new WaitForEndOfFrame();
            value += Time.deltaTime * boatMoveSpeed * .8f;
        }
        value = 0;
        bool enterStarted = false;
        while(blackout.color.a != 0){
            blackout.color = new Color(0,0,0,1-value);
            yield return new WaitForEndOfFrame();
            value += Time.deltaTime * boatMoveSpeed * .6f;
            if(!enterStarted && value > .05f){
                StartCoroutine(EnterAnim());
            }
        }
    }

    IEnumerator EnterAnim(){
        float value = 0f;
        var player = ServiceDesk.instance.GetItem("Player");
        bool enabled = false;
        while(transform.position != BoatPosition.position){
            transform.position = Vector3.Lerp(transform.position,BoatPosition.position,value);
            yield return new WaitForEndOfFrame();
            value += Time.deltaTime * boatMoveSpeed * .00003f;
            if(!enabled && Vector2.Distance(transform.position, BoatPosition.position) < .5f){
                enabled = true;
                player.GetComponent<Interactee>().enabled = true;
                player.GetComponent<SidePlayerController>().enabled = true;
                Camera.main.GetComponent<CamScript>().enabled = true;
            }
        }
        
    }
}
