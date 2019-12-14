using Assets.Scripts.Database;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;

public class UserControl
{
    public string Register(string username, string password)
    {
        string web = GetUserData(username, password, "signUp");

        return web;
    }

    public string Login(string username, string password)
    {
        string web = GetUserData(username, password, "signIn");

        User user = JsonUtility.FromJson<User>(web);

        return web;
    }

    public string GetUserData(string username, string password, string type)
    {
        using (WebClient client = new WebClient())
        {
            string link = $"https://airprojektunitygts.000webhostapp.com/user.php?username={username}&password={password}&type={type}";
            string htmlCode = client.DownloadString(link);
            return htmlCode;
        }
    }
}
