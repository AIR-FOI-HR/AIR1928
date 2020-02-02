using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SkillsScript : MonoBehaviour
{
    public ToggleGroup toggleGroup;

    // Start is called before the first frame update
    void Start()
    {
    }

    public void Izlaz()
    {
        List<int> skills = new List<int>();

        SkillControl skillControl = new SkillControl();
        IEnumerable<Toggle> active = toggleGroup.ActiveToggles();
        foreach (var item in active)
        {
            skills.Add(int.Parse(item.name));
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
