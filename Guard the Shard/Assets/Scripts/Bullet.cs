using UnityEngine;

public class Bullet : MonoBehaviour
{
    //target meta koju se napada , speed brzina kretanja podesiti po potrebi u unity editoru ne tu
    private Transform target;
    public float speed = 10f;
    //šteta koja se nanosi po udarcu
    public float damage;
    //Samo za prijenos parametra
    public void Seek(Transform _target, string type, float _damage)
    {
        target = _target;
        damage = _damage;
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
        //+ transform.Find("GroundBullet").gameObject.GetComponent<SpriteRenderer>().bounds.extents.x
        if (dir.magnitude <= (distanceThisFrame + transform.Find("GroundBullet").gameObject.GetComponent<SpriteRenderer>().bounds.extents.x))
        {
            HitTarget();
            return;
        }
        transform.Translate(dir.normalized * distanceThisFrame, Space.World);
        Vector3 moveDirection = gameObject.transform.position - target.transform.position;
        if (moveDirection != Vector3.zero)
        {
            float angle = Mathf.Atan2(moveDirection.y, moveDirection.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        }
    }
    //ako je metak dosao do mete 
    void HitTarget()
    {
        //uništi metak
        Destroy(gameObject);
        //=================>>dodati stripte za obračun štete za neprijatelje<<=====================
        target.gameObject.GetComponent<NeprijateljFunction>().TakeDamage(damage);
        return;
    }
}
