using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreVisualization : MonoBehaviour
{
   
    private Transform entryTemplate;
    private Transform entryContainer;
    private ScoreControl scoreControl = new ScoreControl();
    private UserControl userControl = new UserControl();
    public int UserId;
    private GetLevelId levelId = new GetLevelId();
    

    void Awake()
    {
        
        

    }
    // Start is called before the first frame update
    void Start()
    {
         
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Visualize()
    {
        entryContainer = GameObject.Find("ScoreContainer").transform;
        entryTemplate = GameObject.Find("ScoreTemplate").transform;

        entryTemplate.gameObject.SetActive(false);
        float entryHeight = 20f;

        ScoresData scoresData = scoreControl.GetAllScores(1);

        int i = 0;

        foreach (var item in scoresData.Scores)
        {
            Transform entryTransform = Instantiate(entryTemplate, entryContainer);
            RectTransform entryRectTransform = entryTransform.GetComponent<RectTransform>();
            entryRectTransform.anchoredPosition = new Vector2(0, -entryHeight * i);
            entryTransform.gameObject.SetActive(true);


            int rank = i + 1;

            //inace ce se uzimati iz baze

            int score = scoreControl.GetAllScores(levelId.LevelId()).Scores[i].Score;
            int userId = scoreControl.GetAllScores(levelId.LevelId()).Scores[i].UserID;
            string username = scoreControl.GetUsername(userId).Username;

            entryTransform.Find("MockPosition").GetComponent<Text>().text = rank.ToString();
            entryTransform.Find("MockScore").GetComponent<Text>().text = score.ToString();
            entryTransform.Find("MockName").GetComponent<Text>().text = username;

            i++;


        }
    }
}
