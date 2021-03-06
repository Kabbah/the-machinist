﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    public float force = 1;

    public float maxSpeed = 5;

    public bool isOnLadder = false;
    public bool isMovingH = false;
    public bool isMovingV = false;

    private Rigidbody2D rb;
    
    public float runSpeed = 30.0f;

    public float horizontalMove = 0.0f;
    public float verticalMove = 0.0f;
    public Animator animator;

    public float direction;
    public float someScale;
    public float _posX;

    void Start() {

        direction = 1;
        _posX = transform.position.x;

        this.rb = this.gameObject.GetComponent<Rigidbody2D>();
        
        someScale = transform.localScale.x; // assuming this is facing right
        transform.localScale = new Vector2(-someScale, transform.localScale.y);
    }

    void Update() {
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;
        verticalMove = Input.GetAxisRaw("Vertical") * runSpeed;

        animator.SetFloat("Speed", Mathf.Abs(horizontalMove));

        if(!SoundManagerScript.audioSrc.isPlaying){
            if(Mathf.Abs(horizontalMove) > 0){
                isMovingH = true;
            } else {
                isMovingH = false;
            }


            if(isMovingH){
                SoundManagerScript.playSound("running boat");
            } else if (!isMovingH){
                SoundManagerScript.audioSrc.Stop();
            }
        }

        if(!SoundManagerScript.audioSrc.isPlaying){
            if(Mathf.Abs(verticalMove) > 0){
                isMovingV = true;
            } else {
                isMovingV = false;
            }

            if(isMovingV){
                SoundManagerScript.playSound("subir escada1");
            } else if (!isMovingV){
                SoundManagerScript.audioSrc.Stop();
            }
        }

        if (transform.position.x < _posX) {
             if (direction == 1) {
                transform.localScale = new Vector2(someScale, transform.localScale.y);
                 direction = -1;
             }
         }
         else if (transform.position.x > _posX) {
            if (direction == -1) {
                transform.localScale = new Vector2(-someScale, transform.localScale.y);
                 direction = 1;
             }
         }
 
         _posX = transform.position.x;

    }

    public void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.CompareTag("Ladder")) {
            this.rb.gravityScale = 0.0f;
            this.isOnLadder = true;
            animator.SetBool("isOnLadder", true);
        }
    }

    public void OnTriggerExit2D(Collider2D other) {
        if (other.gameObject.CompareTag("Ladder")) {
            this.rb.gravityScale = 1.0f;
            this.isOnLadder = false;
            animator.SetBool("isOnLadder", false);
        }
    }

    public void FixedUpdate() {
        this.move();
    }
    
    private void move() {       
        float horizontalMovement = Input.GetAxis("Horizontal");
        if (this.rb.velocity.magnitude < this.maxSpeed) {
            Vector2 movement = new Vector2(horizontalMovement, 0);
            this.rb.AddForce(this.force * movement);
        }

        float verticalMovement = Input.GetAxis("Vertical");
        if (this.isOnLadder && this.rb.velocity.magnitude < this.maxSpeed) {
            Vector2 movement = new Vector2(0, verticalMovement);
            this.rb.AddForce(this.force * movement);
        }

    }
}
