using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* 
 * Title: Brigade
 * Author: Kristian Mckesey & Josue Lopes
 * Date: October 3rd, 2018
 * Description: Brigades are, in a sense, a container of Battalions.
 */

//[System.Serializable]
public class Brigade
{
    private string m_BrigadeName;               
    private int m_FactionID;
    private int m_TileLocation;
    private List<Battalion> m_BrigadeBattalions;

    public Brigade(int id, string name, int tileLocation, List<Battalion> battalions)
    {
        m_FactionID = id;
        m_BrigadeName = name;
        m_TileLocation = tileLocation;

        m_BrigadeBattalions = new List<Battalion>();
        m_BrigadeBattalions = battalions;
    }
}
