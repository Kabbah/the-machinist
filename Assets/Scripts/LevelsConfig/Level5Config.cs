using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level5Config : MonoBehaviour, LevelInterface {
    public int getLevelNumber() {
        return 5;
    }

    public Dictionary<int, GameObject> getIncidents() {
        Dictionary<int, GameObject> incidents = new Dictionary<int, GameObject>();
        incidents.Add(35, GameObject.Find("pipe1"));
        incidents.Add(30, GameObject.Find("furnace1"));
        incidents.Add(20, GameObject.Find("valve1"));
        incidents.Add(15, GameObject.Find("pipe2"));
        incidents.Add(10, GameObject.Find("furnace1"));
        return incidents;
    }

    public int getLevelTime() {
        return 40;
    }
}
