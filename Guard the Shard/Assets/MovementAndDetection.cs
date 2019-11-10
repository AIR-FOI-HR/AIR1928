using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementAndDetection : MonoBehaviour
{
    private MovementOfTurret script;
    // Start is called before the first frame update
    void Start()
    {
        script = GameObject.FindGameObjectWithTag("Turret").GetComponent<MovementOfTurret>();
    }
    
    private bool RaycastElemnt(string tag, RaycastHit2D[] hits)
    {
        bool answer = false;
        foreach (var item in hits)
        {
            if(item.collider.tag == tag)
            {
                answer = true;
            }
        }
        return answer;
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount == 1 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            //Debug.Log("tap");
            Vector2 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position);
            RaycastHit2D[] hits = Physics2D.RaycastAll(mouseWorldPos, Vector2.zero);
            if (script.selected == false)
            {
                if (RaycastElemnt("Turret",hits))
                {
                    script.selected = true;
                    //Debug.Log(script.selected);
                }
            }
            else
            {
                if(RaycastElemnt("Turret", hits))
                {
                    script.selected = false;
                    //Debug.Log(script.selected);
                }
                else if(RaycastElemnt("Usable", hits))
                {
                    script.Teleport();
                    script.selected = false;
                }
            }
            
        }
    }
}
