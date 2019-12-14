using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelMenuScript : MonoBehaviour
{
    /*public Button btnExit;
    public Button btnLvl1;
    public Button btnLvl2;
    public Button btnLvl3;
    public Button btnLvl4;
    public Button btnLvl5;
    public Button btnLvl6;
    public Button btnLvl7;
    public Button btnLvl8;*/

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void IdinaLevel()
    {
        SceneManager.LoadScene(0);
    }

    public void Izlaz()
    {
        SceneManager.LoadScene(3);
    }
}
