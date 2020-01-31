using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class AchievementsScript : MonoBehaviour
{
    public List<Text> Description = new List<Text>();
    public List<Image> Slike = new List<Image>();

    public Sprite blockA;

    private List<Achivement> achivements = new List<Achivement>();
    private List<Achivement> achivementsOstvareni = new List<Achivement>();

    // Start is called before the first frame update
    void Start()
    {
        int userID = PlayerPrefs.GetInt("userid");
        AchivementControl achivementControl = new AchivementControl();
        achivementsOstvareni = achivementControl.GetUserAchivements(userID);

        achivements = achivementControl.GetAllAchivements();
        for (int i = 0; i < achivements.Count; i++)
        {
            Description[i].text = achivements[i].Description;
        }

        foreach (var item in achivementsOstvareni)
        {
            if (item != null)
            {
                for (int j = 0; j < achivements.Count; j++)
                {
                    if (achivements[j].Name == item.Name)
                    {
                        Slike[j].sprite = blockA;
                    }
                }
            }
        }
    }

    public void Izlaz()
    {
        SceneManager.LoadScene(7);
    }
}
