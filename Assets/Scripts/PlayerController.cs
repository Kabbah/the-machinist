﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    public float force = 1;

    public float maxSpeed = 5;

    private Rigidbody2D rb;

    void Start() {
        this.rb = this.gameObject.GetComponent<Rigidbody2D>();
    }

    void Update() {
        
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
    }
}
