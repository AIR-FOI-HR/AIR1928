using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    //prefabovi neprijatelja
    public Transform prefabGround;
    public Transform prefabAir;
    //Lokacija izlaska neprijatelja
    public Transform spawnPoint;
    //vrijeme između valova
    public float timeBetweenWaves = 5f;
    //2 sec do prvog
    private float countdown = 2f;
    //broj vala
    private int waveNumber = 0;
    private void Update()
    {
        //ako je odbrojavanje došlo do kraja
        if(countdown <= 0)
        {
            //stvori wave
            StartCoroutine(SpawnWave());
            //reset timera
            countdown = timeBetweenWaves + waveNumber;
        }
        //odbrojavanje
        countdown -= Time.deltaTime;
    }
    IEnumerator SpawnWave()
    {
        //povećanje broj wavea za 1
        waveNumber++;
        //stvareanje waveNumber neprijatelja
        for (int i = 0; i < waveNumber; i++)
        {
            SpawnEnemy();
            yield return new WaitForSeconds(0.5f);
        }
        //Debug.Log("Wave incoming");
    }
    void SpawnEnemy()
    {
        // posto šanse za neprijatelja
        switch (Random.Range(0, 2))
        {
            case 0:
                Instantiate(prefabGround, spawnPoint.position, spawnPoint.rotation);
                break;
            case 1:
                Instantiate(prefabAir, spawnPoint.position, spawnPoint.rotation);
                break;
        }
    }
}
