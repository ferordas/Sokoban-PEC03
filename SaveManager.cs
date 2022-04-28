using System.IO;
using UnityEngine;

public class SaveManager : MonoBehaviour
{
    public static string directory = "/SaveData/";
    public static string fileName = "MyData.txt";


    // Start is called before the first frame update
    public static void Save(PlayerData Stage)
    {

        string dir = Application.persistentDataPath + directory;

        if (!Directory.Exists(dir))
            Directory.CreateDirectory(dir);

        string json = JsonUtility.ToJson(Stage);
        File.WriteAllText(dir + fileName, json);
    
    }

    public static PlayerData Load() {

        string fullPath = Application.persistentDataPath + directory + fileName;
        PlayerData Stage = new PlayerData();

        if (File.Exists(fullPath))
        {
            string json = File.ReadAllText(fullPath);
            Stage = JsonUtility.FromJson<PlayerData>(json);
        }
        else
        {
            Debug.Log("Save file doesn'y exist");
        }

        return Stage;
    }
}
