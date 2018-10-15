using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* 
 * Title: Tile Graph
 * Author: Kristian Mckesey & Josue Lopes
 * Date: October 3rd, 2018
 * Description: UI bar management
*/

public class UIBar : MonoBehaviour {

    private Canvas UI;
    private GameObject background;
    private GameObject menus;

    private enum Buttons{Map, Battles, Diplomacy, Factions, Overview}
    Buttons selectedButton;

    // Use this for initialization
    // Gets what's needed for the rest of the scripts functions. 
    void Start () {

        
        UI = GameObject.Find("UI").GetComponent<Canvas>();
        background = GameObject.Find("Background");
        background.SetActive(false);
        menus = UI.transform.Find("Menus").gameObject;
        selectedButton = Buttons.Map;
    }
	
	// Update is called once per frame
    // Probabaly want to throw some things for effects here...
	void Update () {
		
	}
    public delegate void MapButtonEvent();

    public event MapButtonEvent OnMapButtonClick;

    //Basically checks if map is visble to be clicked on, if it isn't it will make that happen. Pretty much how all of these work.
    public void MapButtonClick ()
    {
        if(selectedButton != Buttons.Map)
        {
            background.SetActive(false);
            menus.SetActive(false);
            selectedButton = Buttons.Map;
        }
        
    }

    public void BattlesButtonClick ()
    {
        if(selectedButton != Buttons.Battles)
        {
            if(menus.activeSelf == false)
            {
                menus.SetActive(true);
            }
            if(background.activeSelf == false)
            {
                background.SetActive(true);
            }
            menus.transform.Find("BattlesMenu").gameObject.SetActive(true);
            selectedButton = Buttons.Battles;
        }
    }

}
