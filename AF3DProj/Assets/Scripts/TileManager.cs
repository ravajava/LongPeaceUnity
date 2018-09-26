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
    private List<TileDataWrapper> m_TileData;

	void Start()
    {
        m_TileGraph = new TileGraph();
        m_TileData = new List<TileDataWrapper>();

        // get data from JSON file and input to graph to create it
        TextAsset jsonTextFile = Resources.Load<TextAsset>("jsonTileData");
        CreateTileDataFromJson(jsonTextFile.text);

        // TODO: create tile graph from data
        // TODO: create tile game objects from data
	}

    void CreateTileDataFromJson(string data)
    {
        m_TileData = JsonHelper.ParseJsonToTileData(data);
    }
}
