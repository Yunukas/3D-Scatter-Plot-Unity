using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Threading;
public class Loader : MonoBehaviour
{
    // the progress spinner component
	public RectTransform rectComponent;
    // next scene
	public string nextScene;
    // List for holding data from CSV reader
    private List<Dictionary<string, object>> pointList;
    // the data to be loaded
    TextAsset data;
   
    // name of csv file
    public string inputCSV;
    // Start is called before the first frame update
    IEnumerator Start()
    {
        // get the raw data
        data = Resources.Load(inputCSV) as TextAsset;
        // start the coroutine to read csv data
        yield return StartCoroutine("LoadCSV", data.text);
        // load the next scene
        SceneManager.LoadScene(nextScene);
    }
    // coroutine to show spinner animation and read the csv
    IEnumerator LoadCSV(string text)
    {
        // play the animation
        Animator anim = rectComponent.GetComponent<Animator>();
        anim.Play("SpinnerAnim", 0);

        // get the raw data in a new thread
        yield return new WaitForThreadedTask(() =>
        {
            pointList = CSVReader.Read(text);
        });

        // thread is done, assign the data to the DataStore
        DataStore.setPointList(pointList);

        // add a slight delay before transitioning
        yield return new WaitForSeconds(1.5f);

        //stop the animation
        anim.StopPlayback();
    }
}
