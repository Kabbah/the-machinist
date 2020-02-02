using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeScrew : Machine {
    private static readonly string buttonPress = "PlayerAction";
    private int timesToPress = 10;
    public int maxTimesToPress = 10;

    private bool canFixPipe = false;

    public Sprite spritePipeOk;

    public Animator animator;

    public Sprite spritePipeBroken;

    void FixedUpdate() {
        brokeLoop();
    }

    void Start() {
        this.timeToFix = 10.0f;
    }

    private void Update() {
        if (this.isBroken && this.canFixPipe) {
            if (Input.GetButtonDown(buttonPress)) {
                this.timesToPress--;
            }

            if (this.timesToPress == 0) {
                this.fix();
            }

            if(canFixPipe){
                if(Input.GetButtonDown(buttonPress)){
                    SoundManagerScript.playSound("hammer pipe");
                    animator.SetBool("isHittingPipe", true);
                }
            } 
        }
    }

    void OnTriggerStay2D(Collider2D collision) {
        if (!this.canFixPipe && collision.CompareTag("Player")) {
            this.canFixPipe = true;
        }
    }

    void OnTriggerExit2D(Collider2D collision) {
        if (isBroken && collision.CompareTag("Player")) {
            this.Reset();
        }
        animator.SetBool("isHittingPipe", false);
        this.canFixPipe = false;
    }

    private void Reset() {
        this.timesToPress = this.maxTimesToPress;
    }

    public override void stop() {
        if (!this.isBroken) {
            this.isBroken = true;
            this.Reset();
            this.timer = this.timeToFix;
            
            GetComponent<SpriteRenderer>().sprite = spritePipeBroken;
        }
    }

    public override void brokeLoop() {
        if (this.isBroken) {
            if (this.timer <= 0.0f) {
                timer = 0.0f;
                Time.timeScale = 0f;
                PauseController.isEndGame = true;
                loseMenu.SetActive(true);
            }
            else {
                timer -= Time.deltaTime;
            }
        }
    }

    public override void fix() {
        this.isBroken = false;
        GetComponent<SpriteRenderer>().sprite = spritePipeOk;
    }
}
