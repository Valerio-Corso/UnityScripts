using System.Collections;
using System.Collections.Generic;
using System.IO;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class LocalSaveController : MonoBehaviour
{
    const string fileName = "/playerInfo.dat";

    public int Coin { get; set; }

    public int Record { get; set; }

    public int SkinSelected { get; set; }

    public bool HasFinishedTutorial { get; set; }

    public bool IsFirstTimePlaying { get; set; }

    public string FilePath { get; set; }

    void Start()
    {
        FilePath = Application.persistentDataPath + fileName;

        //check save presence
        if (!File.Exists(FilePath))
        {
            SaveDefaultData();
        }
        //load data
        LoadData();
    }

    /// <summary>
    /// Set Default Initial data
    /// </summary>
    private void SaveDefaultData()
    {
        //open formatter and create file
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(FilePath);

        PlayerData data = new PlayerData();
        //get local variables
        data.Coin = 0;
        data.Record = 0;
        data.SkinSelected = 0;

        data.HasFinishedTutorial = false;
        data.IsFirstTimePlaying = true;

        //serialize and close
        bf.Serialize(file, data);
        file.Close();
    }

    /// <summary>
    /// Save All Data
    /// </summary>
    public void SaveAllData()
    {
        //open formatter and create file
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(FilePath);

        PlayerData data = new PlayerData();
        //get local variables
        data.Coin = Coin;
        data.IsFirstTimePlaying = IsFirstTimePlaying;
        data.HasFinishedTutorial = HasFinishedTutorial;
        data.Record = Record;
        data.SkinSelected = SkinSelected;

        //serialize and close
        bf.Serialize(file, data);
        file.Close();
    }

    /// <summary>
    /// Load data locally to avoid reading/writing from file each time
    /// </summary>
    public void LoadData()
    {
        if (File.Exists(FilePath))
        {
            //open formatter and file
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(FilePath, FileMode.Open);

            //deserialize data
            PlayerData data = (PlayerData)bf.Deserialize(file);
            file.Close();

            //assign values
            Coin = data.Coin;
            IsFirstTimePlaying = data.IsFirstTimePlaying;
            HasFinishedTutorial = data.HasFinishedTutorial;
            Record = data.Record;
            SkinSelected = data.SkinSelected;
        }
    }

    /// <summary>
    /// The data written to a file
    /// </summary>
    [Serializable]
    class PlayerData
    {
        public int Coin { get; set; }

        public int SkinSelected { get; set; }

        public int Record { get; set; }

        public bool IsFirstTimePlaying { get; set; }

        public bool HasFinishedTutorial { get; set; }
    }
}


