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
    //Change the username of user
    public async Task<bool> ChangeUsername(int userId, string username)
    {
        using (WebClient client = new WebClient())
        {
            string link = $"https://airprojektunitygts.000webhostapp.com/user.php?type=changeUsername&userId={userId}&username={username}";
            string htmlCode = client.DownloadString(link);
            if (htmlCode == "valid")
            {
                return true;
            }
            return false;
        }
    }
    //Change the password of user, all validation for old password is done here, returns true if successful
    //returns false if old password is incorrect
    public bool ChangePassword(int userId, string oldPassword, string newPassword)
    {
        using (WebClient client = new WebClient())
        {
            string link = $"https://airprojektunitygts.000webhostapp.com/user.php?type=changePassword&userId={userId}&password={oldPassword}&newPassword={newPassword}";
            string htmlCode = client.DownloadString(link);
            if(htmlCode == "valid")
            {
                return true;
            }
            return false;
        }
    }
}
