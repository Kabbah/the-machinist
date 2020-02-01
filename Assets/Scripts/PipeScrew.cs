using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeScrew : MonoBehaviour
{
    
    private bool isPipeBroken = true;
    private static readonly string buttonPress = "PlayerAction";
    private int timesToPress = 10;

    private bool canFixPipe = false;

    private void Update() {
        if (this.isPipeBroken && this.canFixPipe) {
            if (Input.GetButtonDown(buttonPress)) {
                this.timesToPress--;
                Debug.Log("Funcionou + " + this.timesToPress.ToString());
            }

            if (this.timesToPress == 0) {
                this.isPipeBroken = false;
            }
        }
    }

    void OnTriggerStay2D(Collider2D collision) {
        if (!this.canFixPipe && collision.CompareTag("Player")) {
            this.canFixPipe = true;
        }
    }

    void OnTriggerExit2D(Collider2D collision) {
        if (isPipeBroken && collision.CompareTag("Player")) {
            timesToPress = 10;
        }
        this.canFixPipe = false;
        Debug.Log("Reset times to press = " + timesToPress.ToString());
    }
}
