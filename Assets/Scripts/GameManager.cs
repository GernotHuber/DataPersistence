using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public string playerName;
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
        public int bestScore;
    }
    public void SaveGame()
    {
        SaveData data = new SaveData();
        data.bestScore = bestScore;
        data.bestName = bestName;
        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }
    public void LoadGame()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            bestName = data.bestName;
            bestScore = data.bestScore;
        }
    }

}

