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
    //============> put koji se prati mijenjati po potrebi !!!!!! <========
    //zasad je stavljeno na prvi put tj points1 (može se promijeniti na points2 ako je želi drugi put)
    public static List<Transform> travelRoute = Waypoints.points1;

    void Start()
    {
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
            Destroy(gameObject);
            return;
        }
        //prijelaz
        waypointIndex++;
        target = travelRoute[waypointIndex];
    }
}
