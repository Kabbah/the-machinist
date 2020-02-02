using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {
    private static GameController instance;

    public int bestUnlockedStage = 1;
    public int actualStage = 1;

    public int GetBestUnlockedStage() => bestUnlockedStage;

    public int GetActualStage() => actualStage;
    public void SetBestUnlockedStage(int stage) => bestUnlockedStage = stage;


     private void Awake() {
        if (instance != null && instance != this) {
            Destroy(this.gameObject);
            return;
        }

        instance = this;
        DontDestroyOnLoad( this.gameObject );
    }

    public int UpdateBestUnlockStage() {

        List<string> scenesInBuild = new List<string>();
        for (int i = 1; i < SceneManager.sceneCountInBuildSettings; i++) {
            string scenePath = SceneUtility.GetScenePathByBuildIndex(i);
            int lastSlash = scenePath.LastIndexOf("/");
            scenesInBuild.Add(scenePath.Substring(lastSlash + 1, scenePath.LastIndexOf(".") - lastSlash - 1));
        }

        if(scenesInBuild.Contains("world" + (this.bestUnlockedStage + 1))) {
            this.bestUnlockedStage += 1;
        }
        return this.bestUnlockedStage;
    }

    public void SetActualStage(int stage) {
        this.actualStage = stage;
    }

}
