using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface LevelInterface {
	string getLevelName();
	string getNextLevelName();
	Dictionary<int, GameObject> getIncidents();
	int getLevelTime();

}
