using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface LevelIncidentsInterface {
	Dictionary<int, GameObject> getIncidents();
	int getLevelTime();

}
