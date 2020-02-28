using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMasterScript : MonoBehaviour
{

    public static int width = 100;
    public static int score;
    public static float life;
    public static PlayerControllerScript PlayerControler;
    public static GameContollerScript GameController;
    public static InputControllerScript InputController;
    public static UIController uiController;

    private void Start()
    {
        life = 1;
    }

    private void Update()
    {
        uiController.ScoreText.text = "Score: "+ score;
        uiController.LifeBar.size = life;
    }


}
