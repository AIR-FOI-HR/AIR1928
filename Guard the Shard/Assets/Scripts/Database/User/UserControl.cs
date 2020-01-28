using Assets.Scripts.Database;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using UnityEngine;

public class UserControl
{
    public int Register(string username, string password)
    {
        string web = GetUserData(username, password, "signUp");

        try
        {
            int ID = int.Parse(web);
            return ID;
        }
        catch
        {
            return 0;
        }
    }

    public User Login(string username, string password)
    {
        string web = GetUserData(username, password, "signIn");

        try
        {
            User user = JsonUtility.FromJson<User>(web);
            return user;
        }
        catch
        {
            return null;
        }
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

    public User GetUser(int userId)
    {
        using (WebClient client = new WebClient())
        {
            string link = $"https://airprojektunitygts.000webhostapp.com/user.php?type=getUser&userId={userId}";
            string htmlCode = client.DownloadString(link);
            User user = JsonUtility.FromJson<User>(htmlCode);
            return user;
        }
    }

    public async Task SetUserLevel(int userId, int level)
    {
        using (WebClient client = new WebClient())
        {
            string link = $"https://airprojektunitygts.000webhostapp.com/user.php?type=setUserLevel&userId={userId}&level={level}";
            string htmlCode = client.DownloadString(link);
            return;
        }
    }

    public async Task ChangeUsername(int userId, string username)
    {
        using (WebClient client = new WebClient())
        {
            string link = $"https://airprojektunitygts.000webhostapp.com/user.php?type=changeUsername&userId={userId}&username={username}";
            string htmlCode = client.DownloadString(link);
            return;
        }
    }
}
