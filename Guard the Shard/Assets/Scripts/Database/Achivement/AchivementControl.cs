using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;

public class AchivementControl
{
    //Returns all achivements
    public List<Achivement> GetAllAchivements()
    {
        string web = GetAchivementData("getAllAchivements");

        string[] achivement = web.Split('|');
        List<Achivement> achivements = new List<Achivement>();
        foreach (string s in achivement)
        {
            achivements.Add(JsonUtility.FromJson<Achivement>(s));
        }

        return achivements;
    }
    //gets achivement data from web
    private string GetAchivementData(string type)
    {
        using (WebClient client = new WebClient())
        {
            string link = $"https://airprojektunitygts.000webhostapp.com/achivement.php?type={type}";
            string htmlCode = client.DownloadString(link);
            return htmlCode;
        }
    }

    //Returns all achivements from some user
    public List<Achivement> GetUserAchivements(int userId)
    {
        string web = GetUserAchivementData("getUserAchivements", userId);

        string[] achivement = web.Split('|');
        List<Achivement> achivements = new List<Achivement>();
        foreach (string s in achivement)
        {
            achivements.Add(JsonUtility.FromJson<Achivement>(s));
        }

        return achivements;
    }

    //gets user achivements data from web
    private string GetUserAchivementData(string type, int userId)
    {
        using (WebClient client = new WebClient())
        {
            string link = $"https://airprojektunitygts.000webhostapp.com/achivement.php?type={type}&user={userId}";
            string htmlCode = client.DownloadString(link);
            return htmlCode;
        }
    }
}
