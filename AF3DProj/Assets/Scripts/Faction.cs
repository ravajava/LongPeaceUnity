using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Faction : MonoBehaviour {

    private string factionName;
    public List<Character> FactionCharacterList;
    public List<Tile> FactionTiles;
    public float Stability;
    public float Fatigue;
    public int BattalionCap;

    public string FactionName
    {
        get
        {
            return factionName;
        }

        set
        {
            factionName = value;
        }
    }


    // Use this for initialization
    void Start () {
		
	}
	
}
