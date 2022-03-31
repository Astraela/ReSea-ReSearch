using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class NotepadCard : MonoBehaviour, IPointerClickHandler
{
    public float collapsed = 6.69f;
    public float opened = 0.966497f;

    AspectRatioFitter ratio;
    bool debounce = false;
    public void OnPointerClick(PointerEventData eventData)
    {
        if(debounce) return;
        debounce = true;
        StartCoroutine(LerpTo(ratio.aspectRatio == opened ? collapsed : opened));
    }

    // Start is called before the first frame update
    void Start()
    {
        ratio = GetComponent<AspectRatioFitter>();
    }


    IEnumerator LerpTo(float ratioFloat){
        float difference = Mathf.Abs(ratio.aspectRatio - ratioFloat);
        float progress = 0;
        while(difference > .001f){
            progress += Time.deltaTime*.75f;
            ratio.aspectRatio = Mathf.Lerp(ratio.aspectRatio,ratioFloat,progress);
            difference = Mathf.Abs(ratio.aspectRatio - ratioFloat);
            yield return new WaitForEndOfFrame();
        }
        ratio.aspectRatio = ratioFloat;
        debounce = false;
    }
}
