using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NeprijateljFunction : MonoBehaviour
{
    //život neprijatelja ako padne na 0 objekt se uništava
    public float health = 100;
    //bodovi po uništenju neprijatelja
    public int worth = 50;
    //uzimanje štete
    public void TakeDamage(float amount)
    {
        //oduzimanje života jednako količini štete koja se nanosi
        health -= amount;
        //ako health-a više nema pokreće se funkcija za uništavanje
        if(health <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        //===========> TO DO: tu animacije za smrt <===================
        //napomena za Zvonu u ovoj se funkciji ovaj objekt MORA uništiti da sve funkcionira kako spada
        //u suprotnom će turret i danlje gađati ovaj objekt, stoga animaciju staviti u drugi objekt

        //===========> TO DO: nadodati worth + kalkulacije na score <=============
        Destroy(gameObject);
    }
}
