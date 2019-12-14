using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Scoring : MonoBehaviour
{
    public Text ScoreUi;
    //score je 0 na početku
    public float score = 0;
    //varijabla koja će čuvati zadnji 
    private float lastUpdateTime;
    void Start()
    {
        //inicijalno postavljanje vremena
        lastUpdateTime = Time.time;
    }
    
    public void AddScore(float amount)
    {
        //vrijeme koje je prošlo od zadnjeg updatea
        float elapsed = Time.time - lastUpdateTime;
        //ponovno postavljanje updateTimea za sljedeći put
        lastUpdateTime = Time.time;
        //što je manje vremena prošlo od zadnjeg updatea više bodova se nagrađuje do 2 puta više bodova
        if (elapsed < 1) {
            score += amount * 2;
        }
        else if (elapsed < 2) {
            score += amount * 1.6f;
        }
        else if (elapsed < 3) {
            score += amount * 1.2f;
        }
        else { 
            score += amount; 
        }
        ScoreUi.text = score.ToString();
        //Debug.Log(elapsed);
    }
}
