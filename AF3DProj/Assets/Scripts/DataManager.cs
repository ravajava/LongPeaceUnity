using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using UnityEngine;

/* 
 * Title: Data Manager
 * Author: Josue Lopes
 * Date: October 6th, 2018
*/

namespace DataManagement
{
    public class DataManager : MonoBehaviour
    {
        public void SaveGame()
        {
            // create save data object from current data
            SaveData save = CreateSavaDataObject();

            // create formatter and save file
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Create(Application.persistentDataPath + "/TLP_SaveData");

            // serialize data to save file and close file
            bf.Serialize(file, save);
            file.Close();

            Debug.Log("Game Saved.");
        }

        public void LoadGame()
        {
            // if save file exists
            if (File.Exists(Application.persistentDataPath + "/TLP_SaveData"))
            {
                // create formatter and grab file
                BinaryFormatter bf = new BinaryFormatter();
                FileStream file = File.Open(Application.persistentDataPath + "/TLP_SaveData", FileMode.Open);

                // deserialize data into save data object
                SaveData save = bf.Deserialize(file) as SaveData;
                file.Close();

                // TODO: input data from save object into proper location
            }
        }

        private SaveData CreateSavaDataObject()
        {
            SaveData data = new SaveData();
            
            // TODO: grab data from somewhere

            return null;
        }
    }

    [System.Serializable]
    public class SaveData
    {
        // faction data
        public Faction playerFaction;

        // brigade data
        public List<Brigade> brigades;

        public SaveData()
        {
            brigades = new List<Brigade>();
        }
    }
}

