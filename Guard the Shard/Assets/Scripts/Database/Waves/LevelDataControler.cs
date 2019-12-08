using System.Collections;
using System.Collections.Generic;
using UnityEngine.Networking;
using UnityEngine;
using System.Net;

public class LevelDataControler : MonoBehaviour
{
    //level koji je pokrenut
    public int levelID;
    //adresa na koju se šalje zahhtjev
    public string jsonUrl;
    //format u koji se spremaju podatci
    public AllLevelData allLevelData;
    // Start is called before the first frame update
    void Start()
    {
        //inače postavi na vrijednost koju želiš
        levelID = 1;
        //sama adresa zahtjeva
        jsonUrl = "https://airprojektunitygts.000webhostapp.com/Wave.php?level=";
        //Sama korutina
        processJsonData(GetWaveData(levelID));
        foreach (EnemyListData item in allLevelData.enemies)
        {
            Debug.Log(item.EnePrefabName);
        }
        foreach (WaveData item in allLevelData.waves)
        {
            Debug.Log(item.Number);
        }
    }
    //Sam zahtjev
    private string GetWaveData(int level)
    {
        using (WebClient client = new WebClient())
        {
            //link plus podatci zbog get metode
            string link = jsonUrl + level.ToString();
            string htmlCode = client.DownloadString(link);
            return htmlCode;
        }
    }

    //konvertiranje json formata u željeni
    private void processJsonData(string _url)
    {
        allLevelData = JsonUtility.FromJson<AllLevelData>(_url);
    }
}
