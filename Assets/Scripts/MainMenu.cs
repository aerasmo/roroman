using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // void Awake () {
    public bool initsound = false;
    // }
    void Start() { 
        Time.timeScale = 1; 
        if (initsound == true) {
            // SoundManagerScript.PlaySound("title screen");
            StartCoroutine(music());
        }
    }
    IEnumerator music() {
        yield return new WaitForSeconds(0.05f);
        SoundManagerScript.PlaySound("title screen");
    }
    // Start is called before the first frame update
    public void NewGame() {
        string scenename = "scene1";
        Debug.Log("sceneName to load: " + scenename);
        SceneManager.LoadScene(scenename);
    }
    public void QuitGame() {
        Debug.Log("Quit");
        Application.Quit();
    }
    public void Shop() {
        string scenename = "Shop0";
        Debug.Log("sceneName to load: " + scenename);
        SceneManager.LoadScene(scenename);
    }
    public void Continue() {
        string scenename = "menu";
        Debug.Log("sceneName to load: " + scenename);
        SceneManager.LoadScene(scenename);
    }
    public void navigateTo(string scene) {
        string scenename = scene;
        Debug.Log("sceneName to load: " + scenename);
        SceneManager.LoadScene(scenename);  
    }
    public void Restart() {
        SceneManager.LoadScene("boatscene");
    }
}
