using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Valve : MonoBehaviour
{

    private bool highPressureValve = true;
    private string lastButton = "x";
    private int pressure = 10;

    void OnTriggerStay2D(Collider2D collider2D){
        if(highPressureValve){
            if (Input.GetKeyDown("z") && !Input.GetKeyDown(lastButton)){
                pressure--;
                lastButton = "z";
                Debug.Log("Funcionou + " + pressure.ToString());
            }
            if (Input.GetKeyDown("x") && !Input.GetKeyDown(lastButton)){
                pressure--;
                lastButton = "x";
                Debug.Log("Funcionou + " + pressure.ToString());
            }
            if (pressure == 0)
                highPressureValve = false;
        }
    }

    void OnTriggerExit2D(Collider2D collider2D){
        if (highPressureValve){
            pressure = 10;
            lastButton = "x";
        }
        Debug.Log("Reset pressure = " + pressure.ToString());
    }
}