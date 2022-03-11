using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ServiceDesk : MonoBehaviour
{
    public static ServiceDesk instance;

    [SerializeField]
    private List<Service> services = new List<Service>();

    void Start(){
        if(instance==null){
            instance = this;
            DontDestroyOnLoad(this);
        }else{
            foreach (Service item in services)
            {
                instance.SetItem(item.name,item.obj);
            }
            Destroy(this.gameObject);
        }
    }

    public GameObject GetItem(string key){
        return services.Find(x => x.name == key)?.obj;
    }

    public void SetItem(string key, GameObject obj){
        Service find = services.Find(x => x.name == key);
        if(find != null){
            find.obj = obj;
        }else{
            services.Add(new Service(key,obj));
        }
    }

}

[Serializable]
public class Service{
    public string name;
    public GameObject obj;

    public Service(string name,GameObject obj){
        this.name = name;
        this.obj = obj;
    }
}
