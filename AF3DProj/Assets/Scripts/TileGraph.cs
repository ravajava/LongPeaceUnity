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

        public List<int> adjacentNodes;     // graph indices of adjacent nodes
        public int dataIndex;               // index for game data container


        TileNode()
        {
            adjacentNodes = new List<int>();
        }
    }

    private List<TileNode> m_TileNodes;

    //Creates graph structure using information from source 
    void CreateGraph()
    {
        
    }

    //Adds an edge between two vertices
    void AddEdge(int nodeAIndex, int nodeBIndex)
    {
        m_TileNodes[nodeAIndex].adjacentNodes.Add(nodeBIndex);
        m_TileNodes[nodeBIndex].adjacentNodes.Add(nodeAIndex);

        // sort adjacent nodes so we can use binary search
        if (m_TileNodes[nodeAIndex].adjacentNodes.Count > 0)
            m_TileNodes[nodeAIndex].adjacentNodes.Sort();

        if (m_TileNodes[nodeBIndex].adjacentNodes.Count > 0)
            m_TileNodes[nodeBIndex].adjacentNodes.Sort();
    }

    // Removes an edge between two vertices
    void RemoveEdge(int nodeAIndex, int nodeBIndex)
    {
        // search if edge exists
        int edgeIndexA =  m_TileNodes[nodeAIndex].adjacentNodes.BinarySearch(nodeBIndex);
        int edgeIndexB = m_TileNodes[nodeBIndex].adjacentNodes.BinarySearch(nodeAIndex);

        // if it does, remove edge and resort
        if (edgeIndexA >= 0 && edgeIndexB >= 0)
        {
            m_TileNodes[nodeAIndex].adjacentNodes.RemoveAt(edgeIndexA);
            m_TileNodes[nodeBIndex].adjacentNodes.RemoveAt(edgeIndexB);

            // sort adjacent nodes so we can use binary search
            if (m_TileNodes[nodeAIndex].adjacentNodes.Count > 0)
                m_TileNodes[nodeAIndex].adjacentNodes.Sort();

            if (m_TileNodes[nodeBIndex].adjacentNodes.Count > 0)
                m_TileNodes[nodeBIndex].adjacentNodes.Sort();
        }
    }

    //Determines/tests wherever an edge exists between two vertices
    bool Adjacent(int nodeAIndex, int nodeBIndex)
    {
        int edgeIndex = m_TileNodes[nodeAIndex].adjacentNodes.BinarySearch(nodeBIndex);

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
    int GetNodeValue(int nodeIndex)
    {
        if (nodeIndex < 0 || nodeIndex >= m_TileNodes.Count)
            throw new System.IndexOutOfRangeException();

        return m_TileNodes[nodeIndex].dataIndex;
    }

    //Set value or data of a specified node
    void SetNodeValue(int nodeIndex, int value)
    {
        if (nodeIndex < 0 || nodeIndex >= m_TileNodes.Count || value < 0)
            throw new System.IndexOutOfRangeException();

        m_TileNodes[nodeIndex].dataIndex = value;
    }

    //Not sure we need this but I'll keep it her in case we want it to have some debug function. It's meant to display the graph as a matrix
    void Display()
    {

    }
}
