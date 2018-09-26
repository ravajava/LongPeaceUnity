using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameObjectClick : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnMouseDown()
    {
        Debug.Log("Selected Tile was: " + gameObject.name);
    }
}
