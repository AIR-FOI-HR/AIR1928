using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : MonoBehaviour
{
    float range = 2f;
    float damage = 5;
    float lifetime = 1;
    //GameObject[] enemiesAir = null;
    //GameObject[] enemiesGround = null;
    public List<GameObject> Targets = new List<GameObject>();
    void Awake()
    {
        Destroy(gameObject, lifetime);
    }
    private void Start()
    {
        GetAllEnemies();
        DoEfect();
    }
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
            if (distanceToEnemy < range)
            {
                Targets.Add(enemy);
            }
        }
        foreach (GameObject enemy in enemiesAir)
        {
            //provjera udaljenosti
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
            if (distanceToEnemy < range)
            {
                Targets.Add(enemy);
            }
        }
    }
    public void DoEfect()
    {
        foreach (GameObject enemy in Targets)
        {
            enemy.GetComponent<NeprijateljFunction>().TakeDamage(damage);
        }
    }
}
