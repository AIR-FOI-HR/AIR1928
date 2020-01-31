using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelMenuScript : MonoBehaviour
{
    public Button btnExit;
    public Button[] btnLvl;

    // Start is called before the first frame update
    //Otključava razine do kojih je korisnik došao
    void Start()
    {
        UserControl userControl = new UserControl();
        for (int i = 0; i < userControl.GetUser(PlayerPrefs.GetInt("userid")).Level; i++)
        {
            btnLvl[i].interactable = true;
        }
    }

    public void IdinaLevel()
    {
        SceneManager.LoadScene(0);
    }

    public void RazinaDva()
    {
        SceneManager.LoadScene(10);
    }

    public void RazinaTri()
    {
        SceneManager.LoadScene(11);
    }

    public void RazinaCetiri()
    {
        SceneManager.LoadScene(12);
    }

    public void Izlaz()
    {
        SceneManager.LoadScene(3);
    }
}
