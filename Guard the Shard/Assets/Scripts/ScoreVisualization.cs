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

    

    void Awake()
    {
        
        

    }
    // Start is called before the first frame update
    void Start()
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
            
            int score = scoreControl.GetAllScores(1).Scores[i].Score;
            int userId = scoreControl.GetAllScores(1).Scores[i].UserID;
            string username = "Korisnik: " + userId.ToString();

            entryTransform.Find("MockPosition").GetComponent<Text>().text = rank.ToString();
            entryTransform.Find("MockScore").GetComponent<Text>().text = score.ToString();
            entryTransform.Find("MockName").GetComponent<Text>().text = username;

            i++;


        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
