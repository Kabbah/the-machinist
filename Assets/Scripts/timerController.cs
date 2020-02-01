using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class timerController : MonoBehaviour
{
	public float timer;
	public Text timerText;
    public GameObject victoryMenu;
    // Start is called before the first frame update
    void Start()
    {
     
    }

    // Update is called once per frame
    void Update()
    {
        timer = timer - Time.deltaTime;
        timerText.text = "Time: " + timer.ToString();

        if(timer <= 0.0f){
        	victoryMenu.SetActive(true);
        }


    }
}
