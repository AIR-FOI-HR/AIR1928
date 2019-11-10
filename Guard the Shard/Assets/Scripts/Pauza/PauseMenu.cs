using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class PauseMenu : MonoBehaviour
{
    //menu i buttoni koji se nalaze na menu
    public GameObject PauseMenuUI;
    public Button ResumeButton;
    public Button QuitButton;
    public Button MenuButton;
    //button koji otvara menu
    public Button PauseButton;

    

    //public bool Paused = false;
    // Start is called before the first frame update
    void Start()
    {
        //Kod starta je menu u stanju resume - neaktivan
        Resume();
        //Event listener za pokretanje stanja pauze
        Button btnPause = PauseButton.GetComponent<Button>();
        btnPause.onClick.AddListener(Pause);       
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Pause()
    {
        
        //Aktivira pause menu
        PauseMenuUI.SetActive(true);
        //Zaustavlja igru
        Time.timeScale = 0f;
        //Event handleri za izbore u menu

        Button btnQuit = QuitButton.GetComponent<Button>();
        btnQuit.onClick.AddListener(Quit);
        Button btnMenu = MenuButton.GetComponent<Button>();
        btnMenu.onClick.AddListener(Menu);
        Button btnResume = ResumeButton.GetComponent<Button>();
        btnResume.onClick.AddListener(Resume);
        
    }
    void Resume()
    {
        //Stanje igranja, nema pause menua i objekti se pomicu
        PauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
    }
    void Menu()
    {
        //Kada glavni izbornik bude napravljen biti će dodana navigacija
        //SceneManager.LoadScene("MainMenu", LoadSceneMode.Additive);
    }
    void Quit()
    {
        //Zatvra aplikaciju, u editoru se nista ne dogadja (jedino build nacin)
        Application.Quit();
    }
}
