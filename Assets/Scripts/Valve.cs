using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Valve : MonoBehaviour
{

    private bool highPressureValve = true;
    private string lastButton = "PlayerAction";
    private int pressure = 10;

    void OnTriggerStay2D(Collider2D collider2D){
        if(highPressureValve){
            if (Input.GetButtonDown("PlayerAction") && !Input.GetKeyDown(lastButton)){
                pressure--;
                lastButton = "PlayerSubAction";
                Debug.Log("Funcionou + " + pressure.ToString());
            }
            if (Input.GetKeyDown("PlayerSubAction") && !Input.GetKeyDown(lastButton)){
                pressure--;
                lastButton = "PlayerSubAction";
                Debug.Log("Funcionou + " + pressure.ToString());
            }
            if (pressure == 0)
                highPressureValve = false;
        }
    }

    void OnTriggerExit2D(Collider2D collider2D){
        if (highPressureValve){
            pressure = 10;
            lastButton = "PlayerSubAction";
        }
        Debug.Log("Reset pressure = " + pressure.ToString());
    }
}