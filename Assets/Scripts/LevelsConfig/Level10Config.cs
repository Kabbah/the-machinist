using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level10Config : MonoBehaviour, LevelInterface {
    public int getLevelNumber() {
        return 10;
    }

    public Dictionary<int, GameObject> getIncidents() {
        Dictionary<int, GameObject> incidents = new Dictionary<int, GameObject>();
        incidents.Add(19, GameObject.Find("valve1"));
        incidents.Add(10, GameObject.Find("pipe2"));
        return incidents;
    }

    public int getLevelTime() {
        return 20;
    }
}
