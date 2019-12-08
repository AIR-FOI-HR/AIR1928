using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Button))]
public class MainManuScript : MonoBehaviour
{
    //Gumbi koji se nalaze u sceni
    public Button postavke;
    public Button singlePlayer;
    public Button multiPlayer;
    public Button tureti;

    // Start is called before the first frame update
    void Start()
    {
        postavke = GetComponent<Button>();
        singlePlayer = GetComponent<Button>();

        //Omogućivanje/onemogućivanje glazbe ovisno o prethodnim postavkama korisnika
        if (PlayerPrefs.GetInt("glazba") == 1)
        {
            AudioListener.pause = true;
        }
        else
        {
            AudioListener.pause = false;
        }
    }

    //Prelazak na scenu postavki
    public void IdiNaPostavke()
    {
        SceneManager.LoadScene(4);
    }

    //Pokretanje Singeplayera
    public void PokreniSinglePlayer()
    {
        SceneManager.LoadScene(0);
    }
    
}
