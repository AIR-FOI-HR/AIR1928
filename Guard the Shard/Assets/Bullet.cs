using UnityEngine;

public class Bullet : MonoBehaviour
{
    //target meta koju se napada , speed brzina kretanja podesiti po potrebi u unity editoru ne tu
    private Transform target;
    public float speed = 10f;
    //Samo za prijenos parametra
    public void Seek(Transform _target, string type)
    {
        target = _target;
        //gašenje slike metka koji ne odgovara tipu
        if(type != "ground")
            transform.Find("GroundBullet").gameObject.SetActive(false);
        else
            transform.Find("AirBullet").gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        //ako nema mete nemoj nista
        if(target == null)
        {
            Destroy(gameObject);
            return;
        }
        //vektori za udaljenost
        Vector3 dir = target.position - transform.position;
        float distanceThisFrame = speed * Time.deltaTime;
        //za pogodak
        if(dir.magnitude <= distanceThisFrame)
        {
            HitTarget();
            return;
        }
        transform.Translate(dir.normalized * distanceThisFrame, Space.World);
    }
    //ako je metak dosao do mete 
    void HitTarget()
    {
        //uništi metak
        Destroy(gameObject);
        //=================>>dodati stripte za obračun štete za neprijatelje<<=====================
        return;
    }
}
