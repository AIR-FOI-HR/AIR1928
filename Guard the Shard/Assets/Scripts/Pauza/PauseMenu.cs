using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class PauseMenu : MonoBehaviour
{
    //menu i buttoni koji se nalaze na menu
    public Canvas PauseMenuUI;
    public GameObject CoverPanel;
    public Button ResumeButton;
    public Button QuitButton;
    public Button MenuButton;
   
    void Awake()
    {
        PauseMenuUI = GameObject.Find("PauseMenuCanvas").GetComponent<Canvas>();

        ResumeButton = GameObject.Find("ResumeButton").GetComponent<Button>();
        ResumeButton.onClick.AddListener(Resume);

        QuitButton = GameObject.Find("QuitButton").GetComponent<Button>();
        QuitButton.onClick.AddListener(Quit);

        MenuButton = GameObject.Find("MenuButton").GetComponent<Button>();
        MenuButton.onClick.AddListener(Menu);
        
    }
    

    // Start is called before the first frame update
    void Start()
    {
       
        
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Pause()
    {

        
        FindObjectOfType<UIElementManager>().Pause();

    }
    void Resume()
    {
       
        FindObjectOfType<UIElementManager>().PlayGame();
    }
    void Menu()
    {
        FindObjectOfType<AudioManagerController>().UnMuteAll();
        SceneManager.LoadScene("MainMenu", LoadSceneMode.Additive);
        
    }
    void Quit()
    {
        //Zatvra aplikaciju, u editoru se nista ne dogadja (jedino build nacin)
        Application.Quit();
    }
}
