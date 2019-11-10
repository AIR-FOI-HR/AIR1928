using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementOfTurret : MonoBehaviour
{
    public bool selected = false;
    void Start()
    {

    }

    public void Teleport()
    {
        transform.position = Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position);
    } 
    void Update()
    {
        
    }
}
