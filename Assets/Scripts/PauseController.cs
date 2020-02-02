using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseController : MonoBehaviour {

    public static bool isPaused = false;
    public GameObject pauseMenu;

    void Update() {
        if(Input.GetKeyDown(KeyCode.Escape)) {
            togglePauseMenu();
        }
    }

    public void returnToMenuButtonAction() {
        SceneManager.LoadScene("mainMenu", LoadSceneMode.Single);
    }

    public void togglePauseMenu() {
        isPaused = !isPaused;
        pauseMenu.SetActive(isPaused);

        if(isPaused){
            Time.timeScale = 0f;
        } else {
            Time.timeScale = 1f;
        }
    }

    public void nextLevelButtonAction() {
        SceneManager.LoadScene("worldTestVitor", LoadSceneMode.Single);
    }
}
