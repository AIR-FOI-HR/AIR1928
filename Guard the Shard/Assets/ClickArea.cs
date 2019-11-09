using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickArea : MonoBehaviour
{
    GameObject obj;
    Vector3 target;
    void OnMouseDown()
    {
        if (MovingTurret.selected == true)
        {
            Debug.Log("Clicked the Collider!");
            target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            target.z = transform.position.z;
            obj.GetComponent<MovingTurret>().Movement(target);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        obj = GameObject.FindGameObjectWithTag("Turret");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
