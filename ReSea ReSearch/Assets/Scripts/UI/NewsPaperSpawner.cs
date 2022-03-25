using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NewsPaperSpawner : MonoBehaviour
{
    public Transform center;

    public List<List<GameObject>> newspapers;
    [SerializeField]
    public List<NewsPapers> newsPapers = new List<NewsPapers>();
    string solution;


    private int index = 0;

    void Start(){
        solution = Choice.Instance.choice;
    }

    public void StartNews(List<string> newsNames){
        //Next();
    }

    public void Next(){
        if(index >= newsPapers.Find(x => x.name == solution).newspaper.Count){
            SceneManager.LoadScene("StartMenu");
            return;
        }
        var newNewsPaper = Instantiate(newsPapers.Find(x => x.name == solution).newspaper[index]).transform;

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
public class NewsPapers{
    public string name;
    public List<GameObject> newspaper = new List<GameObject>();
}
