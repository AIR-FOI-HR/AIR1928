﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TurretAttacking : MonoBehaviour
{
    //meta
    public Transform target;
    //domet
    public float range = 4f;
    //šteta koja se nanosi pri napadu
    public float damage = 50;
    //tip turreta
    public string type = "ground";
    //broj metaka u sekundi
    public float fireRate = 1f;
    //instanciranje countdowna
    private float fireCountdown = 0f;
    //varijable koje drze objekte prvi za metak
    public GameObject bulletPrefab;
    //brzina metka
    public float bulletSpeed= 10f;
    //za poziciju odakle kreće metak
    public Transform firePoint;
    //button za zamjenu turretta
    public Button changeButton;
    //Komponenta koja sadržava sve podatke koji nam trebaju
    public LevelDataControler scriptWithData;
    void Awake()
    {
        //na klik gumba za promjenu se mijenja turreta
        changeButton.onClick.AddListener(TypeChange);

    }
    // Start is called before the first frame update
    void Start()
    {
        //dohvaćanje skripte koja sadržava dohvaćene podatke s interneta
        scriptWithData = GameObject.Find("DataHandler").GetComponent<LevelDataControler>();
        //postavljanje tih podataka
        range = scriptWithData.allLevelData.TurDmgRange;
        damage = scriptWithData.allLevelData.TurDamage;
        fireRate = scriptWithData.allLevelData.TurAttSp;
        bulletSpeed = scriptWithData.allLevelData.BullSpeed;
        //pozivanje UpdateTarget 2 puta u sekundi
        InvokeRepeating("UpdateTarget", 0f, 0.2f);
    }
    public void TypeChange()
    {
        //ako je zemljani tip onda se mijenja u zračni
        if (type == "ground")
        {
            transform.Find("GroundSprite").gameObject.SetActive(false);
            transform.Find("AirSprite").gameObject.SetActive(true);
            type = "air";
        }
        //ako je zračni mijenja se u zemljani
        else if (type == "air")
        {
            transform.Find("AirSprite").gameObject.SetActive(false);
            transform.Find("GroundSprite").gameObject.SetActive(true);
            type = "ground";
        }
    }
    void UpdateTarget()
    {
        //lista neprijatelja
        GameObject[] enemies = null;
        //ako je tip zemljani traži zemljane neprijatelje
        if (type== "ground")
        {
            enemies = GameObject.FindGameObjectsWithTag("EarthEnemy");
        }
        //ako je tip zračni traži zračne neprijatelje
        else if (type == "air")
        {
            enemies = GameObject.FindGameObjectsWithTag("AirEnemy");
        }
        //najkraća udaljenost prvo na beskonačno
        float shortestDistance = Mathf.Infinity;
        //najbliži neprijatelj
        GameObject nearestEnemy = null;
        //za svakog neprijatelja 
        foreach (GameObject enemy in enemies)
        {
            //provjera udaljenosti
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
            //ako je ovo bliži od dosadašnjeg najbližeg označi to
            if(distanceToEnemy < shortestDistance)
            {
                shortestDistance = distanceToEnemy;
                nearestEnemy = enemy;
            }
        }
        //provjeravanje jel uopce ima neprijatelja i jel uopce u radijusu
        if(nearestEnemy != null && shortestDistance <= range)
        {
            target = nearestEnemy.transform;
        }else
        {
            target = null;
        }
    }
    // Update is called once per frame
    void Update()
    {
        //ako mete nema return
        if(target == null)
        {
            return;
        }   
        //ako se može pucati pucaj
        if(fireCountdown <= 0)
        {
            Shoot();
            fireCountdown = 1f / fireRate;
        }
        //smanjivanje countdowna
        fireCountdown -= Time.deltaTime;
    }
    void Shoot()
    {
        //Debug.Log("Shoot");
        //instanciranje metka i spremanje tog metka u varijablu
        GameObject bulletGO = (GameObject)Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Bullet bullet = bulletGO.GetComponent<Bullet>();
        //ako je bullet postavljen prosljedi metu
        if(bullet != null)
        {
            bullet.Seek(target,type,damage, bulletSpeed);
        }
    }
    //Gizmos da mozemo vit radijus u kojem se gađa
    void OnDrawGizmos()
    {
        //crvena sfera
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position,range);
    }
}
