using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Freeze : MonoBehaviour
{
    //parametri vještine
    float lifetime = 1;
    float SkillRange = 0;
    int SkillDamage = 0;
    float SkillSlow = 0;
    float SKillDuration = 0;
    //lista neprijatelja nad kojima treba nešto napraviti
    public List<GameObject> Targets = new List<GameObject>();
    void Awake()
    {
        //uništavanje nakon lifetime sekundi
        Destroy(gameObject, lifetime);
    }
    private void Start()
    {
        GetAllEnemies();
        DoEfect();
    }
    //stavljanje svih neprijatelja koji su u radijusu u listu
    void GetAllEnemies()
    {
        GameObject[] enemiesAir = null;
        GameObject[] enemiesGround = null;
        enemiesGround = GameObject.FindGameObjectsWithTag("EarthEnemy");
        enemiesAir = GameObject.FindGameObjectsWithTag("AirEnemy");
        foreach (GameObject enemy in enemiesGround)
        {
            //provjera udaljenosti
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
            if (distanceToEnemy < SkillRange)
            {
                Targets.Add(enemy);
            }
        }
        foreach (GameObject enemy in enemiesAir)
        {
            //provjera udaljenosti
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
            if (distanceToEnemy < SkillRange)
            {
                Targets.Add(enemy);
            }
        }
    }
    //samo aktiviranje efekta vještine nad neprijateljima
    public void DoEfect()
    {
        foreach (GameObject enemy in Targets)
        {
            enemy.GetComponent<NeprijateljFunction>().TakeDamage(SkillDamage);
            if (SkillSlow != 0) enemy.GetComponent<NeprijateljKretanje>().SlowEnemy(SkillSlow, SKillDuration);
        }
    }
    //dohvata parametara
    public void GetParameters(float range, int damage, float slow, float duration)
    {
        SkillRange = range;
        SkillDamage = damage;
        SkillSlow = slow;
        SKillDuration = duration;
    }
}
