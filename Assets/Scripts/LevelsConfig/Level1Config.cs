using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level1Config : MonoBehaviour, LevelInterface {
    public string getLevelName() {
        return "world1";
    }

    public string getNextLevelName() {
        return "world2";
    }

    public Dictionary<int, GameObject> getIncidents() {
        Dictionary<int, GameObject> incidents = new Dictionary<int, GameObject>();
        incidents.Add(95, GameObject.Find("valve1"));
        incidents.Add(85, GameObject.Find("valve1"));
        incidents.Add(75, GameObject.Find("valve1"));
        return incidents;
    }

    public int getLevelTime() {
        return 100;
    }
}
