using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class NameTransfer : MonoBehaviour
{
    public static NameTransfer Instance;

    public string currentPlayerName;

    public string bestName;
    public int bestScore;


    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }


    [System.Serializable]
    class SaveData
    {
        public string bestName;
        public int bestscore;
    }

    public void SaveBest()
    {
        SaveData data = new SaveData();
        data.bestName = bestName;
        data.bestscore = bestScore;

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void LoadBest()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            bestName = data.bestName;
            bestScore = data.bestscore;
        }
    }
}
