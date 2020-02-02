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
                Debug.Log("Funcionou + " + this.timesToPress.ToString());
            
            }

            if (this.timesToPress == 0) {
                this.fix();
            }

            if(canFixPipe){
                if(Input.GetButtonDown(buttonPress)){
                    animator.SetBool("isHittingPipe", true);
                } /*else if (Input.GetButtonUp(buttonPress)){
                    animator.SetBool("isHittingPipe", false);
                }*/
            } 
        }
        if(!canFixPipe || (Mathf.Abs(Input.GetAxis("Horizontal")) > 0)){
            animator.SetBool("isHittingPipe", false);
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
        this.canFixPipe = false;
        Debug.Log("Reset times to press = " + timesToPress.ToString());
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
            Debug.Log("Stop pipe");
        }
    }

    public override void brokeLoop() {
        if (this.isBroken) {
            if (this.timer <= 0.0f) {
                timer = 0.0f;
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
