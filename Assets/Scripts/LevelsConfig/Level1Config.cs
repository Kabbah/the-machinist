using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level1Config : MonoBehaviour, LevelInterface {
    public int getLevelNumber() {
        return 1;
    }

    public Dictionary<int, GameObject> getIncidents() {
        Dictionary<int, GameObject> incidents = new Dictionary<int, GameObject>();
        incidents.Add(95, GameObject.Find("pipe1"));
        incidents.Add(90, GameObject.Find("furnace1"));
        incidents.Add(85, GameObject.Find("valve1"));
        incidents.Add(80, GameObject.Find("furnace1"));
        return incidents;
    }

    public int getLevelTime() {
        return 100;
    }
}
