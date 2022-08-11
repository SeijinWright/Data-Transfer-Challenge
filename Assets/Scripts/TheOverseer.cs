using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TheOverseer : MonoBehaviour
{
    public static TheOverseer instance;
    public string playerName;
    public string highestPlayer;
    public int highestScore = 0;
    // Start is called before the first frame update
    void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
        LoadScore();
        DontDestroyOnLoad(gameObject);
    }

    public void CalculateHighscore(int currentScore)
    {
        if (currentScore > highestScore)
        {
            highestScore = currentScore;
            highestPlayer = playerName;
        }
    }

    public void SaveScore()
    {
        SaveData data = new SaveData();
        data.highscoreName = highestPlayer;
        data.highscoreNumber = highestScore;
        string json = JsonUtility.ToJson(data);
        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void LoadScore()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);
            highestPlayer = data.highscoreName;
            highestScore = data.highscoreNumber;
        }
    }

    [System.Serializable]
    public class SaveData
    {
        public string highscoreName;
        public int highscoreNumber;
    }
}
