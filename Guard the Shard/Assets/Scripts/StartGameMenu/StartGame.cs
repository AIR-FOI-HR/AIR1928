using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{
    public Canvas previewCanvas;
    public Button playButton;
    public Button mainMenu;
    public Transform userHS;
    public Transform globalHS;
    public Canvas inGameCanvas;
    
    void Awake()
    {
        previewCanvas = GameObject.Find("PreviewLevelCanvas").GetComponent<Canvas>();

        inGameCanvas = GameObject.Find("InGameCanvas").GetComponent<Canvas>();
        inGameCanvas.enabled = false;

        playButton = GameObject.Find("PlayButton").GetComponent<Button>();
        playButton.onClick.AddListener(PlayLevel);

        mainMenu = GameObject.Find("ReturnButton").GetComponent<Button>();
        mainMenu.onClick.AddListener(Return);

        userHS = GameObject.Find("UserHS").transform;
        Text userHsValue = userHS.GetComponent<Text>();
        userHsValue.text = "Your highscore: \n 5000";

        globalHS = GameObject.Find("GlobalHS").transform;
        Text globalHsValue = globalHS.GetComponent<Text>();
        globalHsValue.text = "Global highscore: \n 10000";

        Time.timeScale = 0f;
        
    }

    // Start is called before the first frame update
    void Start()
    {
        FindObjectOfType<AudioManagerController>().MuteAll();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void PlayLevel()
    {
        FindObjectOfType<AudioManagerController>().UnMuteAll();
        Time.timeScale = 1f;
        inGameCanvas.enabled = true;
        previewCanvas.enabled = false;
    }

    void Return()
    {
        SceneManager.LoadScene("MainMenu", LoadSceneMode.Additive);
        FindObjectOfType<AudioManagerController>().UnMuteAll();
    }
}
