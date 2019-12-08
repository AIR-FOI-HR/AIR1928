using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


[RequireComponent(typeof(Button))]
public class SettingsScript : MonoBehaviour
{
    //Gumbi koji se nalaze u sceni postavki
    public Button musicButton;
    public Button soundButton;
    public Button exitButton;

    //Dvije slike koje se izmjenjuju ovisno o tome je li određena postavka uključena/isključena
    public Sprite blockA;
    public Sprite blockB;

    //Dva brojača
    private int brojacS = 0;

    // Start is called before the first frame update
    void Start()
    {
        //Postavljanje slike on/off za gumb glazbe
        if (PlayerPrefs.GetInt("glazba") == 1)
        {
            musicButton.GetComponent<Image>().sprite = blockB;
        }
        else
        {
            musicButton.GetComponent<Image>().sprite = blockA;
        }
    }

    //Promjena postavki glazbe, uključeno/isključeno
    public void changeMusicButton()
    {
        if (PlayerPrefs.GetInt("glazba") == 1)
        {
            musicButton.GetComponent<Image>().sprite = blockA;
            AudioListener.pause = false;
            PlayerPrefs.SetInt("glazba", 0);
            PlayerPrefs.Save();
        }
        else
        {
            musicButton.GetComponent<Image>().sprite = blockB;
            AudioListener.pause = true;
            PlayerPrefs.SetInt("glazba", 1);
            PlayerPrefs.Save();
        }
    }

    //Promjena postavki zvučnih efekata, uključeno/isključeno
    public void changeSoundButton()
    {
        brojacS++;
        if (brojacS % 2 == 0)
        {
            soundButton.image.overrideSprite = blockA;
        }
        else
        {
            soundButton.image.overrideSprite = blockB;
        }
    }

    //Izlaz iz scene postavki
    public void Izlaz()
    {
        SceneManager.LoadScene(3);
    }
}
