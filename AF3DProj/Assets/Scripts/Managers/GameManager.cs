using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
	void Start ()
    {
        // initialize managers
        TileManager tileManager = TileManager.Instance;
        UnitManager unitManager = UnitManager.Instance;
	}
}
