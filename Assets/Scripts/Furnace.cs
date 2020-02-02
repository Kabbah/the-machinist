using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Furnace : Machine {

    //public Sprite spriteFurnaceOk;

    //public Sprite spriteFurnaceBroken;

    public Animator animator;

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
            animator.SetBool("FurnaceIsBroken", true);
            //GetComponent<SpriteRenderer>().sprite = spriteFurnaceBroken;
        }
    }

    public override void brokeLoop() {
        if(this.isBroken) {
            if(this.timer <= 0.0f){
                timer = 0.0f;
                Time.timeScale = 0f;
                PauseController.isEndGame = true;
                loseMenu.SetActive(true);
            } else {
                timer -= Time.deltaTime;
            }
        }
    }

    public override void fix() {
        this.isBroken = false;
        animator.SetBool("FurnaceIsBroken", false);
        //GetComponent<SpriteRenderer>().sprite = spriteFurnaceOk;
    }
}
