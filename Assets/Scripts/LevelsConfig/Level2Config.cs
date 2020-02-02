using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level2Config : MonoBehaviour, LevelInterface {

    public int getLevelNumber() {
        return 2;
    }
    public Dictionary<int, GameObject> getIncidents() {
        Dictionary<int, GameObject> incidents = new Dictionary<int, GameObject>();
        incidents.Add(50, GameObject.Find("furnace1"));
        incidents.Add(30, GameObject.Find("pipe1"));
        incidents.Add(10, GameObject.Find("furnace1"));
        return incidents;

    }

    public int getLevelTime() {
        return 60;
    }
}
