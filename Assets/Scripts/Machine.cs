using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Machine : MonoBehaviour {
    public GameObject loseMenu;
    public float timeToFix = 10.0f;
    public float timer;
    public bool isBroken = false;
    public abstract void stop();
    public abstract void fix();
    public abstract void brokeLoop();
}
