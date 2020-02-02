using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level2Config : MonoBehaviour, LevelInterface {
    public int getLevelNumber() {
        return 2;
    }

    public Dictionary<int, GameObject> getIncidents() {
        Dictionary<int, GameObject> incidents = new Dictionary<int, GameObject>();
        incidents.Add(35, GameObject.Find("pipe1"));
        incidents.Add(30, GameObject.Find("furnace1"));
        incidents.Add(25, GameObject.Find("valve1"));
        incidents.Add(20, GameObject.Find("pipe2"));
        incidents.Add(15, GameObject.Find("furnace1"));
        return incidents;
    }

    public int getLevelTime() {
        return 40;
    }
}
