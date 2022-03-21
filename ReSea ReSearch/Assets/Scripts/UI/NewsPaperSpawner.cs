using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewsPaperSpawner : MonoBehaviour
{
    public Transform center;
    [SerializeField]
    public List<NewsPaper> newsPapers = new List<NewsPaper>();

    private List<string> newsPaperNames;
    private int index = 0;

    void Start(){
        StartNews(new List<string>(){"a","b","c","d","b","c","d","b","c","d"});
    }

    public void StartNews(List<string> newsNames){
        newsPaperNames = newsNames;
        //Next();
    }

    public void Next(){
        if(index >= newsPaperNames.Count) return;
        var newNewsPaper = Instantiate(newsPapers.Find(x => x.name == newsPaperNames[index]).newspaper).transform;

        newNewsPaper.position = center.position + new Vector3(Random.Range(-10,10),Random.Range(-10,10),0);
        newNewsPaper.rotation = Quaternion.Euler(0,0,Random.Range(-15,15));
        newNewsPaper.localScale = Vector3.one*5;
        newNewsPaper.SetParent(transform);
        StartCoroutine(SpawnNewspaper(newNewsPaper));
        //index++;
    }

    IEnumerator SpawnNewspaper(Transform obj){
        float t = 0;
        while(true){
                obj.localScale = Vector3.Lerp(obj.localScale,Vector3.one,t);
            t += Time.deltaTime;
            if((obj.localScale - Vector3.one).magnitude < .01f){
                obj.localScale = Vector3.one;
                break;
            }
            yield return new WaitForEndOfFrame();
        }
    }

}

[System.Serializable]
public class NewsPaper{
    public string name;
    public GameObject newspaper;

    NewsPaper(string name, GameObject newspaper){
        this.name = name;
        this.newspaper = newspaper;
    }
}
