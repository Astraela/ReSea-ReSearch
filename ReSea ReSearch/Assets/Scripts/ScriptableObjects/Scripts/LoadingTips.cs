using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/SpawnManagerScriptableObject", order = 1)]
public class LoadingTips : ScriptableObject
{
    [SerializeField]
    public List<string> loadingTips = new List<string>();
}
