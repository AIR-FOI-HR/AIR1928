using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingTurret : MonoBehaviour
{
    public float speed = 50f;
    private Vector3 target;
    public static bool selected = true;
    void Start()
    {
        target = transform.position;
    }
    public void Movement(Vector3 target)
    {
        transform.position = Vector3.Lerp(transform.position, target, speed * Time.deltaTime);
        selected = false;
    }
    void OnMouseDown()
    {
        Debug.Log("Selektirano!");
        selected = true;
    }
    void Update()
    {
        
    }
}
