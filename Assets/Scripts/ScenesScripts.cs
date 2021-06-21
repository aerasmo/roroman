using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class ScenesScripts : MonoBehaviour
{   
    void Start() { Time.timeScale = 1; }
    // Start is called before the first frame update
    public void BackButton()
    {
        string scenename = "splashscreen";
        Debug.Log("sceneName to load: " + scenename);
        SceneManager.LoadScene(scenename);
    }
    public void Play()
    {
        string scenename = "boatscene";
        Debug.Log("sceneName to load: " + scenename);
        SceneManager.LoadScene(scenename);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
