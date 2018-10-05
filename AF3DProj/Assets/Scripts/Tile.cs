using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour {

    public string tileName;
    public List<Tile> NeighbourList;
    private int infastructureLevel;
    private City tileCity;
    public Vector2 tileCenter;

    

    public Color OnClickColour = new Color(153.0f, 204.0f, 255.0f);
    public Color OffClickColour = new Color(37.0f, 53.0f, 45.0f);
    
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
    
    public void OnMouseDown()
    {
        Debug.Log("Selected Tile was: " + gameObject.name);
        gameObject.GetComponent<Renderer>().material.color = OnClickColour;
        gameObject.layer = 8;
        //calls the parents 'updateselectedchildren' function and includes the sender as part of the message
        transform.parent.gameObject.SendMessage("UpdateSelectedChildren", gameObject);
       
    }

    
    public void OffClick()
    {
        gameObject.GetComponent<Renderer>().material.color = OffClickColour;
        gameObject.layer = 0;
        Debug.Log(gameObject.name + " was deselected.");
    }
    
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
