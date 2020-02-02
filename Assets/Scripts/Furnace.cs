using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Furnace : Machine {

    public Animator animator;

    private MachineTimerBar machineTimerBar;

    void Start() {
        timeToFix = 10.0f;
        machineTimerBar = this.gameObject.GetComponent<MachineTimerBar>();
    }

    void FixedUpdate() {
        brokeLoop();
    }

    public override void stop() {
        if(!this.isBroken){
            this.isBroken = true;
            this.timer = this.timeToFix;
            machineTimerBar.initBar(2.1f, 1.7f);
            animator.SetBool("FurnaceIsBroken", true);
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
                machineTimerBar.updateBar(timer, timeToFix);
            }
        }
    }

    public override void fix() {
        this.isBroken = false;
        machineTimerBar.closeBar();
        animator.SetBool("FurnaceIsBroken", false);
    }

    void OnTriggerEnter2D(Collider2D collision) {
        if (isBroken && collision.CompareTag("Player")) {
            transform.Find("furnaceTooltip").gameObject.SetActive(true);
        }
    }

    void OnTriggerExit2D(Collider2D collision) {
        if (collision.CompareTag("Player")) {
            transform.Find("furnaceTooltip").gameObject.SetActive(false);
        }
    }

}
