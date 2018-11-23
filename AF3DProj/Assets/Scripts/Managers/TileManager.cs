using System.Collections.Generic;
using UnityEngine;
using JsonHelpers;

/* 
 * Title: Tile Manager
 * Author: Josue Lopes
 * Date: September 26th, 2018
*/

public class TileManager
{
    // singleton
    private static TileManager m_Instance = null;

    private TileGraph m_TileGraph;
    private List<Tile> m_Tiles;
    private List<TileDataWrapper> m_TileData;

	private TileManager()
    {
        m_TileData = new List<TileDataWrapper>();

        // get data from JSON file and input to graph to create it
        TextAsset jsonTextFile = Resources.Load<TextAsset>("jsonTileData");
        CreateTileDataFromJson(jsonTextFile.text);

        // create tile graph
        m_TileGraph = new TileGraph(m_TileData);

        // create tile game objects from data
        //m_Tiles = new List<Tile>();
        
        //foreach (TileDataWrapper d in m_TileData)
        //{
        //    Tile tile = new Tile();
        //}
    }

    public static TileManager Instance
    {
        get
        {
            if (m_Instance == null)
                m_Instance = new TileManager();

            return m_Instance;
        }
    }

    private void CreateTileDataFromJson(string data)
    {
        m_TileData = JsonHelper.ParseJsonToTileData(data);
    }

    //TODO: create methods to access any tile data / functionality that is needed for game features
}
