using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Faction : MonoBehaviour {

    public string factionName;
    public List<Character> FactionCharacterList;
    public List<Tile> FactionTiles;
    public float Stability;
    public float Fatigue;
    public int BattalionCap;
     
    // Use this for initialization
    void Start () {
		
	}
	
}
