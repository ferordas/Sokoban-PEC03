using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;



[System.Serializable]
public class LevelElement 
{
    public Text Level;
    public string m_Character;
    public GameObject m_Prefab;
   

}


public class LevelBuilder : MonoBehaviour
{
    public static int m_CurrentLevel;
    public Text Level;
    public List<LevelElement> m_LevelElements;
    private Level m_Level;
    public static bool Construir = false;
    public static bool Construir1 = false;
    public static bool Construir2 = false;
    public static int StageACargar;

    GameObject GetPrefab(char c)
    {
        LevelElement levelElement = m_LevelElements.Find(le => le.m_Character == c.ToString());
        if (levelElement != null)
        {
            return levelElement.m_Prefab;
        }
        else
        {
            return null;
        }
    }

    public void NextLevel()
    {

        m_CurrentLevel++;
      //  SaveTest.ActualitzarStage();
        if (m_CurrentLevel >= GetComponent<Levels>().m_Levels.Count)
        {
            m_CurrentLevel = 0;
        }

    }

    public void Build()
    {
        //SceneManager.UnloadSceneAsync("StageSelection");

        m_Level = GetComponent<Levels>().m_Levels[m_CurrentLevel];
        int startx = -m_Level.Width / 2;
        int x = startx;
        int y = -m_Level.Height / 2;
        foreach (var row in m_Level.m_Rows)
        {
            foreach (var ch in row)
            {
                Debug.Log(ch);
                GameObject prefab = GetPrefab(ch);
                if (prefab)
                {
                    Debug.Log(prefab.name);
                    Instantiate(prefab, new Vector3(x, y, 0), Quaternion.identity);
                }
                x++;

            }
            y++;
            x = startx;
        }
    }
    public void Build1()
    {

        //m_CurrentLevel = 
        m_Level = GetComponent<Levels>().m_Levels[m_CurrentLevel];
        int startx = -m_Level.Width / 2;
        int x = startx;
        int y = -m_Level.Height / 2;
        foreach (var row in m_Level.m_Rows)
        {
            foreach (var ch in row)
            {
                Debug.Log(ch);
                GameObject prefab = GetPrefab(ch);
                if (prefab)
                {
                    Debug.Log(prefab.name);
                    Instantiate(prefab, new Vector3(x, y, 0), Quaternion.identity);
                }
                x++;

            }
            y++;
            x = startx;
        }
    }


    // Start is called before the first frame update
    void Start()
    {
        //if (PlayerData.Stage.Exists)
        //{    CargarSavedGame();
        //    m_CurrentLevel = PlayerData.Stage.Stage;
        //}
    }

    // Update is called once per frame
    void Update()
    {
        if (Construir)
        {
            Construir = false;
            GameManager.ResetearScene = true;
            Build1();


        } 
        if (Construir1)
        {
            Construir1 = false;
            GameManager.ResetearScene = true;
            Build1();


        }
        if (Construir2)
        {
            Construir2 = false;
            CargarStageX();
            //GameManager.ResetearScene = true;
            //Build1();


        }
      //  PlayerData.Stage) = m_CurrentLevel;

        //Level = m_CurrentLevel.ToString();
        //GameObject.Find("NumStage").GetComponent<Text>().TextMesh = Level.ToString();
    }
    
    public static void CargarSavedGame()
    {
        m_CurrentLevel = GameObject.Find("Canvas").GetComponent<SaveTest>().Stage.Stage;
        Resources.UnloadUnusedAssets();
        // m_CurrentLevel = int.Parse(SaveTest.Stage);
        Construir = true;
        // Resources.UnloadUnusedAssets();

      //  StartCoroutine (GameManager.ResetSceneASync());
        // GameManager.ResetScene();

    }


    public void CargarStageX()
    {
        m_CurrentLevel = StageACargar  ;
      //  Construir1 = true;
       // if (StageACargar == 1) { LevelBuilder.m_CurrentLevel = 1; LevelBuilder.CargarSavedGame(); }

    }
}
