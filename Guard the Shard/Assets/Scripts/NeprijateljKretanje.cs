using UnityEngine;
using System.Collections.Generic;

public class NeprijateljKretanje : MonoBehaviour
{
    //brzina
    public float speed = 10f;
    //trenutna meta za kretanje
    private Transform target;
    //postavka indeksa na 0 kao uvjet za ostalo
    private int waypointIndex = 0;
    //za svrhe oduzimanja bodova na kraju puta
    public BaseHealth baseHealth;
    //1 za rutu a 2 za rutu 2
    public int route = 1;
    //============> put koji se prati mijenjati po potrebi !!!!!! <========
    //zasad je stavljeno na prvi put tj points1 (može se promijeniti na points2 ako je želi drugi put)
    public Waypoints movement;
    //ruta za kretanje pogledaj start za nastavak
    public List<Transform> travelRoute;
    //
    public void GetParameters(float _speed,int _route)
    {
        speed = _speed;
        route = _route;
    }


    void Start()
    {
        //dohvaćanje skripte
        baseHealth = GameObject.Find("BaseHealth").GetComponent<BaseHealth>();
        movement = GameObject.Find("Waypoints").GetComponent<Waypoints>();
        //============> put koji se prati mijenjati po potrebi !!!!!! <========
        //zasad je stavljeno na prvi put tj points1 (može se promijeniti na points2 ako je želi drugi put)
        switch (route)
        {
            case 1:
                travelRoute = movement.points1;
                break;
            case 2:
                travelRoute = movement.points2;
                break;
        }
        //travelRoute = movement.points1;
        //inicijalno postavljanje mete
        target = travelRoute[0];
    }

    void Update()
    {
        //postavljenje smjera
        Vector3 dir = target.position - transform.position;
        //Samo kretanje
        transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);
        //Ako smo došli do nekog waypointa idemo do sljedećeg
        if (Vector3.Distance(transform.position, target.position) <= 0.2f)
        {
            GetNextWaypoint();
        }
    }
    void GetNextWaypoint()
    {
        // prijelaz na sljedeću točku kretanja ili kraj put tj. uništenje neprijatelja
        if(waypointIndex >= travelRoute.Count - 1)
        {
            //uništenje
            baseHealth.TakeDamage();
            Destroy(gameObject);
            return;
        }
        //prijelaz
        waypointIndex++;
        target = travelRoute[waypointIndex];
    }
}
