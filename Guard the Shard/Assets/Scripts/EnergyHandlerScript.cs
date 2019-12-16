using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnergyHandlerScript : MonoBehaviour
{
    public int Energy = 100;
    public void Deduct(int cost)
    {
        Energy = Energy - cost;
    }
}
