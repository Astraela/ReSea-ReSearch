using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class Functions : MonoBehaviour{

    [MenuItem("CONTEXT/RectTransform/Set Anchor to Bounds")]
    static void DoSomething()
    {
        var tr = Selection.activeTransform.GetComponent<RectTransform>();
        var width = tr.parent.GetComponent<RectTransform>().rect.width;
        var height = tr.parent.GetComponent<RectTransform>().rect.height;
        tr.anchorMin = new Vector2(tr.offsetMin.x/width,tr.offsetMin.y/height);
        tr.anchorMax = new Vector2(1- -tr.offsetMax.x/width,1- -tr.offsetMax.y/height);
        tr.offsetMin = new Vector2(0,0);
        tr.offsetMax = new Vector2(0,0);
    }
}
