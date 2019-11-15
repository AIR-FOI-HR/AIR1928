using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseHealth : MonoBehaviour
{
    public int LivesLeft = 5;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    //Uzimanje štete kad je neprijatelj došao do kraja svog puta
    public void TakeDamage()
    {
        //oduzima se jedan život
        LivesLeft--;
        //ako smo ostali bez života
        if (LivesLeft <= 0)
        {
            //Game over and shit
        }
    }
}
