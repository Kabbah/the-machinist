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

    public LevelIncidentsInterface levelConfig;

    void Start() {
        this.levelConfig = this.GetComponent<LevelIncidentsInterface>();
        this.timer = levelConfig.getLevelTime();
        this.incidents = levelConfig.getIncidents();
    }

    void Update() {

        if(timer <= 0.0f){
            timer = 0.0f;
        	victoryMenu.SetActive(true);
        } else {
            timer -= Time.deltaTime;
            
        }

        timerText.text = "Time: " + String.Format("{0:#,###.#}", timer);

    }
}
