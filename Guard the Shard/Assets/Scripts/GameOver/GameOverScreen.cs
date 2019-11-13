using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverScreen : MonoBehaviour
{
    //Za potrebe testiranja se koristi property isGameOver, kasnije ce logika biti drugacije implementirana
    bool isGameOver = false;
    //hardcodirana vrijednost za potrebe testiranja
    public float result = 3000;
    public Button PlayAgainButton;
    public Button GoToMenuButton;
    public GameObject PauseButton;
    // Start is called before the first frame update
    public GameObject gameOverScreenUi;
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
  
        gameOverScreenUi.SetActive(false);
        
    }

    // Update is called once per frame
    void Update()
    {
        //Kada je igra gotovo zaustaviti igranje i prikazati game over screen -> optimizacija!
        if (isGameOver)
        {
            gameOverScreenUi.SetActive(true);
            Time.timeScale = 0f;
            PauseButton.SetActive(false);
            userResult.text = "Your score: " + result.ToString();
            
        }
    }

   void PlayAgain()
    {         
        //Riješiti ponovo pokretanje scene -> transform error
        //string currentSceneName = SceneManager.GetActiveScene().name;
        //SceneManager.LoadScene(currentSceneName);


    }

    public void GoToMenu()
    {
        //kada main menu bude dodan dodati scene manager navigaciju
    }
}
