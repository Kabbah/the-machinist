using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Furnace : Machine {

    void Start() {
        timeToFix = 20.0f;
    }

    void FixedUpdate() {
        brokeLoop();
    }
    
    public override void stop() {
        if(!this.isBroken){
            this.isBroken = true;
            this.timer = this.timeToFix;
            Debug.Log("Stop furnace");
        }
    }

    public override void brokeLoop() {
        if(this.isBroken) {
            if(this.timer <= 0.0f){
                timer = 0.0f;
                Time.timeScale = 1f;
                loseMenu.SetActive(true);
            } else {
                timer -= Time.deltaTime;
            }
        }
    }

    public override void fix() {
        Debug.Log("Furnace complete");
        this.isBroken = false;
        GetComponent<Animator>().Play("Fogo_forte");
    }
}
