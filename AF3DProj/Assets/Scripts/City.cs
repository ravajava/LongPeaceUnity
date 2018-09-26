using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class City : MonoBehaviour {

    private string cityName;
    public List<Building> CityBuildings;

    public string CityName
    {
        get
        {
            return cityName;
        }

        set
        {
            cityName = value;
        }
    }


    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
