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
    public Transform levelName;
    private ScoreControl scoreControl = new ScoreControl();
    private GetLevelId level  = new GetLevelId();

    void Awake()
    {
        previewCanvas = GameObject.Find("PreviewLevelCanvas").GetComponent<Canvas>();

        playButton = GameObject.Find("PlayButton").GetComponent<Button>();

        playButton.onClick.AddListener(PlayLevel);

        mainMenu = GameObject.Find("ReturnButton").GetComponent<Button>();
        mainMenu.onClick.AddListener(Return);

        userHS = GameObject.Find("UserHS").transform;
        Text userHsValue = userHS.GetComponent<Text>();

        int levelId = level.LevelId();
        levelName = GameObject.Find("LevelName").transform;
        Text levelNameText = levelName.GetComponent<Text>();
        

        if (levelId != 0)
        {
            levelNameText.text = "Level: " + (levelId - 4).ToString();
            userHsValue.text = "YOUR HIGHSCORE: \n" + scoreControl.GetPlayerScore(levelId, 1).Score.ToString();
            //userHsValue.text = "Your highscore: \n 5000";

            globalHS = GameObject.Find("GlobalHS").transform;
            Text globalHsValue = globalHS.GetComponent<Text>();
            globalHsValue.text = "GLOBAL HIGHSCORE: \n" + scoreControl.GetAllScores(levelId).Scores[0].Score.ToString();
        }
        


        FindObjectOfType<UIElementManager>().Preview();
        
    }

    // Start is called before the first frame update
    void Start()
    {
         
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void PlayLevel()
    {
        FindObjectOfType<UIElementManager>().PlayGame();
    }

    void Return()
    {

        FindObjectOfType<AudioManagerController>().UnMuteAll();
        SceneManager.LoadScene("MainMenu", LoadSceneMode.Additive);
        
    }

   

    

}
