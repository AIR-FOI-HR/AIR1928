using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InGameEventMaanger : MonoBehaviour
{
    public Canvas InGameCanvas;
    public Button PauseButton;
    public Transform Score;
    public Button fireballButton;
    public Button freezeButton;
    public Button magicButton;
    public SkillHandlerScript skripta;

    void Awake()
    {
        InGameCanvas = GameObject.Find("InGameCanvas").GetComponent<Canvas>();

        PauseButton = GameObject.Find("PauseButton").GetComponent<Button>();
        PauseButton.onClick.AddListener(StartPause);

        Score = GameObject.FindGameObjectWithTag("ScoreUi").transform;

        fireballButton = GameObject.Find("ThirdSkillButton").GetComponent<Button>();
        fireballButton.onClick.AddListener(delegate { UseSkill(0); });

        freezeButton = GameObject.Find("FirstSkillButton").GetComponent<Button>();
        freezeButton.onClick.AddListener(delegate { UseSkill(1); });

        magicButton = GameObject.Find("SecondSkillButton").GetComponent<Button>();
        magicButton.onClick.AddListener(delegate { UseSkill(2); });

    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void StartPause()
    {
        FindObjectOfType<UIElementManager>().Pause();
    }

    public void UseSkill(int skillId)
    {
        
        skripta.Enabled = true;
        skripta.skillToUSe = skillId;
    }
}
