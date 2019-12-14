using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;

public class SkillControl
{
    public List<Skill> GetSkills()
    {
        string web = GetSkillData("getAll");

        string[] skill = web.Split('|');
        List<Skill> skills = new List<Skill>();
        foreach(string s in skill)
        {
            skills.Add(JsonUtility.FromJson<Skill>(s));
        }

        return skills;
    }

    private string GetSkillData(string type)
    {
        using (WebClient client = new WebClient())
        {
            string link = $"https://airprojektunitygts.000webhostapp.com/skill.php?type={type}";
            string htmlCode = client.DownloadString(link);
            return htmlCode;
        }
    }

    public void SetSkills(int skill1, int skill2, int skill3, int userId)
    {
        using (WebClient client = new WebClient())
        {
            string link = $"https://airprojektunitygts.000webhostapp.com/skill.php?type=setSkills&skill1={skill1}&" +
            $"skill2={skill2}&skill3={skill3}&userId={userId}";
            string htmlCode = client.DownloadString(link);
        }
        
    }
}


