using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class WorldSelectController : MonoBehaviour {

    public Dropdown dropdown;
    GameController gameController;

    void Start() {
        gameController = GameObject.Find("GameController").GetComponent<GameController>();
        initDropDown();
    }

    private void initDropDown() {
        dropdown.ClearOptions();
        List<Dropdown.OptionData> options = new List<Dropdown.OptionData>();
        for (int i=1; i<=gameController.GetBestUnlockedStage(); i++) {
            options.Add(new Dropdown.OptionData("Mundo " + i.ToString()));
        }
        dropdown.AddOptions(options);
        dropdown.value = options.Count;
    }

    public void GoToStage() {
        gameController.SetActualStage((dropdown.value + 1));
        SceneManager.LoadScene("world" + gameController.GetActualStage().ToString(), LoadSceneMode.Single);
    }
}
