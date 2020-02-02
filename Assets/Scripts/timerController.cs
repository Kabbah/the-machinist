using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class timerController : MonoBehaviour
{
	public float timer;
	public Text timerText;
    public GameObject victoryMenu;
    private Dictionary<int, GameObject> incidents;

    public LevelInterface levelConfig;

    void Start() {
        Time.timeScale = 1f;
        this.levelConfig = this.GetComponent<LevelInterface>();
        this.timer = levelConfig.getLevelTime();
        this.incidents = levelConfig.getIncidents();
    }

    void Update() {
        if(timer <= 0.0f){
            timer = 0.0f;
        	victoryMenu.SetActive(true);
        } else {
            timer -= Time.deltaTime;
            int second = Mathf.FloorToInt(timer);
            if(incidents.ContainsKey(second)) {
                Debug.Log(second);
                GameObject machine = incidents[second];
                machine.GetComponent<Machine>().stop();
                incidents.Remove(second);
            }
        }

        timerText.text = "Time: " + String.Format("{0:#,###.#}", timer);

    }
}
