using UnityEngine;

public class SaveTest : MonoBehaviour
{
    public PlayerData Stage;
    public int levelActual;
    public int levelInicial;

    // Start is called before the first frame update
    void Start() 
    {
        //if (Stage != "") {

        //    LevelBuilder.CargarSavedGame();
        
        //}


        levelInicial = LevelBuilder.m_CurrentLevel;
        ActualitzarStage();
    }

    void Update ()
    {


        levelActual = LevelBuilder.m_CurrentLevel;
        if (levelActual != levelInicial)
        {
            ActualitzarStage();
        }

    }

    public void Guardar() {

        SaveManager.Save(Stage);
    
    }
    
    public void Cargar() {

        Stage = SaveManager.Load();
        LevelBuilder.CargarSavedGame();
       // LevelBuilder.m_CurrentLevel = int.Parse("Stage");

    }
    public void ActualitzarStage() {

        Stage.Stage = LevelBuilder.m_CurrentLevel;

    }

}
