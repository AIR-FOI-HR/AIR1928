﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementAndDetection : MonoBehaviour
{
    //skripta iz turreta
    private MovementOfTurret script;
    // Start is called before the first frame update
    void Start()
    {
        script = GameObject.FindGameObjectWithTag("Turret").GetComponent<MovementOfTurret>();
    }
    //provjerava pronalazi li se među elementima raycasta element s traženim tag-om
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
        //ako je uhvaćen tap
        if (Input.touchCount == 1 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            //Debug.Log("tap");
            //raycasting
            Vector2 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position);
            RaycastHit2D[] hits = Physics2D.RaycastAll(mouseWorldPos, Vector2.zero);
            //turret nije selektiran
            if (script.selected == false)
            {
                //tap na turret
                if (RaycastElemnt("Turret",hits))
                {
                    //selektiraj ga
                    script.selected = true;
                    //Debug.Log(script.selected);
                }
            }
            //ako nije
            else
            {
                //tap na turret
                if(RaycastElemnt("Turret", hits))
                {
                    //deselektiran
                    script.selected = false;
                    //Debug.Log(script.selected);
                }
                else if(RaycastElemnt("Usable", hits))
                {
                    //teleportiraj i deselektiraj
                    script.Teleport();
                    script.selected = false;
                }
            }
            
        }
    }
}
