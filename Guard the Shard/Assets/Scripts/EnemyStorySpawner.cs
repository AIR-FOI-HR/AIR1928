using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyStorySpawner : MonoBehaviour
{
    //Lokacija izlaska neprijatelja
    public Transform spawnPoint;
    public Transform spawnPoint2;
    //broj živih neprijatelja
    public int EnemiesAlive=0;
    //vrijeme između valova
    public float timeBetweenWaves = 5f;
    //2 sec do prvog
    private float countdown = 2f;
    //broj vala
    public int waveNumber = 1;
    //pozicija u listi neprijatelja
    public int currentListPos = 0;
    //skripta u kojoj se nalaze podatci levela
    public LevelDataControler scriptWithData;
    //svi neprijatelji koji se pojavljuju u levelu 
    public List<GameObject> enemyPrefabList;
    //odglumi pointera za prefab koji trebamo
    public List<int> pointerLikeList;
    //Lista neprijatelja po valovima
    public List<List<int>> ListofEnemies = new List<List<int>>();
    //postavljanje parametara i liste neprijatelja
    private void Start()
    {
        scriptWithData = GameObject.Find("DataHandler").GetComponent<LevelDataControler>();
        foreach (EnemyListData item in scriptWithData.allLevelData.enemies)
        {
            enemyPrefabList.Add(Resources.Load(item.EnePrefabName) as GameObject);
            pointerLikeList.Add(item.EneID);
        }
        //privremena lista
        List<int> placeholderList = new List<int>();
        //prvi i najmanji idex
        int index = scriptWithData.allLevelData.waves[0].LevelNum;
        //samo stavljanje u listu koja sadrži sve valove individualne valove koji su naponjeni
        foreach (WaveData item in scriptWithData.allLevelData.waves)
        {
            if (index != item.LevelNum)
            {
                ListofEnemies.Add(placeholderList);
                placeholderList = new List<int>();
                index = item.LevelNum;
            }
            if (index == item.LevelNum)
            {
                placeholderList.Add(item.Enemy);
            }
        }
        ListofEnemies.Add(placeholderList);
    }
    private void Update()
    {
        //ako ima živih neprijatelja
        if (EnemiesAlive > 0) return;
        //ako je odbrojavanje došlo do kraja
        if (countdown <= 0)
        {
            //Pošto se radi o storymode-u ako je došlo do kraj lista s valovima ništa se ne događa
            if (ListofEnemies.Count < waveNumber) return;
            EnemiesAlive = ListofEnemies[waveNumber - 1].Count;
            //stvori wave
            StartCoroutine(SpawnWave());
            //reset timera
            countdown = timeBetweenWaves + waveNumber;
            return;
        }
        //odbrojavanje
        countdown -= Time.deltaTime;
    }
    IEnumerator SpawnWave()
    {
        //povećanje broj wavea za 1
        //waveNumber++;
        //pozicija u listi neprijatelja za dani val se resetira
        currentListPos = 0;
        //stvareanje waveNumber neprijatelja
        //je li iskoristen bonus
        bool bonus = false;
        for (int i = 0; i < (ListofEnemies[waveNumber-1].Count); i++)
        {            
            if (waveNumber % 3 == 0 && !bonus)
            {               
                FindObjectOfType<UIElementManager>().TurretUpgrade();
                bonus = true;
            }
            SpawnEnemy();
            yield return new WaitForSeconds(0.5f);
        }
        //Debug.Log("Wave incoming");
    }
    void SpawnEnemy()
    {
        //samo spawnanje neprijatelja svaki neprijatelj u valu ima istu šansu za spawn (od onog očitanog iz baze)
        int indexer = 0;
        foreach (int item in pointerLikeList)
        {
            if (item == ListofEnemies[waveNumber - 1][currentListPos])
            {
                //gdje je spawn point 1 ili 2
                switch (Random.Range(0, 2))
                {
                    case 0:
                        GameObject instantiatedOnPath1 = (GameObject)Instantiate(enemyPrefabList[indexer], spawnPoint.position, spawnPoint.rotation);
                        NeprijateljKretanje onPath1 = instantiatedOnPath1.GetComponent<NeprijateljKretanje>();
                        //ako ista postoji
                        if (onPath1 != null)
                        {
                            onPath1.GetParameters(scriptWithData.allLevelData.enemies[indexer].EneSpeed, 1);
                        }
                        //ostali parametri
                        NeprijateljFunction onPath1Fun = instantiatedOnPath1.GetComponent<NeprijateljFunction>();
                        //ako ista postoji
                        if (onPath1Fun != null)
                        {
                            onPath1Fun.GetParameters(scriptWithData.allLevelData.enemies[indexer].EneHP, scriptWithData.allLevelData.enemies[indexer].EneWorth);
                        }
                        break;
                    case 1:
                        GameObject instantiatedOnPath2 = (GameObject)Instantiate(enemyPrefabList[indexer], spawnPoint2.position, spawnPoint2.rotation);
                        //prijenos parametara skripti za kretanje
                        NeprijateljKretanje onPath2 = instantiatedOnPath2.GetComponent<NeprijateljKretanje>();
                        //ako ista postoji
                        if (onPath2 != null)
                        {
                            onPath2.GetParameters(scriptWithData.allLevelData.enemies[indexer].EneSpeed, 2);
                        }
                        //ostali parametri
                        NeprijateljFunction onPath2Fun = instantiatedOnPath2.GetComponent<NeprijateljFunction>();
                        //ako ista postoji
                        if (onPath2Fun != null)
                        {
                            onPath2Fun.GetParameters(scriptWithData.allLevelData.enemies[indexer].EneHP, scriptWithData.allLevelData.enemies[indexer].EneWorth);
                        }
                        break;
                }
                break;
            }
            indexer++;
        }
        //povećanje current list pos tj pozicije za jedan kako bi znali kojeg neprijatelja stvoriti
        currentListPos++;
    }
    //kad neprijatelj ume što se događa
    public void DecreaseEnemyCount()
    {
        EnemiesAlive--;
        if(EnemiesAlive <= 0) {
            Debug.Log("Wave Gotov");
            waveNumber++;
            if (waveNumber > ListofEnemies.Count)
            {
                string score = FindObjectOfType<InGameEventMaanger>().Score.GetComponent<Text>().text;
                FindObjectOfType<UIElementManager>().GameOver(score);                
            }
        }
    }
}
