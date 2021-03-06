﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BaseHealth : MonoBehaviour
{
    public int LivesLeft = 5;
    
    
    void Awake()
    {
        
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }
    //Uzimanje štete kad je neprijatelj došao do kraja svog puta
    public void TakeDamage()
    {
         
        //oduzima se jedan život
        LivesLeft--;
        //TODO provjera jeli ugasena vibracija u postavkama
        //Vibration ne radi u unity remote, samo u build appu        
        //FindObjectOfType<AudioManagerController>().DisableVibration();
        bool allowed = FindObjectOfType<AudioManagerController>().AllowVibration;
        if (allowed)
        {
            Handheld.Vibrate();
        }
        
        FindObjectOfType<ScaleHealth>().Scale(LivesLeft);
        //ako smo ostali bez života
        if (LivesLeft <= 0)
        {
            string score = FindObjectOfType<InGameEventMaanger>().Score.GetComponent<Text>().text;
            FindObjectOfType<UIElementManager>().GameOver(score);
            
        }
    }
}
