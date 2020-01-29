using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InGameEventMaanger : MonoBehaviour
{
    public Canvas InGameCanvas;
    public Button PauseButton;
    public Transform Score;
    public SkillHandlerScript skripta;

    void Awake()
    {
        InGameCanvas = GameObject.Find("InGameCanvas").GetComponent<Canvas>();

        PauseButton = GameObject.Find("PauseButton").GetComponent<Button>();
        PauseButton.onClick.AddListener(StartPause);

        Score = GameObject.FindGameObjectWithTag("ScoreUi").transform;
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

}
