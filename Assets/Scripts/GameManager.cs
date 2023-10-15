using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    // ENCAPSULATION
    private string playername;
    public string playerName{
        get{return playername;}
        set{
            if(playername == null){
                playername = "default name";
            }
            else{
                playername = value;
            }
        }
    }

    [System.Serializable]
    public class SaveData{
        public string savedName;
    }


    void Awake(){
        if(instance == null){
            instance = this;
            DontDestroyOnLoad(gameObject);
            LoadUserData();
        }
        else{
            Destroy(gameObject);
        }
    }

    public void SaveUserData(){
        SaveData data = new SaveData
        {
            savedName = playername
        };
        Debug.Log(data.savedName);
        Debug.Log(playerName);
        string json = JsonUtility.ToJson(data);
        string path = Application.persistentDataPath + "/savefile.json";
        File.WriteAllText(path, json);
    }

    public void LoadUserData(){
        string path = Application.persistentDataPath + "/savefile.json";
        if(File.Exists(path)){
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);
            playername = data.savedName;
            Debug.Log(data.savedName);
            Debug.Log(playerName);
        }
        else{
            Debug.Log("No save file.");
        }
    }
}
