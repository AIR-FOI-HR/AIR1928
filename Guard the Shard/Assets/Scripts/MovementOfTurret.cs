using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementOfTurret : MonoBehaviour
{
    //selektiranost za kretanje
    public bool selected = false;
    void Start()
    {

    }

    public void Teleport()
    {
        //micanje na poziciju klika + postavljanje z na 0
        transform.position = Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position);
        transform.position = new Vector3(transform.position.x, transform.position.y, 0);
    } 
    void Update()
    {
        
    }
}
