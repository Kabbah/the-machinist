using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeScrew : MonoBehaviour
{
    
    private bool isPipeBroken = true;
    private string buttonPress = "PlayerAction";
    private int timesToPress = 10;

    void OnTriggerStay2D(Collider2D collider2D){
        if(isPipeBroken){
            if (Input.GetButtonDown("PlayerAction")){
                timesToPress--;
                Debug.Log("Funcionou + " + timesToPress.ToString());
            }
            
            if (timesToPress == 0)
                isPipeBroken = false;
        }
    }

    void OnTriggerExit2D(Collider2D collider2D){
        if (isPipeBroken){
            timesToPress = 10;
            
        }
        Debug.Log("Reset times to press = " + timesToPress.ToString());
    }
}
