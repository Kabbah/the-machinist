using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    public float force = 1;

    public float maxSpeed = 5;

    public bool isOnLadder = false;

    private Rigidbody2D rb;

    void Start() {
        this.rb = this.gameObject.GetComponent<Rigidbody2D>();
    }

    void Update() {
    }

    public void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.CompareTag("Ladder")) {
            this.rb.gravityScale = 0.0f;
            this.isOnLadder = true;
        }
    }

    public void OnTriggerExit2D(Collider2D other) {
        if (other.gameObject.CompareTag("Ladder")) {
            this.rb.gravityScale = 1.0f;
            this.isOnLadder = false;
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
