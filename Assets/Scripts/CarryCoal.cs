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
        /*
        if (Input.GetButtonDown("PlayerAction")){
            animator.SetBool("isGettingCoal", true);
            return true;
        }
        return false;*/
        
        return Input.GetButtonDown("PlayerAction");
        
    }

    private bool DropCoalAction() {
        /*if (Input.GetButtonDown("PlayerAction")){
            animator.SetBool("isHoldingShovel", false);
            animator.SetBool("isPuttingCoal", true);
            return true;
        }
        return false;
        /**/
        animator.SetBool("isPuttingCoal", true);
        return Input.GetButtonUp("PlayerAction");
        
    }

    private void GetCoal() {

        animator.SetBool("isGettingCoal", true);
        if (this.canGetCoal && this.GetCoalAction()) {
            this.carryingCoal = true;
            SoundManagerScript.playSound("shovel coal pickup");
            animator.SetBool("isHoldingShovel", true);
        }
        animator.SetBool("isGettingCoal", false);
    }

    private void DropCoal() {

        if (this.carryingCoal && this.DropCoalAction()) {
            this.carryingCoal = false;
            animator.SetBool("isHoldingShovel", false);
            Debug.Log(animator.GetBool("isHoldingShovel"));
            SoundManagerScript.audioSrc.Stop();
            if (this.nextFurnace != null) {
                SoundManagerScript.playSound("droping coal");
                Debug.Log("Coal was dropped in furnace");
                this.nextFurnace.fix();
            }
        }
        animator.SetBool("isPuttingCoal", false);
    }
}
