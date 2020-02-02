using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MachineTimerBar : MonoBehaviour {
    private GameObject progressBar;
    public GameObject progressBarPrefab;

    public void updateBar(float actual, float max) {
        //Debug.Log("Update bar - actual: " + actual.ToString() + " max: " + max.ToString());
    }

    public void initBar() {
        Debug.Log("Init bar");
        progressBar = Instantiate(progressBarPrefab, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
    }

    public void closeBar() {
        Debug.Log("Close bar");
        Destroy(progressBar);
    }
}
