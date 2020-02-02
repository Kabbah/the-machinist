using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Valve : Machine {
    public enum Direction { RIGHT, LEFT, ANY };

    public int maxPressure = 10;

    private int pressure = 10;

    public Sprite spriteValveOk;

    public Sprite spriteValveBroken;

    private Direction nextDirection = Direction.ANY;

    private MachineTimerBar machineTimerBar;
    
    void FixedUpdate() {
        brokeLoop();
    }

    void Start() {
        this.timeToFix = 15.0f;
        machineTimerBar = this.gameObject.GetComponent<MachineTimerBar>();
    }

    public void Turn(Direction direction) {
        if (!this.isBroken || direction == Direction.ANY) {
            return;
        }

        if (this.nextDirection == Direction.ANY || this.nextDirection == direction) {
            this.nextDirection = (direction == Direction.RIGHT)? Direction.LEFT : Direction.RIGHT;

            if (--this.pressure <= 0) {
                fix();
            }
        }
    }

    public void OnTriggerEnter2D(Collider2D collision) {
        if(isBroken && collision.gameObject.CompareTag("Player")) {
            transform.Find("valveTooltip").gameObject.SetActive(true);
        }
    }

    public override void fix() {
        this.isBroken = false;
        machineTimerBar.closeBar();
        GetComponent<SpriteRenderer>().sprite = spriteValveOk;
    }

    private void Reset() {
        this.pressure = this.maxPressure;
        this.nextDirection = Direction.ANY;
    }

    void OnTriggerExit2D(Collider2D collision) {
        if (collision.CompareTag("Player")) {
            transform.Find("valveTooltip").gameObject.SetActive(false);
            this.Reset();
        }
    }

    public override void stop() {
        if(!this.isBroken){
            this.isBroken = true;
            this.Reset();
            this.timer = this.timeToFix;
            machineTimerBar.initBar(2.1f, 1.7f);
            GetComponent<SpriteRenderer>().sprite = spriteValveBroken;
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
}