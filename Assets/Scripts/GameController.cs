using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {
    public static int bestUnlockedStage = 1;

    public static int GetBestUnlockedStage() => bestUnlockedStage;
    public static void SetBestUnlockedStage(int stage) => bestUnlockedStage = stage;
    
    public static void GoToMainMenu() {
        SceneManager.LoadScene("mainMenu", LoadSceneMode.Single);
    }

    public static void GoToStage(int num) {
        if (num <= bestUnlockedStage) {
            SceneManager.LoadScene("stage" + num.ToString(), LoadSceneMode.Single);
        }
    }
}
