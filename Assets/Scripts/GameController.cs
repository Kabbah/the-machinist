using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {
    private static GameController instance;

    public int bestUnlockedStage = 1;

    public int GetBestUnlockedStage() => bestUnlockedStage;
    public void SetBestUnlockedStage(int stage) => bestUnlockedStage = stage;


     private void Awake() {
        if (instance != null && instance != this) {
            Destroy(this.gameObject);
            return;
        }

        instance = this;
        DontDestroyOnLoad( this.gameObject );
    }
    
    public void GoToMainMenu() {
        SceneManager.LoadScene("mainMenu", LoadSceneMode.Single);
    }

    public void GoToStage(int num) {
        if (num <= bestUnlockedStage) {
            SceneManager.LoadScene("world" + num.ToString(), LoadSceneMode.Single);
        }
    }

    public void GoToNextStage() {
        SceneManager.LoadScene("world" + bestUnlockedStage.ToString(), LoadSceneMode.Single);
    }
}
