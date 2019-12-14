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
    // Start is called before the first frame update
    void Awake()
    {
        //Pronalazak odgovorajućih objekata
        LevelPreview = GameObject.Find("PreviewLevelCanvas").GetComponent<Canvas>();
        InGameCanvas = GameObject.Find("InGameCanvas").GetComponent<Canvas>();
        GameOverCanvas = GameObject.Find("GameOverCanvas").GetComponent<Canvas>();
        PauseCanvas = GameObject.Find("PauseMenuCanvas").GetComponent<Canvas>();
       
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

        Time.timeScale = 0f;
        //FindObjectOfType<AudioManagerController>().MuteAll();

    }

    public void PlayGame()
    {
        //Igra je u tijeku
        FindObjectOfType<AudioManagerController>().UnMuteAll();
        FindObjectOfType<AudioManagerController>().Play("MainTheme");
        Time.timeScale = 1f;
        InGameCanvas.enabled = true;
        GameOverCanvas.enabled = false;
        LevelPreview.enabled = false;
        PauseCanvas.enabled = false;
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

        FindObjectOfType<GameOverScreen>().userResult.text = "Your score: " + score;

    }
}
