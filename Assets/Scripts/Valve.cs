using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Valve : MonoBehaviour {
    public enum Direction { RIGHT, LEFT, ANY };

    public int maxPressure = 10;

    private bool highPressureValve = true;

    private int pressure = 10;

    private Direction nextDirection = Direction.ANY;

    public void Turn(Direction direction) {
        if (!this.highPressureValve || direction == Direction.ANY) {
            return;
        }

        if (this.nextDirection == Direction.ANY || this.nextDirection == direction) {
            Debug.Log("Turned valve");
            this.nextDirection = (direction == Direction.RIGHT)? Direction.LEFT : Direction.RIGHT;

            if (--this.pressure <= 0) {
                Debug.Log("Turn valve complete");
                this.highPressureValve = false;
            }
        }
    }

    private void Reset() {
        this.pressure = this.maxPressure;
        this.nextDirection = Direction.ANY;
    }

    public void SetHighPressure() {
        this.highPressureValve = true;
        this.Reset();
    }

    void OnTriggerExit2D(Collider2D collision) {
        if (this.highPressureValve && collision.CompareTag("Player")) {
            this.Reset();
            Debug.Log("Valve reset");
        }
    }
}