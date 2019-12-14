﻿using System.Collections;
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
        Scores score = JsonUtility.FromJson<Scores>(web);
        if (score.Score < scoreOnLevel)
        {
            Debug.Log("Velik score");
            string type = "writeScore";
            using (WebClient client = new WebClient())
            {
                string link = $"https://airprojektunitygts.000webhostapp.com/HS.php?LevelID={levelId}&UserID={userId}&Score={scoreOnLevel}&type={type}";
            }
        }
        else
        {
            Debug.Log("Premal score");
        }
    }

    public static class JsonHelper
    {
        public static T[] FromJson<T>(string json)
        {
            Wrapper<T> wrapper = JsonUtility.FromJson<Wrapper<T>>(json);
            return wrapper.Items;
        }

        public static string ToJson<T>(T[] array)
        {
            Wrapper<T> wrapper = new Wrapper<T>();
            wrapper.Items = array;
            return JsonUtility.ToJson(wrapper);
        }

        public static string ToJson<T>(T[] array, bool prettyPrint)
        {
            Wrapper<T> wrapper = new Wrapper<T>();
            wrapper.Items = array;
            return JsonUtility.ToJson(wrapper, prettyPrint);
        }

        [Serializable]
        private class Wrapper<T>
        {
            public T[] Items;
        }
    }


}
