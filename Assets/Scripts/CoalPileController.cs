using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoalPileController : MonoBehaviour {
    void OnTriggerEnter2D(Collider2D collision) {
        if (collision.CompareTag("Player")) {
            transform.Find("coalTooltip").gameObject.SetActive(true);
        }
    }

    void OnTriggerExit2D(Collider2D collision) {
        if (collision.CompareTag("Player")) {
            transform.Find("coalTooltip").gameObject.SetActive(false);
        }
    }

}
