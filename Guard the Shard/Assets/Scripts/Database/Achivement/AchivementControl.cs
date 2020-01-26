using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;

public class AchivementControl
{
    //Returns all achivements in list
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

    //Returns all achivements from some user in list, if user has no achivements, method returns null
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

    //connets user with achivement, returns true if successful and false if user already has that achivement
    public bool SetUserAchivements(int userId, int achivementId)
    {
        string web = SetUserAchivementData("setUserAchivement", userId, achivementId);

        if (web == "Success")
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    //gets user achivements data from web
    private string SetUserAchivementData(string type, int userId, int achivementId)
    {
        using (WebClient client = new WebClient())
        {
            string link = $"https://airprojektunitygts.000webhostapp.com/achivement.php?type={type}&userId={userId}&achivementId={achivementId}";
            string htmlCode = client.DownloadString(link);
            return htmlCode;
        }
    }
}
