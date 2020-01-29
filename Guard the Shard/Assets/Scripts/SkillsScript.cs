using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SkillsScript : MonoBehaviour
{
    public Toggle tglTime;
    public Toggle tglIce;
    public Toggle tglStorm;
    public Toggle tglFire;
    public Toggle tglSwords;
    public Toggle tglStons;

    public ToggleGroup toggleGroup;

    // Start is called before the first frame update
    void Start()
    {
        SkillControl skillControl = new SkillControl();

        foreach (var item in skillControl.GetUserSkills(PlayerPrefs.GetInt("userid")))
        {
            switch (item)
            {
                case 1:
                    tglTime.isOn = true;
                    break;
                case 2:
                    tglIce.isOn = true;
                    break;
                case 3:
                    tglStorm.isOn = true;
                    break;
                case 4:
                    tglFire.isOn = true;
                    break;
                case 5:
                    tglSwords.isOn = true;
                    break;
                case 6:
                    tglStons.isOn = true;
                    break;
                default:
                    break;
            }
        }
    }

    public void Izlaz()
    {
        List<int> skills = new List<int>();

        SkillControl skillControl = new SkillControl();
        IEnumerable<Toggle> active = toggleGroup.ActiveToggles();
        foreach (var item in active)
        {
            switch (item.name)
            {
                case "tglTime":
                    skills.Add(1);
                    break;
                case "tglIce":
                    skills.Add(2);
                    break;
                case "tglStorm":
                    skills.Add(3);
                    break;
                case "tglFire":
                    skills.Add(4);
                    break;
                case "tglSwords":
                    skills.Add(5);
                    break;
                case "tglStons":
                    skills.Add(6);
                    break;
                default:
                    break;
            }
        }

        if (skills.Count != 3)
        {
        }
        else
        {
            skillControl.SetSkills(skills[0], skills[1], skills[2], PlayerPrefs.GetInt("userid"));
            SceneManager.LoadScene(3);
        }
    }

}
