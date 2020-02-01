using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Freeze : MonoBehaviour
{
    //parametri vještine
    float lifetime = 1;
    float SkillRange = 0;
    string[] Tags = null;
    //lista neprijatelja nad kojima treba nešto napraviti
    public List<GameObject> Targets = new List<GameObject>();
    void Awake()
    {
        //uništavanje nakon lifetime sekundi
        Destroy(gameObject, lifetime);
    }
    //stavljanje svih neprijatelja koji su u radijusu u listu
    public List<GameObject> GetAllEnemies()
    {
        GameObject[] enemiesPerTag = null;
        foreach (string tag in Tags)
        {
            enemiesPerTag = GameObject.FindGameObjectsWithTag(tag);
            foreach (GameObject obj in enemiesPerTag)
            {
                float distanceToEnemy = Vector3.Distance(transform.position, obj.transform.position);
                if (distanceToEnemy < SkillRange)
                {
                    Targets.Add(obj);
                }
            }
        }
        return Targets;
    }
    //dohvata parametara
    public void GetParameters(float range, string[] tags)
    {
        Tags = tags;
        SkillRange = range;
    }
}
