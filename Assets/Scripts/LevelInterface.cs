using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface LevelInterface {
	int getLevelNumber();
	Dictionary<int, GameObject> getIncidents();
	int getLevelTime();
}
