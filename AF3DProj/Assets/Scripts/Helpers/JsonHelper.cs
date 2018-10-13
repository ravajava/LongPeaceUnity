﻿using System.Collections.Generic;
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
            TileListWrapper tileWrapper = JsonUtility.FromJson<TileListWrapper>(json);
            return tileWrapper.tiles;
        }

        public static List<BattalionDataWrapper> ParseJsonToBrigadeData(string json)
        {
            BattalionListWrapper battalionWrapper = JsonUtility.FromJson<BattalionListWrapper>(json);
            return battalionWrapper.battalions;
        }
    }

    [System.Serializable]
    public class TileListWrapper
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

    //[System.Serializable]
    //public class BrigadeListWrapper
    //{
    //    public List<BrigadeDataWrapper> brigades;
    //}

    //[System.Serializable]
    //public class BrigadeDataWrapper
    //{
    //    public int tileID;
    //    public string name;
    //    public List<BattalionDataWrapper> battalions;
    //}

    [System.Serializable]
    public class BattalionListWrapper
    {
        public List<BattalionDataWrapper> battalions;
    }

    [System.Serializable]
    public class BattalionDataWrapper
    {
        public int cost;
        public int lightAtk;
        public int heavyAtk;
        public int health;
        public int armour;
        public int supply;
        public int speed;
        public int awareness;
    }
}