using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MachineTimerBar : MonoBehaviour {
    private GameObject progressBar;
    public GameObject progressBarPrefab;

    public void updateBar(float actual, float max) {
        Transform frontbar = progressBar.transform.Find("machineFrontbar");
        float perc = actual / max;
        frontbar.localScale = new Vector3(0.8f*perc, 0.1f, 1.0f);
    }

    public void initBar(float offsetX, float offsetY) {
        progressBar = Instantiate(progressBarPrefab, new Vector3(transform.position.x+offsetX, transform.position.y+offsetY, transform.position.z), Quaternion.identity);
    }

    public void closeBar() {
        Destroy(progressBar);
    }
}
