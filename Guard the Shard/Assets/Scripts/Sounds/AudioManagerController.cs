using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using System;

public class AudioManagerController : MonoBehaviour
{
    //lista zvukova koje pokrećemo
    public Sound[] sounds;
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
        Play("MainTheme");
        
    }

    // Update is called once per frame
    void Update()
    {
        //Provjera je li uključen menu za pauzu ako je, onda se zvukovi gase inace se pale (dorada->optimizacija)
        if (Time.timeScale == 0f)
        {

            foreach (Sound s in sounds)
            {
                Mute(s.name);
            }
        }
        else
        {
            foreach (Sound s in sounds)
            {
                Unmute(s.name);
            }
        }
    }

    void Play(string name)
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
    void Mute(string name)
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
}
