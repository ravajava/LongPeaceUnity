using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameObjectClick : MonoBehaviour {

    public Color OnClickColour = new Color(153.0f, 204.0f, 255.0f);
    public Color OffClickColour = new Color(37.0f, 53.0f, 45.0f);

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnMouseDown()
    {
        Debug.Log("Selected Tile was: " + gameObject.name);
        gameObject.GetComponent<Renderer>().material.color = OnClickColour;
    }
}
