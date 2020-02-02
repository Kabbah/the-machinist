using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tooltip : MonoBehaviour {
    private GameObject tooltip;
    public GameObject tooltipPrefab;

    public void Show(float offsetX, float offsetY) {
        Vector3 position = this.transform.position + new Vector3(offsetX, offsetY);
        this.tooltip = Instantiate(this.tooltipPrefab, position, Quaternion.identity);
    }

    public void Hide() {
        Destroy(this.tooltip);
    }
}
