using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level3Config : MonoBehaviour, LevelInterface {

    public int getLevelNumber() {
        return 3;
    }
    public Dictionary<int, GameObject> getIncidents() {
        Dictionary<int, GameObject> incidents = new Dictionary<int, GameObject>();
        incidents.Add(24, GameObject.Find("furnace1"));
        incidents.Add(17, GameObject.Find("furnace2"));
        incidents.Add(10, GameObject.Find("furnace3"));
        return incidents;
    }

    public int getLevelTime() {
        return 25;
    }
}
