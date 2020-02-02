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

    public void UpdateBestUnlockStage() {
        this.bestUnlockedStage += 1;
    }

    public void SetActualStage(int stage) {
        this.actualStage = stage;
    }

}
