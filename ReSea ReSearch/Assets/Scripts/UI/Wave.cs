using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wave : MonoBehaviour
{
    public float sizeIncrease = 10;

    private RectTransform rt;
    // Start is called before the first frame update
    void Start()
    {
        rt = GetComponent<RectTransform>();
    }

    private string requirement = "sonic";
    private string progress = "";

    private bool activated = false;

    // Update is called once per frame
    void Update()
    {

        if(!activated && Input.anyKeyDown){
            if(Input.GetKeyDown(requirement[progress.Length].ToString())){
                progress += requirement[progress.Length];
                if(progress == requirement) activated = true;
            }else{
                progress = string.Empty;
            }
        }
        if(activated){
            rt.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, rt.rect.width + sizeIncrease*2000*Time.deltaTime);
            return;
        }

        rt.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, rt.rect.width + sizeIncrease*20*Time.deltaTime);
    }
}
