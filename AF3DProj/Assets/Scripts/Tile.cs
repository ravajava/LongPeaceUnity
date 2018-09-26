using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour {

    public string tileName;
    public List<Tile> NeighbourList;
    private int infastructureLevel;
    private City tileCity;
    public Vector2 tileCenter;
    
    public string TileName
    {
        get
        {
            return tileName;
        }

        set
        {
            tileName = value;
        }
    }

    public int InfastructureLevel
    {
        get
        {
            return infastructureLevel;
        }

        set
        {
            infastructureLevel = value;
        }
    }

    public City TileCity
    {
        get
        {
            return tileCity;
        }

        set
        {
            tileCity = value;
        }
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
