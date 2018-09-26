using System.Collections.Generic;
using UnityEngine;

/* 
 * Title: Json Helper
 * Author: Josue Lopes
 * Date: September 26th, 2018
*/

namespace JsonHelpers
{
    public class JsonHelper
    {
        public static List<TileDataWrapper> ParseJsonToTileData(string json)
        {
            ListWrapper tileWrapper = JsonUtility.FromJson<ListWrapper>(json);
            return tileWrapper.tiles;
        }
    }

    [System.Serializable]
    public class ListWrapper
    {
        public List<TileDataWrapper> tiles;
    }

    [System.Serializable]
    public class TileDataWrapper
    {
        public int ID;
        public string name;
        public List<int> edges;
    }
}