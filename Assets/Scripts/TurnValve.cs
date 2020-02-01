using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnValve : MonoBehaviour {
    private static readonly string playerAction = "PlayerAction";

    private static readonly string playerSubAction = "PlayerSubAction";

    private Valve valve = null;

    void Update() {
        if (this.valve != null) {
            if (this.TryToTurnValveRight()) {
                this.valve.Turn(Valve.Direction.RIGHT);
            }
            else if (this.TryToTurnValveLeft()) {
                this.valve.Turn(Valve.Direction.LEFT);
            }
        }
    }

    public void OnTriggerStay2D(Collider2D collision) {
        if (this.valve == null && collision.CompareTag("Valve")) {
            Valve valve = collision.GetComponent<Valve>();
            if (valve != null) {
                this.valve = valve;
            }
        }
    }

    public void OnTriggerExit2D(Collider2D collision) {
        if (collision.CompareTag("Valve")) {
            this.valve = null;
        }
    }

    private bool TryToTurnValveRight() {
        return Input.GetButtonDown(playerAction);
    }

    private bool TryToTurnValveLeft() {
        return Input.GetButtonDown(playerSubAction);
    }
}
