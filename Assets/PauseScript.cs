using System.Collections;
using System.Collections.Generic;
using UnityEngine; 

public class PauseScript : MonoBehaviour
{
    public static bool GameIsPaused = false;

    public GameObject pauseMenuUI;

    void Update() {
        if(Input.GetKeyDown(KeyCode.Escape)){
            Pause();
        }
    }
    
    public void Pause(){
        if (GameIsPaused) {
            pauseMenuUI.SetActive(true);
            Time.timeScale = 0;
            GameIsPaused = false;
        } else {
            pauseMenuUI.SetActive(false);
            Time.timeScale = 1;
            GameIsPaused = true;
        }
    }

}
