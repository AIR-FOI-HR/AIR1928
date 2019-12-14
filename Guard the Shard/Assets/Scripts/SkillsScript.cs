using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SkillsScript : MonoBehaviour
{
    public ToggleGroup toggleGroup;
    private IEnumerable<Toggle> active;

    // Start is called before the first frame update
    void Start()
    {
        active = toggleGroup.ActiveToggles();
        foreach (var item in active)
        {
            Debug.Log("Tekst: " + item.name);
        }
    }

    public void OnOff()
    {
        /*if (PlayerPrefs.GetInt("vatra") == 1)
        {
            PlayerPrefs.SetInt("vatra", 0);
            PlayerPrefs.Save();
        }
        else
        {
            PlayerPrefs.SetInt("vatra", 1);
            PlayerPrefs.Save();
        }*/
        IEnumerable<Toggle> active = toggleGroup.ActiveToggles();
        foreach (var item in active)
        {
            Debug.Log("Tekst: " + item.name);
        }
    }

    /*public void Vrijeme()
    {
        if (PlayerPrefs.GetInt("vrijeme") == 1)
        {
            PlayerPrefs.SetInt("vrijeme", 0);
            PlayerPrefs.Save();
        }
        else
        {
            PlayerPrefs.SetInt("vrijeme", 1);
            PlayerPrefs.Save();
        }
    }

    public void Led()
    {
        if (PlayerPrefs.GetInt("led") == 1)
        {
            PlayerPrefs.SetInt("led", 0);
            PlayerPrefs.Save();
        }
        else
        {
            PlayerPrefs.SetInt("led", 1);
            PlayerPrefs.Save();
        }
    }

    public void Kamen()
    {
        if (PlayerPrefs.GetInt("kamen") == 1)
        {
            PlayerPrefs.SetInt("kamen", 0);
            PlayerPrefs.Save();
        }
        else
        {
            PlayerPrefs.SetInt("kamen", 1);
            PlayerPrefs.Save();
        }
    }

    public void Macevi()
    {
        if (PlayerPrefs.GetInt("mac") == 1)
        {
            PlayerPrefs.SetInt("mac", 0);
            PlayerPrefs.Save();
        }
        else
        {
            PlayerPrefs.SetInt("mac", 1);
            PlayerPrefs.Save();
        }
    }

    public void Munje()
    {
        if (PlayerPrefs.GetInt("munje") == 1)
        {
            PlayerPrefs.SetInt("munje", 0);
            PlayerPrefs.Save();
        }
        else
        {
            PlayerPrefs.SetInt("munje", 1);
            PlayerPrefs.Save();
        }
    }*/

}
