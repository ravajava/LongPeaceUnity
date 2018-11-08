using System.Collections.Generic;
using UnityEngine;
using JsonHelpers;

/* 
 * Title: Tile Manager
 * Author: Josue Lopes
 * Date: September 26th, 2018
*/

public class TileManager : MonoBehaviour
{
    private TileGraph m_TileGraph;
    private List<Tile> m_Tiles;
    private List<TileDataWrapper> m_TileData;

	void Start()
    {
        m_TileData = new List<TileDataWrapper>();

        // get data from JSON file and input to graph to create it
        TextAsset jsonTextFile = Resources.Load<TextAsset>("jsonTileData");
        CreateTileDataFromJson(jsonTextFile.text);

        // create tile graph
        m_TileGraph = new TileGraph(m_TileData);

        // TODO: create tile game objects from data

        // TEST
       BattalionManager test = BattalionManager.Instance;
    }

    void CreateTileDataFromJson(string data)
    {
        m_TileData = JsonHelper.ParseJsonToTileData(data);
    }

    //TODO: create methods to access any tile data / functionality that is needed for game features
}
