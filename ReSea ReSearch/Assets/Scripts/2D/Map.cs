using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map : MonoBehaviour
{
    public void MapSelect(string id){
        ServiceDesk.instance.GetItem("Boat").GetComponent<Boat>().Exit();
        gameObject.SetActive(false);
    }
}
