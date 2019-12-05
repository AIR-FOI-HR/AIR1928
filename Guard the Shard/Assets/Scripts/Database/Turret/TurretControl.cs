using Assets.Scripts.Database;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;

public class TurretControl
{
    public Turret GetTurret(int id)
    {
        string web = GetTurretData(id, "getTurret");

        Turret turret = JsonUtility.FromJson<Turret>(web);

        return turret;
    }

    public string GetTurretData(int id, string type)
    {
        using (WebClient client = new WebClient())
        {
            string link = $"https://airprojektunitygts.000webhostapp.com/turret.php?turretId={id}&type={type}";
            string htmlCode = client.DownloadString(link);
            return htmlCode;
        }
    }
}
