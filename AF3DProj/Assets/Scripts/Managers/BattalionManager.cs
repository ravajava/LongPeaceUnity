using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using JsonHelpers;

/* 
 * Title: Battalion Manager
 * Author: Josue Lopes
 * Date: October 30th, 2018
*/

public class BattalionManager
{
    private static BattalionManager m_Instance = null;
    private List<BattalionDataWrapper> m_BattalionData;
    private List<Battalion> m_Battalions;

    private BattalionManager()
    {
        m_BattalionData = new List<BattalionDataWrapper>();
        m_Battalions = new List<Battalion>();

        LoadBattalionData();
    }

    public static BattalionManager Instance
    {
        get
        {
            if (m_Instance == null)
                m_Instance = new BattalionManager();

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
}
