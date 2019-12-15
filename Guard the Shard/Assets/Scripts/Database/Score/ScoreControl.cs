using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts.Database;
using System.Net;
using System;

public class ScoreControl 
{
    public Scores GetPlayerScore(int levelId, int userId)
    {
        string web = GetPlayerScoreData(levelId, userId, "getPlayerHS");
       
        Scores score = JsonUtility.FromJson<Scores>(web);
       
        return score;
    }

    private string GetPlayerScoreData(int levelId, int userId, string type)
    {
        using (WebClient client = new WebClient())
        {
            string link = $"https://airprojektunitygts.000webhostapp.com/HS.php?LevelID={levelId}&UserID={userId}&Score={0}&type={type}";
            string htmlCode = client.DownloadString(link);
            
            return htmlCode;

        }
    }

    public ScoresData GetAllScores(int levelId)
    {
        string web = GetAllScoresData(levelId, "getAllScores");         

        ScoresData  scores = JsonUtility.FromJson<ScoresData>(web);
        //Debug.Log(scores.Scores[0].Score);
        return scores;
    }

    private string GetAllScoresData(int levelId, string type)
    {
        
        using (WebClient client = new WebClient())
        {
            
            string link = $"https://airprojektunitygts.000webhostapp.com/HS.php?LevelID={levelId}&UserID={1}&Score={0}&type={type}";
            string htmlCode = client.DownloadString(link);
           
            return htmlCode;
        }
    }

    public void writeScore(int levelId, int userId, int scoreOnLevel)
    {        
        string web = GetPlayerScoreData(levelId, userId, "getPlayerHS");
        string type;
        
        //korisnik već ima rezulatat i zadovoljava da je HS
        if (web.Length > 0)
        {
            type = "updatePlayerHS";
            Scores score = JsonUtility.FromJson<Scores>(web);
            if (score.Score < scoreOnLevel)
            {
                Debug.Log("Velik score");

                using (WebClient client = new WebClient())
                {
                    string link = $"https://airprojektunitygts.000webhostapp.com/HS.php?LevelID={levelId}&UserID={userId}&Score={scoreOnLevel}&type={type}";
                    string htmlCode = client.DownloadString(link);
                }
            }
            //rezultat nije Hs
            else
            {
                Debug.Log("Premal score");
            }
        //prvi score korisnika
        }
        else
        {
            type = "writeScore";
            Debug.Log("Prvi Score");
            using (WebClient client = new WebClient())
            {
                string link = $"https://airprojektunitygts.000webhostapp.com/HS.php?LevelID={levelId}&UserID={userId}&Score={scoreOnLevel}&type={type}";
                string htmlCode = client.DownloadString(link);
            }

        }

        
        
    }

    public User GetUsername(int userId)
    {
        string web = GetUsernameData(userId, "getPlayerUsername");

        User user = JsonUtility.FromJson<User>(web);
        Debug.Log(user.Username);
        return user;
    }

    private string GetUsernameData(int userId, string type)
    {

        using (WebClient client = new WebClient())
        {

            string link = $"https://airprojektunitygts.000webhostapp.com/HS.php?LevelID={1}&UserID={userId}&Score={0}&type={type}";
            string htmlCode = client.DownloadString(link);

            return htmlCode;
        }
    }



}
