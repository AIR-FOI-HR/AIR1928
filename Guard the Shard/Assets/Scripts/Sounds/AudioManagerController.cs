﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using System;

public class AudioManagerController : MonoBehaviour
{
    //lista zvukova koje pokrećemo
    public Sound[] sounds;
    public bool AllowVibration = true;
    //Awake se poziva kako bi nam zvukovi bili spremni prije prvog framea
    void Awake()
    {
        //Zvukovima se daju vrijednosti iz sourcea (UnityEditor)
        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;

        }
    }
    // Start is called before the first frame update
    void Start()
    {
        //kod pokretanje igre pokreće se i glavna tema.
        
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Play(string name)
    {
        //Izraz za pronalaženje zvuka po imenu danom u UnityEditoru
        Sound s = Array.Find(sounds, sound => sound.name == name);
        //Ako je ime krivo zadano trebamo izbjeci error
        if(s == null)
        {
            return;
        }
        s.source.Play();
        
    }

    //Pronalazi zuvkovni zapis po imenu i prigusuje ga
    public void Mute(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
        {
            
            return;
        }
        s.source.mute = true;
    }
    //Pronalazi zvukovni zapis i omogucuje ga
    void Unmute(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
        {

            return;
        }
        s.source.mute = false;
    }

    public void MuteAll()
    {
        foreach (Sound s in sounds)
        {
            Mute(s.name);
        }
    }

    public void UnMuteAll()
    {
        foreach (Sound s in sounds)
        {
            Unmute(s.name);
        }
    }

    public void DisableVibration()
    {
        AllowVibration = false;
    }

    public void EnableVibration()
    {
        AllowVibration = true;
    }
    

}

