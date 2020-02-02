using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProgressController : MonoBehaviour {
    public float startPosition;

    public float endPosition;

    public void Start() {
        this.SetProgress(0);
    }

    public void SetProgress(float percentage) {
        float newPosition = this.startPosition + (this.endPosition - this.startPosition) * percentage;
        this.transform.position = new Vector3(newPosition,
            this.transform.position.y, this.transform.position.z);
    }
}
