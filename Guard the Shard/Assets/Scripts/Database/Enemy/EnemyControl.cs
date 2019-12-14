using Assets.Scripts.Database;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;

public class EnemyControl
{
    public Enemy GetEnemy(int id)
    {
        string web = GetEnemyData(id, "getEnemy");

        Enemy enemy = JsonUtility.FromJson<Enemy>(web);

        return enemy;
    }

    private string GetEnemyData(int id, string type)
    {
        using (WebClient client = new WebClient())
        {
            string link = $"https://airprojektunitygts.000webhostapp.com/enemy.php?enemyId={id}&type={type}";
            string htmlCode = client.DownloadString(link);
            return htmlCode;
        }
    }
}
