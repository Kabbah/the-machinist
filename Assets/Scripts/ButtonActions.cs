using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonActions : MonoBehaviour {

    GameController gameController;

    void Start() {
         gameController = GameObject.Find("GameController").GetComponent<GameController>();
    }

    public void PlayButtonAction() {
        SceneManager.LoadScene("worldTestVitor", LoadSceneMode.Single);
    }

    public void GoToMainMenu() {
        SceneManager.LoadScene("mainMenu", LoadSceneMode.Single);
    }

    public void GoToWorldSelect() {
        SceneManager.LoadScene("worldSelectMenu", LoadSceneMode.Single);
    }

    public void ExitButtonAction() {
        Application.Quit();
    }

    public void GoToStage(int num) {
        if (num <= gameController.GetBestUnlockedStage()) {
            gameController.SetActualStage(num);
            SceneManager.LoadScene("world" + num.ToString(), LoadSceneMode.Single);
        }
    }

    public void RetryStage() {
        SceneManager.LoadScene("world" + gameController.GetActualStage().ToString(), LoadSceneMode.Single);
    }

    public void GoToNextStage() {
        gameController.SetActualStage(gameController.GetBestUnlockedStage());
        SceneManager.LoadScene("world" + gameController.GetActualStage().ToString(), LoadSceneMode.Single);
    }
}
