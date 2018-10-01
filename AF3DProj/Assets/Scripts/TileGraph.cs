using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using JsonHelpers;

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

        public TileNode()
        {
            adjacentNodes = new List<int>();
        }
    }

    private List<TileNode> m_TileNodes;

    public TileGraph(List<TileDataWrapper> data)
    {
        // create list equal to # of tiles
        m_TileNodes = new List<TileNode>(data.Count);
        
        // store all adjacent nodes into graph
        foreach (TileDataWrapper tile in data)
        {
            TileNode node = new TileNode();
            node.adjacentNodes = tile.edges;

            m_TileNodes[tile.ID] = node;

        }
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
    bool AreNodesAdjacent(int nodeAIndex, int nodeBIndex)
    {
        int edgeIndex = m_TileNodes[nodeAIndex].adjacentNodes.BinarySearch(nodeBIndex);

        if (edgeIndex >= 0)
            return true;
        else
            return false;
    }

    //Lists all nodes y adjacent to a given node x if they exist
    List<int> GetNodeNeighbours(int nodeIndex)
    {
        if (nodeIndex < 0 || nodeIndex >= m_TileNodes.Count)
            throw new System.IndexOutOfRangeException();

        return m_TileNodes[nodeIndex].adjacentNodes;
    }

    //Not sure we need this but I'll keep it her in case we want it to have some debug function. It's meant to display the graph as a matrix
    void Display()
    {

    }
}
