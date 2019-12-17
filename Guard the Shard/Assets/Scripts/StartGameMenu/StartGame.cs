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
    private Button firstSkill;
    private Button secondSkill;
    private Button thirdSkill;
    private Button fourthSkill;
    private Button fifthSkill;
    private ScoreControl scoreControl = new ScoreControl();
    
    void Awake()
    {
        previewCanvas = GameObject.Find("PreviewLevelCanvas").GetComponent<Canvas>();

        playButton = GameObject.Find("PlayButton").GetComponent<Button>();
        
        playButton.onClick.AddListener(PlayLevel);

        mainMenu = GameObject.Find("ReturnButton").GetComponent<Button>();
        mainMenu.onClick.AddListener(Return);

        userHS = GameObject.Find("UserHS").transform;
        Text userHsValue = userHS.GetComponent<Text>();
        userHsValue.text = "YOUR HIGHSCORE: \n" + scoreControl.GetPlayerScore(1, 1).Score.ToString();
        //userHsValue.text = "Your highscore: \n 5000";

        globalHS = GameObject.Find("GlobalHS").transform;
        Text globalHsValue = globalHS.GetComponent<Text>();
        globalHsValue.text = "GLOBAL HIGHSCORE: \n" + scoreControl.GetAllScores(1).Scores[0].Score.ToString();

        firstSkill = GameObject.Find("FireSkillButton").GetComponent<Button>();
        secondSkill = GameObject.Find("FreezeSkillButton").GetComponent<Button>();
        thirdSkill = GameObject.Find("ThunderSkillButton").GetComponent<Button>();
        fourthSkill = GameObject.Find("RockSkillButton").GetComponent<Button>();
        fifthSkill = GameObject.Find("TimeSkillButton").GetComponent<Button>();
 

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

    public void SkillSelector(Button skill)
    {

    }
}
