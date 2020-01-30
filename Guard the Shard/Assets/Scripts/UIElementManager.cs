using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UIElementManager : MonoBehaviour
{


    //Elementi sučelja čije pojavljivanje kontroliramo
    public Canvas InGameCanvas;
    public Canvas PauseCanvas;
    public Canvas GameOverCanvas;
    public Canvas LevelPreview;
    public ScoreControl scoreControl = new ScoreControl();
    public GetLevelId levelId = new GetLevelId();
    public Canvas DialogBoxCanvas;

    //varijable za dialog
    public bool pauseMode = false;
    public GameObject dialogBox;
    public Text dialogText;
    public string dialog;
    // Start is called before the first frame update
    void Awake()
    {
        //Pronalazak odgovorajućih objekata
        LevelPreview = GameObject.Find("PreviewLevelCanvas").GetComponent<Canvas>();
        InGameCanvas = GameObject.Find("InGameCanvas").GetComponent<Canvas>();
        GameOverCanvas = GameObject.Find("GameOverCanvas").GetComponent<Canvas>();
        PauseCanvas = GameObject.Find("PauseMenuCanvas").GetComponent<Canvas>();
        DialogBoxCanvas = GameObject.Find("DialogBoxCanvas").GetComponent<Canvas>();
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Preview()
    {
        //Pocetno sucelje levela
        InGameCanvas.enabled = false;
        GameOverCanvas.enabled = false;
        LevelPreview.enabled = true;
        PauseCanvas.enabled = false;
        DialogBoxCanvas.enabled = false;

        Time.timeScale = 0f;
        //FindObjectOfType<AudioManagerController>().MuteAll();

    }

    public void PlayGame()
    {
        DialogBoxCanvas.enabled = true;
        LevelPreview.enabled = false;
        
        if(GameObject.Find("WaveSpawner") == null)
        {
            dialogText.text = "Try to survive as much as posible. " +
                              "Good luck, you are on endless mode.";
        }
        else if (GameObject.Find("TutorijalEventManager") != null)
        {
            dialogText.text = dialog;
        }
        else
        {
            dialogText.text = dialog;
        }


        // Prilikom pritiska na ekran, dialog nestaje
        // i igra pocinje
        if (Input.GetKeyDown(KeyCode.Space) || Input.touchCount > 0 || pauseMode)
        {
            pauseMode = true;
            DialogBoxCanvas.enabled = false; 
            
            //Igra je u tijeku
            FindObjectOfType<AudioManagerController>().UnMuteAll();
            FindObjectOfType<AudioManagerController>().Play("MainTheme");
            //FindObjectOfType<ScaleEnergy>().Scale(10);
            Time.timeScale = 1f;
            GameOverCanvas.enabled = false;
            InGameCanvas.enabled = true;
            PauseCanvas.enabled = false;
        
        }
    }

    public void Pause()
    {
        //Igra je pauzirana
        FindObjectOfType<AudioManagerController>().MuteAll();
        Time.timeScale = 0f;
        InGameCanvas.enabled = false;
        GameOverCanvas.enabled = false;
        LevelPreview.enabled = false;
        PauseCanvas.enabled = true;
    }

    public void GameOver(string score)
    {
        //Kraj igre, treba nam rezultat za ispis na zaslonu za kraj igree
        InGameCanvas.enabled = false;
        GameOverCanvas.enabled = true;
        LevelPreview.enabled = false;
        PauseCanvas.enabled = false;

        Time.timeScale = 0f;
        scoreControl.writeScore(levelId.LevelId(), 1, int.Parse(score));
       
        FindObjectOfType<GameOverScreen>().userResult.text = "Your score: " + score;
        FindObjectOfType<ScoreVisualization>().Visualize();
        //Debug.Log(FindObjectOfType<GameOverScreen>().userResult.text);

    }

    
}
