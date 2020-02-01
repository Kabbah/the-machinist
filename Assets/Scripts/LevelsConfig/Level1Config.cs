using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level1Config : MonoBehaviour, LevelIncidentsInterface {
    public Dictionary<int, GameObject> getIncidents() {
        Dictionary<int, GameObject> incidents = new Dictionary<int, GameObject>();
        incidents.Add(2, GameObject.Find("Furnace1"));
        incidents.Add(5, GameObject.Find("Furnace2"));
        incidents.Add(8, GameObject.Find("Furnace1"));
        return incidents;
    }

    public int getLevelTime() {
        return 20;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
