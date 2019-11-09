using UnityEngine;
using System.Collections.Generic;

public class Waypoints : MonoBehaviour
{
    //prvi put za neprijatelje
    public static List<Transform> points1 = new List<Transform>();
    //drugi put za neprijatelje
    public static List<Transform> points2 = new List<Transform>();

    void Awake()
    {
        // stavlja sve waypointe u listu

        //samo da drži trenutni objekt
        Transform current;
        //iterira kroz svu djecu
        for (int i = 0; i< transform.childCount; i++)
        {
            //postavlje i-to dijete u varijablu
            current = transform.GetChild(i);
            //stavlja se u listu po tome gdje pripada
            if (current.CompareTag("Route1"))
            {
                points1.Add(current);
            }
            if (current.CompareTag("Route2"))
            {
                points2.Add(current);
            }
        }
    }
}
