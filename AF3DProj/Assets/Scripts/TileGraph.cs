using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* 
 * Title: Tile Graph
 * Author: Kristian Mckesey & Josue Lopes
 * Date: September 25th, 2018
*/

public class TileGraph : MonoBehaviour {


    private Vector2 TileVertices;

	// Use this for initialization
	void Start () {
		
	}

    //Creates graph structure using information from source 
    void CreateGraph()
    {

    }

    //Adds an edge between two vertices
    void AddEdge(float x, float y, int edge)
    {

    }

    // Removes an edge between two vertices
    void RemoveEdge(float x, float y)
    {

    }

    //Determines/tests wherever an edge exists between two vertices
    void Adjacent(float x, float y)
    {

    }

    //Lists all nodes y adjacent to a given node x if they exist
    void Neighbour(float x)
    {

    }

    // Returns the value with a specified node
    void GetNodeValue(float y)
    {

    }

    //Set value or data of a specified node
    void SetNodeValue(int data, float x, float y)
    {

    }

    //Not sure we need this but I'll keep it her in case we want it to have some debug function. It's meant to display the graph as a matrix
    void Display()
    {

    }
}
