using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map : MonoBehaviour {

    List<GameObject> ChildSendersList = new List<GameObject>();

	// Use this for initialization
	void Start () {
        foreach (Transform child in transform)
            child.SendMessage("OffClick");
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void UpdateSelectedChildren(GameObject SendingChild)
    {
        if(ChildSendersList.Count > 0)
        {
            for(int i = 0; i < ChildSendersList.Count; i++)
            {
               ChildSendersList[i].SendMessage("OffClick");
            }
            ChildSendersList.Clear();
        }
       
        ChildSendersList.Add(SendingChild);
    }
}
