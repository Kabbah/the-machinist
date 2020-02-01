﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseController : MonoBehaviour {

    public GameObject pauseMenu;
    public bool isPaused = false;

    void Update() {
        if(Input.GetKeyDown(KeyCode.Escape)) {
            togglePauseMenu();
        }
    }

    public void ReturnToMenuButtonAction() {
        SceneManager.LoadScene("mainMenu", LoadSceneMode.Single);
    }

    public void togglePauseMenu() {
        isPaused = !isPaused;
        pauseMenu.SetActive(isPaused);
    }
}