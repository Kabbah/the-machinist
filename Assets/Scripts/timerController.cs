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

    void Update() {
        
        timerText.text = "Time: " + String.Format("{0:#,###.#}", timer);

        if(timer <= 0.0f){
        	victoryMenu.SetActive(true);
        } else {
            timer -= Time.deltaTime;
            
        }


    }
}
