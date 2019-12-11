using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreVisualization : MonoBehaviour
{
   
    private Transform entryTemplate;
    private Transform entryContainer;
   

    void Awake()
    {
        
        entryContainer = GameObject.Find("ScoreContainer").transform;
        entryTemplate = GameObject.Find("ScoreTemplate").transform;

        entryTemplate.gameObject.SetActive(false);
        float entryHeight = 20f;

        for (int i = 0; i < 10; i++)
        {
            Transform entryTransform = Instantiate(entryTemplate, entryContainer);
            RectTransform entryRectTransform = entryTransform.GetComponent<RectTransform>();
            entryRectTransform.anchoredPosition = new Vector2(0, -entryHeight * i);
            entryTransform.gameObject.SetActive(true);
            
            int rank = i + 1;
            //inace ce se uzimati iz baze
            string username = "user";
            int score = Random.Range(0,5000);
            

            entryTransform.Find("MockPosition").GetComponent<Text>().text = rank.ToString();
            entryTransform.Find("MockScore").GetComponent<Text>().text = score.ToString();
            entryTransform.Find("MockName").GetComponent<Text>().text = username;

            

        }

    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
