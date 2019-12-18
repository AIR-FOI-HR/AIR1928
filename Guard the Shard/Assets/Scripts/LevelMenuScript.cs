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
    void Start()
    {
        UserControl userControl = new UserControl();
        for (int i = 0; i < userControl.GetUser(20).Level; i++)
        {
            btnLvl[i].interactable = true;
        }
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
