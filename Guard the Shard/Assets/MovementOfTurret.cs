using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementOfTurret : MonoBehaviour
{
    public bool selected = false;
    Vector3 newPosition;
    // Start is called before the first frame update
    void Start()
    {
        newPosition = transform.position;
    }

    public void Teleport(RaycastHit2D hit)
    {
        transform.position = Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position);
        //transform.position = new Vector2(x, y);
        //transform.position = new Vector3(hit.transform.position.x, hit.transform.position.y, transform.position.z);

    } 
    // Update is called once per frameInput.GetTouch(0).
    void Update()
    {
        
    }
}
