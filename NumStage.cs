using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NumStage : MonoBehaviour
{
    public int currentStage;
    public Text CurrentStage;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        CurrentStage = GetComponent<Text>();
        CurrentStage.text = LevelBuilder.m_CurrentLevel.ToString();
    }
}
