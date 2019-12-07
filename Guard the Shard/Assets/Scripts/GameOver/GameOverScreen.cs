using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverScreen : MonoBehaviour
{

     
    //Za potrebe testiranja se koristi property isGameOver, kasnije ce logika biti drugacije implementirana
     
    //hardcodirana vrijednost za potrebe testiranja
    public Text ScoreUi;
    public Button PlayAgainButton;
    public Button GoToMenuButton;
    public Canvas InGameCanvas;
    // Start is called before the first frame update
    public GameObject gameOverScreenUi;
    public GameObject coverGameOver;
    public Text userResult;
    //Dodati event listenere
    void Awake()
    {
        Button btnPlayAgain = PlayAgainButton.GetComponent<Button>();
        btnPlayAgain.onClick.AddListener(PlayAgain);
        Button btnGoToMenu = GoToMenuButton.GetComponent<Button>();
        btnGoToMenu.onClick.AddListener(GoToMenu);
    }
    //Na početku igranja screen je neaktivan
    void Start()
    {
        coverGameOver.SetActive(false);
        gameOverScreenUi.SetActive(false);
        
    }

    // Update is called once per frame
    void Update()
    {
        
        //Kada je igra gotovo zaustaviti igranje i prikazati game over screen -> optimizacija!
        if (gameOverScreenUi.activeSelf)
        {
            InGameCanvas.enabled = false;
            Time.timeScale = 0f;
            userResult.text = "Your score: " + ScoreUi.text;
            gameOverScreenUi.SetActive(true);
            coverGameOver.SetActive(true);        
            
        }
    }

   void PlayAgain()
    {
        string currentSceneName = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(currentSceneName);


    }

    public void GoToMenu()
    {
        SceneManager.LoadScene("MainMenu", LoadSceneMode.Additive);
        FindObjectOfType<AudioManagerController>().UnMuteAll();
        //Pokretat ce se main menu theme muzika
    }
}
