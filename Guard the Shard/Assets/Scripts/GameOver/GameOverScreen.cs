using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverScreen : MonoBehaviour
{    
  
    public Text ScoreUi;
    public Button PlayAgainButton;
    public Button GoToMenuButton;
    public Canvas GameOverCanvas;
    public GameObject coverGameOver;
    public Text userResult;
    
    void Awake()
    {
        //Pronalazak komponenti
        GameOverCanvas = GameObject.Find("GameOverCanvas").GetComponent<Canvas>();

        PlayAgainButton = GameObject.Find("PlayAgainButton").GetComponent<Button>();
        PlayAgainButton.onClick.AddListener(PlayAgain);

        GoToMenuButton = GameObject.Find("GoToMainMenuButton").GetComponent<Button>();
        GoToMenuButton.onClick.AddListener(GoToMenu);

        userResult = GameObject.Find("GameOverScore").GetComponent<Text>();
    }
    //Na početku igranja screen je neaktivan
    void Start()
    {
      
        
    }

    // Update is called once per frame
    void Update()
    {
        
         
         
    }

   void PlayAgain()
    {
        //POnovna igra -> ponovno učitavanje scene 
        string currentSceneName = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(currentSceneName, LoadSceneMode.Single);
        


    }

    public void GoToMenu()
    {
        //Povratak na glavni izbornik
        SceneManager.LoadScene("MainMenu", LoadSceneMode.Single);        

    }
}
