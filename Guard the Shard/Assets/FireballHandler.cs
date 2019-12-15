using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireballHandler : MonoBehaviour, ISkillInterface
{
    GameObject InstanceOfSkill = null;
    public bool DeductCost(int cost)
    {
        int usableEnergy = GameObject.Find("EnergyHandler").GetComponent<EnergyHandlerScript>().Energy;
        if(usableEnergy >= cost)
        {
            GameObject.Find("EnergyHandler").GetComponent<EnergyHandlerScript>().Deduct(cost);
            return true;
        }
        return false;

    }

    public void PrepareForUse()
    {
        InstanceOfSkill = Resources.Load("FireballSkill") as GameObject;
    }

    public void SpawnObject(Vector3 vector3)
    {
        if (DeductCost(5))
        {
            Instantiate(InstanceOfSkill, vector3, Quaternion.identity);
        }
    }
    void Awake()
    {
        PrepareForUse();
    }
}
