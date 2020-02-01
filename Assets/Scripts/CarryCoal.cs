using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarryCoal : MonoBehaviour {
    private bool canGetCoal = false;

    private bool carryingCoal = false;

    private bool canDropCoalInFurnace = false;
    
    void Update() {
        this.GetCoal();
        this.DropCoal();
    }

    public void OnTriggerEnter2D(Collider2D collision) {
        if (collision.CompareTag("CoalPile")) {
            this.canGetCoal = true;
        }
        else if (collision.CompareTag("Furnace")) {
            this.canDropCoalInFurnace = true;
        }
    }

    public void OnTriggerExit2D(Collider2D collision) {
        if (collision.CompareTag("CoalPile")) {
            this.canGetCoal = false;
        }
        else if (collision.CompareTag("Furnace")) {
            this.canDropCoalInFurnace = false;
        }
    }

    private bool GetCoalAction() {
        return Input.GetButtonDown("PlayerAction");
    }

    private bool DropCoalAction() {
        return Input.GetButtonUp("PlayerAction");
    }

    private void GetCoal() {
        if (this.canGetCoal && this.GetCoalAction()) {
            Debug.Log("Got coal");
            this.carryingCoal = true;
        }
    }

    private void DropCoal() {
        if (this.carryingCoal && this.DropCoalAction()) {
            Debug.Log("Dropped coal");
            this.carryingCoal = false;
            if (this.canDropCoalInFurnace) {
                Debug.Log("Coal was dropped in furnace");
                // TODO
            }
        }
    }
}
