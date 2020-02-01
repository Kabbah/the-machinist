using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonActions : MonoBehaviour {
    public void PlayButtonAction() {
        SceneManager.LoadScene("worldTestVitor", LoadSceneMode.Single);
    }

    public void ExitButtonAction() {
        Application.Quit();
    }
}
