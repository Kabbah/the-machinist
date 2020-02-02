using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level4Config : MonoBehaviour, LevelInterface {

    public int getLevelNumber() {
        return 4;
    }
    public Dictionary<int, GameObject> getIncidents() {
        Dictionary<int, GameObject> incidents = new Dictionary<int, GameObject>();
        incidents.Add(28, GameObject.Find("valve1"));
        incidents.Add(22, GameObject.Find("furnace1"));
        incidents.Add(15, GameObject.Find("valve1"));
        return incidents;
    }

    public int getLevelTime() {
        return 30;
    }
}
