using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using JsonHelpers;

/* 
 * Title: Unit Manager
 * Author: Josue Lopes
 * Date: October 30th, 2018
*/

public class UnitManager
{
    // singleton
    private static UnitManager m_Instance = null;

    // json data wrappers
    private List<BattalionDataWrapper> m_BattalionData;
    private List<BrigadeDataWrapper> m_BrigadeData;

    // unit collections
    private List<Battalion> m_Battalions;
    private List<Brigade> m_Brigades;

    private UnitManager()
    {
        m_BattalionData = new List<BattalionDataWrapper>();
        m_Battalions = new List<Battalion>();

        m_BrigadeData = new List<BrigadeDataWrapper>();
        m_Brigades = new List<Brigade>();

        LoadBattalionData();
        LoadBrigadeData();
    }

    public static UnitManager Instance
    {
        get
        {
            if (m_Instance == null)
                m_Instance = new UnitManager();

            return m_Instance;
        }
    }

    // loads the data for all battalions from json file
    private void LoadBattalionData()
    {
        TextAsset jsonTextFile = Resources.Load<TextAsset>("Infantry Battalion Data");
        m_BattalionData = JsonHelper.ParseJsonToBattalionData(jsonTextFile.text);

        // loop through data wrapper and create proper list of battalions
        foreach (BattalionDataWrapper d in m_BattalionData)
        {
            Battalion b = new Battalion(d.UnitName, d.Cost, d.LightAttack, d.HeavyAttack, d.Health, d.Armour, d.Supply, d.Speed, d.Awareness);
            m_Battalions.Add(b);
        }
    }

    // loads the data for all brigades from json file
    private void LoadBrigadeData()
    {
        TextAsset jsonTextFile = Resources.Load<TextAsset>("brigadeData");
        m_BrigadeData = JsonHelper.ParseJsonToBrigadeData(jsonTextFile.text);

        foreach(BrigadeDataWrapper d in m_BrigadeData)
        {
            List<Battalion> battalions = new List<Battalion>();
            
            foreach (int bt in d.BattalionList)
            {
                battalions.Add(GetBattalionAtIndex(bt));
            }

            Brigade b = new Brigade(d.FactionID, d.BrigadeName, d.BrigadeLocation, battalions);
            m_Brigades.Add(b);
        }
    }

    // returns battalion at index
    public Battalion GetBattalionAtIndex(int index)
    {
        return m_Battalions[index];
    }
}
