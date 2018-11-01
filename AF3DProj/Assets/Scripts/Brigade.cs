using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* 
 * Title: Brigade
 * Author: Kristian Mckesey & Josue Lopes
 * Date: October 3rd, 2018
 * Description: Brigades are, in a sense, a container of Battalions.
 */

[System.Serializable]
public class Brigade : MonoBehaviour
{

    public int BrigadeName;
    public List<Battalion> BrigadeBattalions;
    public int FactionID;


    // Use this for initialization
    void Start()
    {

    }

    

}
