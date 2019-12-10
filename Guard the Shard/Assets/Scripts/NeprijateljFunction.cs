using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NeprijateljFunction : MonoBehaviour
{
    //život neprijatelja ako padne na 0 objekt se uništava
    public float health = 100;
    //bodovi po uništenju neprijatelja
    public int worth = 50;
    //uzimanje štete
    public Scoring scorinScript;
    //dohvaćanje parametara koji su došli s weba
    public void GetParameters(float _health,int _worth)
    {
        health = _health;
        worth = _worth;
    }
    public void TakeDamage(float amount)
    {
        scorinScript = GameObject.Find("Score").GetComponent<Scoring>();
        //oduzimanje života jednako količini štete koja se nanosi
        health -= amount;
        //ako health-a više nema pokreće se funkcija za uništavanje
        if(health <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        //===========> TO DO: tu animacije za smrt <===================
        //napomena za Zvonu u ovoj se funkciji ovaj objekt MORA uništiti da sve funkcionira kako spada
        //u suprotnom će turret i danlje gađati ovaj objekt, stoga animaciju staviti u drugi objekt
        //nadodavanje score-a
        scorinScript.AddScore(worth);
        SubtractFromEneNumber();
        //uništavanje objekta
        Destroy(gameObject);
    }
    void SubtractFromEneNumber()
    {
        EnemyStorySpawner spawner = GameObject.Find("WaveSpawnerStoryMode").GetComponent<EnemyStorySpawner>();
        if (spawner != null)
        {
            spawner.DecreaseEnemyCount();
        }
    }
}
