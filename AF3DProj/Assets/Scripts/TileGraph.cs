using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* 
 * Title: Tile Graph
 * Author: Kristian Mckesey & Josue Lopes
 * Date: September 25th, 2018
*/

public class TileGraph
{
    private class TileNode
    {
        public List<int> adjagentNodes;     // graph indices of adjacent nodes
        public int dataIndex;               // index for game data container

        TileNode()
        {
            adjagentNodes = new List<int>();
        }
    }

    private List<TileNode> m_TileNodes;

    //Creates graph structure using information from source 
    void CreateGraph()
    {
        
    }

    //Adds an edge between two vertices
    void AddEdge(int tileAIndex, int tileBIndex)
    {
        m_TileNodes[tileAIndex].adjagentNodes.Add(tileBIndex);
        m_TileNodes[tileBIndex].adjagentNodes.Add(tileAIndex);

        // sort adjacent nodes so we can use binary search
        if (m_TileNodes[tileAIndex].adjagentNodes.Count > 0)
            m_TileNodes[tileAIndex].adjagentNodes.Sort();

        if (m_TileNodes[tileBIndex].adjagentNodes.Count > 0)
            m_TileNodes[tileBIndex].adjagentNodes.Sort();
    }

    // Removes an edge between two vertices
    void RemoveEdge(int tileAIndex, int tileBIndex)
    {
        // search if edge exists
        int edgeIndexA =  m_TileNodes[tileAIndex].adjagentNodes.BinarySearch(tileBIndex);
        int edgeIndexB = m_TileNodes[tileBIndex].adjagentNodes.BinarySearch(tileAIndex);

        // if it does, remove edge and resort
        if (edgeIndexA >= 0 && edgeIndexB >= 0)
        {
            m_TileNodes[tileAIndex].adjagentNodes.RemoveAt(edgeIndexA);
            m_TileNodes[tileBIndex].adjagentNodes.RemoveAt(edgeIndexB);

            // sort adjacent nodes so we can use binary search
            if (m_TileNodes[tileAIndex].adjagentNodes.Count > 0)
                m_TileNodes[tileAIndex].adjagentNodes.Sort();

            if (m_TileNodes[tileBIndex].adjagentNodes.Count > 0)
                m_TileNodes[tileBIndex].adjagentNodes.Sort();
        }
    }

    //Determines/tests wherever an edge exists between two vertices
    bool Adjacent(int tileAIndex, int tileBIndex)
    {
        int edgeIndex = m_TileNodes[tileAIndex].adjagentNodes.BinarySearch(tileBIndex);

        if (edgeIndex >= 0)
            return true;
        else
            return false;
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
