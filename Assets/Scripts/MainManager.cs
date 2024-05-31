using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;

public class MainManager : MonoBehaviour
{

    public static MainManager Instance;

    //Variables for current session
    public string playerName;
    public int currentScore;

    //Variables for high score session
    //Specify for other script compile errors
    public int highScore;
    public string highScoreName;

    private void Awake()
    {
        //If there are 2 MainManagers in scene, destroy this one
        //Happens when other scene you move to tries to create its own MainManager
        if(Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        //But don't destroy MainManager if it's the only one
        Instance = this;

        DontDestroyOnLoad(gameObject);

        //Do this, or the code wouldn't know a high score exists in MainManager
        LoadHighScore();
    }

    //Load Game Scene
    public void StartGame()
    {
        SceneManager.LoadScene(1);
        //Make sure scenes are in correct order in File > Build Settings
    }

    //Data Persistance across scenes
    [System.Serializable]
    public class SaveData
    {
        public int highScore;
        public string highScoreName;
    }

    //This looks different from the tutorial as we need to capture two arguments
    public void SaveHighScore(int currentScore, string playerName)
    {
        // First, create a new instance of the save data
        SaveData data = new SaveData();

        //Then specify what you want to store
        data.highScore = currentScore;
        data.highScoreName = playerName;

        //Next, transform that instance to JSON with JsonUtility.ToJson
        string json = JsonUtility.ToJson(data);

        //Finally, use the special method File.WriteAllText to write a string to a file
        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void LoadHighScore()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            highScore = data.highScore;
            highScoreName = data.highScoreName;
        }
    }

}
