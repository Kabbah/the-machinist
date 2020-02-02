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
    
    void FixedUpdate() {
        brokeLoop();
    }

    void Start() {
        this.timeToFix = 5.0f;
    }

    public void Turn(Direction direction) {
        if (!this.isBroken || direction == Direction.ANY) {
            return;
        }

        if (this.nextDirection == Direction.ANY || this.nextDirection == direction) {
            Debug.Log("Turned valve");
            this.nextDirection = (direction == Direction.RIGHT)? Direction.LEFT : Direction.RIGHT;

            if (--this.pressure <= 0) {
                fix();
            }
        }
    }

    public override void fix() {
        Debug.Log("Turn valve complete");
        this.isBroken = false;
        GetComponent<SpriteRenderer>().sprite = spriteValveOk;
    }

    private void Reset() {
        this.pressure = this.maxPressure;
        this.nextDirection = Direction.ANY;
    }

    void OnTriggerExit2D(Collider2D collision) {
        if (this.isBroken && collision.CompareTag("Player")) {
            this.Reset();
            Debug.Log("Valve reset");
        }
    }

    public override void stop() {
        if(!this.isBroken){
            this.isBroken = true;
            this.Reset();
            this.timer = this.timeToFix;
            GetComponent<SpriteRenderer>().sprite = spriteValveBroken;
            Debug.Log("Stop valve");
        }
    }

    public override void brokeLoop() {
        if(this.isBroken) {
            if(this.timer <= 0.0f){
                timer = 0.0f;
                Time.timeScale = 0f;
                loseMenu.SetActive(true);
            } else {
                timer -= Time.deltaTime;
            }
        }
    }
}