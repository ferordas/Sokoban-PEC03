using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public LevelBuilder m_LevelBuilder;
    public GameObject m_NextButton;

    private bool m_ReadyForInput;
    public static bool ResetearScene = false;
    private Player m_Player;

    public GameObject Stage;


    void Start() {


        SceneManager.SetActiveScene(SceneManager.GetSceneByName("StageSelection"));

        //  GameObject.Find("Canvas").GetComponent<SaveTest>().Stage.Stage = 0;
        //   joystick = GameObject.Find("Fixed Joystick").transform ;

        //  m_NextButton.SetActive(false);
        ResetScene();
      
        //m_LevelBuilder.Build();
        //m_Player = FindObjectOfType<Player>();
       // //m_Player = GameObject.Find("PROTA(Clone)").GetComponent<Player>();
    }

    void Update() {

        // IsLevelComplete(m_NextButton.SetActive(true));

        if (ResetearScene)
        {
            ResetearScene = false;
            ResetScene();
        }

       // Vector2 moveInput = new Vector2(joystick.Horizontal, joystick.Vertical);

        Vector2 moveInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
       // Vector2 moveInput = new Vector2(ProtaMove.MoveRight1() + ProtaMove.MoveLeft1(), ProtaMove.MoveUp1() + ProtaMove.MoveDown1());
       // Vector2 moveInput = new Vector2(ProtaMove.MoveRight() + ProtaMove.MoveLeft(), ProtaMove.MoveUp() + ProtaMove.MoveDown());
        moveInput.Normalize();

        if (moveInput.sqrMagnitude > 0.5)

        {

            if (m_ReadyForInput)
            {

                m_ReadyForInput = false;
                m_Player.Move(moveInput);
              //  m_NextButton.SetActive(IsLevelComplete());

            }
            else
            {

                m_ReadyForInput = true;
            }


        }
    
    }


    public void NextLevel() 
    {
      //  m_NextButton.SetActive(false);
        m_LevelBuilder.NextLevel();
       // LevelBuilder.m_CurrentLevel++;
        // m_LevelBuilder.Build();
        StartCoroutine(ResetSceneASync());
    }
    public void LevelX() 
    {
      //  m_NextButton.SetActive(false);
        m_LevelBuilder.CargarStageX();
       // LevelBuilder.m_CurrentLevel++;
        // m_LevelBuilder.Build();
        StartCoroutine(ResetSceneASync());
    }

    public void ResetScene()
    {
        StartCoroutine(ResetSceneASync());
    }


    bool IsLevelComplete() {

        Box[] boxes = FindObjectsOfType<Box>();
        foreach (var box in boxes)
        {
            if (!box.m_OnCross) return false;
        }
        
        return true;

    }

    IEnumerator ResetSceneASync() {
        if (SceneManager.sceneCount > 1)

        {
            AsyncOperation asyncUnload = SceneManager.UnloadSceneAsync("LevelScene");
            while (!asyncUnload.isDone)
            {
                yield return null;
                Debug.Log("Unlaoding...");
            }
            Debug.Log("Unload Done");
            Resources.UnloadUnusedAssets();
        }

        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync("LevelScene", LoadSceneMode.Additive);
        while (!asyncLoad.isDone)
        {
            yield return null;
            Debug.Log("Laoding...");

        }
        SceneManager.SetActiveScene(SceneManager.GetSceneByName("LevelScene"));
        m_LevelBuilder.Build();
        m_Player = FindObjectOfType<Player>();
        Debug.Log("Level Loaded");
    
    }

}
