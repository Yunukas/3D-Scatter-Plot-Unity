using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Loader : MonoBehaviour
{
    public string nextScene;
    // List for holding data from CSV reader
    private List<Dictionary<string, object>> pointList;
    // the data to be loaded
    TextAsset data;
    string text;
    public string inputCSV;
    // Start is called before the first frame update
    void Start()
    {
        data = Resources.Load(inputCSV) as TextAsset;
        text = data.text;
        StartCoroutine("LoadCSV", nextScene);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator LoadCSV(string scene)
    {
        yield return new WaitForThreadedTask(() => {
            pointList = CSVReader.Read(text);
        });
        DataStore.setPointList(pointList);

        // add a slight delay
        yield return new WaitForSeconds(1.5f);
        // load the next scene
        SceneManager.LoadScene(scene);
    }
}
