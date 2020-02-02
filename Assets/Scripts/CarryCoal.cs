using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarryCoal : MonoBehaviour {
    private bool canGetCoal = false;

    private bool carryingCoal = false;

    private Furnace nextFurnace = null;
    
    public Animator animator;

    void Update() {
        this.GetCoal();
        this.DropCoal();
    }

    public void OnTriggerEnter2D(Collider2D collision) {
        if (collision.CompareTag("CoalPile")) {
            this.canGetCoal = true;
        }
        else if (collision.CompareTag("Furnace")) {
            this.nextFurnace = collision.GetComponent<Furnace>();
        }
    }

    public void OnTriggerExit2D(Collider2D collision) {
        if (collision.CompareTag("CoalPile")) {
            this.canGetCoal = false;
        }
        else if (collision.CompareTag("Furnace")) {
            
            this.nextFurnace = null;
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
            animator.SetBool("isHoldingShovel", true);
        }
    }

    private void DropCoal() {
        if (this.carryingCoal && this.DropCoalAction()) {
            Debug.Log("Dropped coal");
            this.carryingCoal = false;
            animator.SetBool("isHoldingShovel", false);
            Debug.Log(animator.GetBool("isHoldingShovel"));
            if (this.nextFurnace != null) {
                Debug.Log("Coal was dropped in furnace");
                this.nextFurnace.fix();
            }
        }
    }
}
