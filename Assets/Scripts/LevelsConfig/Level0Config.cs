using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level0Config : MonoBehaviour, LevelInterface {
    public string getLevelName() {
        return "world0";
    }

    public string getNextLevelName() {
        return "world1";
    }

    public Dictionary<int, GameObject> getIncidents() {
        return new Dictionary<int, GameObject>();
    }

    public int getLevelTime() {
        return 10;
    }
}
